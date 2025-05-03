namespace Common.RequestContext;

/// <summary>
/// Provides mutable access to the current request context.
/// </summary>
public interface IMutableRequestContext
{
    /// <summary>
    /// The request ID.
    /// </summary>
    public string RequestId { get; set; }
    
    /// <summary>
    /// The  AccessToken.
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// The tenant ID.
    /// </summary>
    public string TenantId { get; set; }

    /// <summary>
    /// The user ID.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Api auth
    /// </summary>
    public string? ApiKey { get; set; }
}