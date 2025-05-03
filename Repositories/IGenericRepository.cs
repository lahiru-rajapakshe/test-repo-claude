using Common.Infrastructure.Repositories.Models;
using Common.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Common.Infrastructure.Repository
{
    public interface IGenericRepository<TEntity, TId> where TEntity : IBaseEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);
        Task<TEntity> GetByIdAsync(string id, string field);
        Task InsertAsync(TEntity entity);
        Task InsertManyAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(string id, string field, TEntity entity);
        Task UpdateFieldAsync<TField>(int id, string filterfield, Expression<Func<TEntity, TField>> field, TField value);
        Task UpdateAllAsync(int id, string idField, TEntity entity);
        Task DeleteAsync(TId id);
        Task DeleteAsync(string id, string field);
        Task<IEnumerable<TEntity>> FilterByAsync(FilterDefinition<TEntity> filter);
        Task<TProjection> FindOneAsync<TProjection>(
            Expression<Func<TEntity, bool>> filterExpression,
            Expression<Func<TEntity, TProjection>> projectionExpression);

        Task<List<TEntity>> GetByFieldAsync(string fieldName, string fieldValue);
        Task<PaginatedList<TEntity>> GetAllAsync(int? page, int? pageSize, string searchTerm, string searchField);//with pagination support

        Task<List<TEntity>> FindByFilterAsync(FilterDefinition<TEntity> filter);
        Task<TEntity> FindOneAndUpdateAsync(FilterDefinition<TEntity> filter,UpdateDefinition<TEntity> update,FindOneAndUpdateOptions<TEntity> options = null);
        Task UpsertAsync(TEntity entity, TId idField);
        Task DeleteManyAsync(FilterDefinition<TEntity> filter, IClientSessionHandle session = null);
    }
}
