using FileCompositions.Core.File.Quality.Ext;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Quality.Ext;

public static partial class UnspecifiedQualityExt
{
    extension<TOwnership>(IUnspecifiedQuality<TOwnership, Placement.RequiredInRequired> unspecified)
        where TOwnership : Ownership
    {
        public Task<Stream> ReadAsync(CancellationToken cancellationToken = default) => unspecified.OpenReadAsync(cancellationToken);
        public Task<Stream> WriteAsync(CancellationToken cancellationToken = default) => unspecified.OpenWriteAsync(cancellationToken);
        public Task<Stream> AppendAsync(CancellationToken cancellationToken = default) => unspecified.OpenAppendAsync(cancellationToken);
    }

    extension(IUnspecifiedQuality<Ownership.Internal, Placement.OptionalInRequired> unspecified)
    {
        public Task<Stream?> ReadAsync(CancellationToken cancellationToken = default) => unspecified.OpenReadAsync(cancellationToken);
        public Task<Stream> WriteAsync(CancellationToken cancellationToken = default) => unspecified.OpenWriteAsync(cancellationToken);
        public Task<Stream> AppendAsync(CancellationToken cancellationToken = default) => unspecified.OpenAppendAsync(cancellationToken);
    }

    extension(IUnspecifiedQuality<Ownership.External, Placement.OptionalInRequired> unspecified)
    {
        public Task<Stream?> ReadAsync(CancellationToken cancellationToken = default) => unspecified.OpenReadAsync(cancellationToken);
        public Task<Stream?> WriteAsync(CancellationToken cancellationToken = default) => unspecified.OpenWriteAsync(cancellationToken);
        public Task<Stream?> AppendAsync(CancellationToken cancellationToken = default) => unspecified.OpenAppendAsync(cancellationToken);
    }

    extension(IUnspecifiedQuality<Ownership.Internal, Placement.OptionalInOptional> unspecified)
    {
        public Task<Stream?> ReadAsync(CancellationToken cancellationToken = default) => unspecified.OpenReadAsync(cancellationToken);
        public Task<Stream?> WriteAsync(CancellationToken cancellationToken = default) => unspecified.OpenWriteAsync(cancellationToken);
        public Task<Stream?> AppendAsync(CancellationToken cancellationToken = default) => unspecified.OpenAppendAsync(cancellationToken);
    }

    extension(IUnspecifiedQuality<Ownership.External, Placement.OptionalInOptional> unspecified)
    {
        public Task<Stream?> ReadAsync(CancellationToken cancellationToken = default) => unspecified.OpenReadAsync(cancellationToken);
        public Task<Stream?> WriteAsync(CancellationToken cancellationToken = default) => unspecified.OpenWriteAsync(cancellationToken);
        public Task<Stream?> AppendAsync(CancellationToken cancellationToken = default) => unspecified.OpenAppendAsync(cancellationToken);
    }
}
