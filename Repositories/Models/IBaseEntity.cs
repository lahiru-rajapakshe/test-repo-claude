namespace Common.Models
{
    public interface IBaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
