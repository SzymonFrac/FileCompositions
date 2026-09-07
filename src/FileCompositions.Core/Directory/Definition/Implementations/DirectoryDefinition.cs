using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Abstract;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem.Address;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Directory.Definition.Implementations;

internal sealed class DirectoryDefinition<TOwnership, TNecessity>(IDirectoryContext context, DirectoryDefinitionKey key, FileSystemAddress address)
    : AbstractDirectoryDefinition<TOwnership, TNecessity>(context, key, address)
        where TOwnership : Ownership
        where TNecessity : Necessity;