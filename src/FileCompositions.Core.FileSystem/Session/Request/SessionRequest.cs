namespace FileCompositions.Core.FileSystem.Session.Request;

internal delegate Task SessionRequest(ISession session, CancellationToken cancellationToken = default);
internal delegate Task<TResult> SessionRequest<TResult>(ISession session, CancellationToken cancellationToken = default);
