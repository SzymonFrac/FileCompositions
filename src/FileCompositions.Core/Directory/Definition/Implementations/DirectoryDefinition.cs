using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Directory.Location.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Address;

namespace FileCompositions.Core.Directory.Definition.Implementations;

internal class DirectoryDefinition<TOwnership, TNecessity>(DirectoryDefinitionKey key, IDirectoryContext context, StorageAddress address) :
    DirectoryLocation(context, address), IDirectoryDefinition<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    public DirectoryDefinitionKey Key { get; } = key;
}
