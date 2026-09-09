using FileCompositions.Core.FileSystem.Session.Request;

namespace FileCompositions.Core.FileSystem.Session.Source;

internal partial interface ISessionSource
{
    Task RequestAsync(SessionRequest request, CancellationToken cancellationToken = default);
    Task<TResult> RequestAsync<TResult>(SessionRequest<TResult> request, CancellationToken cancellationToken = default);
}
