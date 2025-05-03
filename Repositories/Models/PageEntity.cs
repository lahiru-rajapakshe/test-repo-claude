using Common.Models;

namespace Common.Infrastructure.Repositories.Models
{
    public class PageEntity : BaseMongoEntity
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public long TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1;

        public bool HasNext => CurrentPage < TotalPages;

    }
}
