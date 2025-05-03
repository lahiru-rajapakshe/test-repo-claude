namespace Common.RequestContext;

/// <summary>
/// Provides read-only access to the current request context.
/// </summary>
public interface IRequestContext
{
    /// <summary>
    /// The request ID.
    /// </summary>
    public string RequestId { get; }
    public string? TenantId { get;  }
    public string? UserId { get;  }
    public string? AccessToken { get;  }
    public string? Language { get; }
}