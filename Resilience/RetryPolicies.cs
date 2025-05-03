using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Polly.Retry;

namespace Common.Resilience;

/// <summary>
/// Contains retry policies used across the system
/// </summary>
public static class RetryPolicies
{
    /// <summary>
    /// Provides a retry policy for HttpClient to handle transient HTTP errors.
    /// Utilizes a jittered exponential backoff strategy.
    /// </summary>
    public static AsyncRetryPolicy<HttpResponseMessage> HttpClientRetryPolicy =>
        HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(
                Backoff.DecorrelatedJitterBackoffV2(
                    medianFirstRetryDelay: TimeSpan.FromSeconds(1),
                    retryCount: 1));
}