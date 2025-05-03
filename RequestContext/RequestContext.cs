namespace Common.RequestContext
{
    /// <summary>
    /// Contains information about the current request.
    /// </summary>
    public class RequestContext : IRequestContext, IMutableRequestContext
    {
        /// <summary>
        /// Gets or sets the unique identifier for the current request.
        /// </summary>
        public string RequestId { get; set; } = null!;

        /// <summary>
        /// Gets or sets the identifier for the current tenant associated with the request.
        /// </summary>
        public string TenantId { get; set; } = null!;
        public string AccessToken { get; set; } = null!;

        /// <summary>
        /// Gets or sets the optional identifier for the user associated with the request.
        /// </summary>
        public string? UserId { get; set; }
        public string? ApiKey { get; set; }

        public string? Language { get; set; } = null!;
    }
}