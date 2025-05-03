namespace Common.Infrastructure
{
    /// <summary>
    /// Defines constants related to logging and headers.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Header name for the request ID.
        /// </summary>
        public const string RequestIdHeaderName = "X-Request-ID";

        /// <summary>
        /// Header name for the authorization token.
        /// </summary>
        public const string AuthorizationHeaderName = "Authorization";

        /// <summary>
        /// Log key for the request ID.
        /// </summary>
        public const string RequestIdLogKey = "RequestID";

        /// <summary>
        /// Log key for the tenant ID.
        /// </summary>
        public const string TenantIdLogKey = "TenantID";

        /// <summary>
        /// Header name for the tenant ID.
        /// </summary>
        public const string TenantIdHeaderName = "X-Tenant-ID";

        /// <summary>
        /// Log key for the user ID.
        /// </summary>
        public const string UserIdLogKey = "UserID";

        /// <summary>
        /// Header name for the user ID.
        /// </summary>
        public const string UserIdHeaderName = "X-User-ID";

        /// <summary>
        /// Header name for the access token.
        /// </summary>
        public const string AccessTokenHeaderName = "Authorization";

        /// <summary>
        /// Header name for API Key authentication.
        /// </summary>
        public const string ApiKeyHeaderName = "X-API-KEY";

        /// <summary>
        /// Log key for API Key authentication.
        /// </summary>
        public const string ApiKeyLogKey = "ApiKey";

        /// <summary>
        /// Claim key for the tenant ID.
        /// </summary>
        public const string TenantIdClaimKey = "tenant_id";

        public const string Language = "language";
    }
}