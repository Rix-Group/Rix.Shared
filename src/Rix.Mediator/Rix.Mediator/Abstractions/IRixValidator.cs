namespace Rix.Mediator.Abstractions;

/// <summary>
/// An interface for validators - used for internals
/// </summary>
public interface IRixValidator;

/// <summary>
/// A class that validates requests
/// </summary>
/// <typeparam name="TRequest">Request type</typeparam>
public interface IRixValidator<TRequest> : IRixValidator where TRequest : IRixRequest
{
    /// <summary>
    /// Handles requests
    /// </summary>
    /// <param name="request">The request to handle</param>
    /// <param name="error">The error returned if invalid</param>
    /// <returns>True if valid</returns>
    public Task<bool> IsValidAsync(TRequest request, out string error);
}