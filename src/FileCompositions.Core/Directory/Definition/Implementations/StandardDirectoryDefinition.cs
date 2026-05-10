using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Abstract;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Address;

namespace FileCompositions.Core.Directory.Definition.Implementations;

internal class StandardDirectoryDefinition<TOwnership, TNecessity>(IDirectoryContext context, DirectoryDefinitionKey key, StorageAddress address)
    : DirectoryDefinition<TOwnership, TNecessity>(context, key, address)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
