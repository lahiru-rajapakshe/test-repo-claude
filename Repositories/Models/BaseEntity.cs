using Common.Models;

public class BaseEntity : BaseMongoEntity
{
    public string? Scope { get; set; }
    public string? TenantId { get; set; }
    public string? PropertyId { get; set; }
    public bool? IsActive { get; set; } = true;
}

