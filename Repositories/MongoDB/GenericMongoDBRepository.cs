using Common.Infrastructure.MongoDB;
using Common.Infrastructure.Repositories.Helpers;
using Common.Infrastructure.Repositories.Models;
using Common.Models;
using Common.RequestContext;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Common.Infrastructure.Repository.MongoDB
{
    public class GenericMongoDBRepository<TEntity> : IGenericRepository<TEntity, string> where TEntity : BaseMongoEntity
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMongoCollection<TEntity> _collection;

        public GenericMongoDBRepository(
            IMongoDbClientProvider mongoDbClientProvider,
            IServiceProvider serviceProvider,
            string databaseName,
            string collectionName)
        {
            _serviceProvider = serviceProvider;
            var database = mongoDbClientProvider.Client.GetDatabase(databaseName);
            _collection = database.GetCollection<TEntity>(collectionName);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<List<TEntity>> FindByFilterAsync(FilterDefinition<TEntity> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<TEntity> GetByIdAsync(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<TEntity> GetByIdAsync(string id, String field)
        {
            var filter = Builders<TEntity>.Filter.Eq(field, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task InsertAsync(TEntity entity)
        {
            var requestContext = _serviceProvider.GetService<IRequestContext>();

            if (entity is TenantEntity tenantEntity)
            {

                if (requestContext?.TenantId != null)
                {
                    tenantEntity.TenantId = requestContext.TenantId;
                }
            }

            if (requestContext?.UserId != null)
            {
                entity.CreatedBy = requestContext.UserId;
                entity.ModifiedBy = requestContext.UserId;
            }

            entity.CreatedOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;

            await _collection.InsertOneAsync(entity);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task InsertManyAsync(IEnumerable<TEntity> entities)
        {


            await _collection.InsertManyAsync(entities);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);

            var currentDocument = await _collection.Find(filter).FirstOrDefaultAsync();

            if (currentDocument == null)
                throw new KeyNotFoundException($"Document with ID {entity.Id} not found.");

            // Add ModifiedOn and ModifiedBy fields
            entity.ModifiedOn = DateTime.UtcNow;

            var requestContext = _serviceProvider.GetService<IRequestContext>();
            if (requestContext?.UserId != null)
            {
                entity.ModifiedBy = requestContext.UserId;
            }

            var mergedDocument = DocumentMerger.MergeDocuments(currentDocument, entity);

            var updateDefinition = PatchEntityHelper.CreateUpdateDefinition(
                mergedDocument,
                e => e.Id
            );

            if (updateDefinition != null)
            {
                await _collection.UpdateOneAsync(filter, updateDefinition);

                var updatedDocument = await _collection.Find(filter).FirstOrDefaultAsync();

                return updatedDocument;
            }
            else
            {
                throw new InvalidOperationException("No valid fields to update.");
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<TEntity> UpdateAsync(string id, string field, TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            // Dynamically construct the filter
            var filter = Builders<TEntity>.Filter.Eq(field, id);

            var currentDocument = await _collection.Find(filter).FirstOrDefaultAsync();

            if (currentDocument == null)
                throw new KeyNotFoundException($"Document with ID {entity.Id} not found.");

            // Add ModifiedOn and ModifiedBy fields
            entity.ModifiedOn = DateTime.UtcNow;

            var requestContext = _serviceProvider.GetService<IRequestContext>();
            if (requestContext?.UserId != null)
            {
                entity.ModifiedBy = requestContext.UserId;
            }

            var mergedDocument = DocumentMerger.MergeDocuments(currentDocument, entity);
            var updateDefinition = PatchEntityHelper.CreateUpdateDefinition(
              mergedDocument,
              e => e.Id
             );

            if (updateDefinition != null)
            {
                await _collection.UpdateOneAsync(filter, updateDefinition);

                var updatedDocument = await _collection.Find(filter).FirstOrDefaultAsync();

                return updatedDocument;
            }
            else
            {
                throw new InvalidOperationException("No valid fields to update.");
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------

        public async Task UpdateFieldAsync<TField>(int id, string filterfield, Expression<Func<TEntity, TField>> field, TField value)
        {
            var filter = Builders<TEntity>.Filter.Eq(filterfield, id);

            var update = Builders<TEntity>.Update.Set(field, value);

            update = update
                .Set(e => e.ModifiedOn, DateTime.UtcNow)
                .Set(e => e.ModifiedBy, _serviceProvider.GetService<IRequestContext>()?.UserId);

            // Execute the update operation
            await _collection.UpdateOneAsync(filter, update);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task UpdateAllAsync(int id, string idField, TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(idField, id);
            entity.ModifiedOn = DateTime.UtcNow;

            if (_serviceProvider.GetService<IRequestContext>() is IRequestContext requestContext)
            {
                entity.ModifiedBy = requestContext.UserId;
            }

            var updateDefinitionBuilder = Builders<TEntity>.Update;
            var updateDefinition = new List<UpdateDefinition<TEntity>>();

            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)) // Excluding String ID Which mentioned in Base entity // TODO: Implement Base Entity int ID
                    continue;

                var value = property.GetValue(entity);
                updateDefinition.Add(updateDefinitionBuilder.Set(property.Name, value));
            }

            await _collection.UpdateOneAsync(filter, updateDefinitionBuilder.Combine(updateDefinition));
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task DeleteAsync(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, id);
            await _collection.DeleteOneAsync(filter);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task DeleteAsync(string id, String field)
        {
            var filter = Builders<TEntity>.Filter.Eq(field, id);
            await _collection.DeleteOneAsync(filter);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<IEnumerable<TEntity>> FilterByAsync(FilterDefinition<TEntity> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<TProjection> FindOneAsync<TProjection>(
            Expression<Func<TEntity, bool>> filterExpression,
            Expression<Func<TEntity, TProjection>> projectionExpression)
        {
            return await _collection.Find(filterExpression).Project(projectionExpression).FirstOrDefaultAsync();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            var filterDefinition = Builders<TEntity>.Filter.Where(filter);
            return await _collection.Find(filterDefinition).FirstOrDefaultAsync();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<List<TEntity>> GetByFieldAsync(string fieldName, string fieldValue)
        {

            // Build a filter based on the fieldName and fieldValue
            var filter = Builders<TEntity>.Filter.Eq(fieldName, fieldValue);

            // Query the collection to get matching entities
            var result = await _collection.Find(filter).ToListAsync();

            return result;

        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            return await _collection.Find(filterExpression).FirstOrDefaultAsync();
        }

        public async Task<PaginatedList<TEntity>> GetAllAsync(int? page, int? pageSize, string searchTerm, string searchField)
        {
            var filter = string.IsNullOrEmpty(searchTerm) || string.IsNullOrEmpty(searchField)
                ? Builders<TEntity>.Filter.Empty
                : Builders<TEntity>.Filter.Regex(searchField, new BsonRegularExpression(searchTerm, "i"));

            // Sort first by UpdatedOn (descending), then by CreatedOn (descending)
            var sortDefinition = Builders<TEntity>.Sort
                .Descending("ModifiedOn")
                .Descending("CreatedOn");

            var totalCount = await _collection.CountDocumentsAsync(filter);

            if (page.HasValue && pageSize.HasValue)
            {
                var items = await _collection.Find(filter)
                    .Sort(sortDefinition)
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Limit(pageSize.Value)
                    .ToListAsync();

                return new PaginatedList<TEntity>(items, totalCount, page.Value, pageSize.Value);
            }
            else
            {
                var items = await _collection.Find(filter)
                    .Sort(sortDefinition)
                    .ToListAsync();
                return new PaginatedList<TEntity>(items, totalCount, 1, (int)totalCount);  // Defaults to a single page with all items.
            }
        }

        public async Task<TEntity> FindOneAndUpdateAsync(FilterDefinition<TEntity> filter,UpdateDefinition<TEntity> update,FindOneAndUpdateOptions<TEntity> options = null)
        {
            options ??= new FindOneAndUpdateOptions<TEntity> { ReturnDocument = ReturnDocument.After };

            return await _collection.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task UpsertAsync(TEntity entity, string idField)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, idField);

            entity.ModifiedOn = DateTime.UtcNow;
            var updateOptions = new ReplaceOptions { IsUpsert = true };
            await _collection.ReplaceOneAsync(filter, entity, updateOptions);
        }

        public async Task DeleteManyAsync(FilterDefinition<TEntity> filter, IClientSessionHandle session = null)
        {
            if (session != null)
            {
                await _collection.DeleteManyAsync(session, filter);
            }
            else
            {
                await _collection.DeleteManyAsync(filter);
            }
        }
    }
}
