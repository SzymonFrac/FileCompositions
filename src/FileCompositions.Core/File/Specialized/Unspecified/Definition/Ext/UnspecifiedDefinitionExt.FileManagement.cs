using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.FileSystem.Abstractions.Proxy;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Ext;

public static partial class UnspecifiedDefinitionExt
{
    extension(IUnspecifiedDefinition<Ownership.Internal, Placement.RequiredInRequired> unspecified)
    {

    }

    extension(IUnspecifiedDefinition<Ownership.External, Placement.RequiredInRequired> unspecified)
    {

    }

    extension(IUnspecifiedDefinition<Ownership.Internal, Placement.OptionalInRequired> unspecified)
    {
        public Task CreateAsync(CancellationToken cancellationToken = default) => unspecified.OpenCreateAsync(cancellationToken);
    }

    extension(IUnspecifiedDefinition<Ownership.External, Placement.OptionalInRequired> unspecified)
    {

    }

    extension(IUnspecifiedDefinition<Ownership.Internal, Placement.OptionalInOptional> unspecified)
    {
        public Task<bool> TryCreateAsync(CancellationToken cancellationToken = default) => unspecified.TryOpenCreateAsync(cancellationToken);
    }

    extension(IUnspecifiedDefinition<Ownership.External, Placement.OptionalInOptional> unspecified)
    {

    }
}
