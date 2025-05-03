namespace Common.Models;

/// <summary>
/// An entity that is tenant aware.
/// </summary>
public abstract class TenantEntity : BaseMongoEntity
{
    public string? TenantId { get; set; } = null;
    public bool? IsActive { get; set; } = true;
}