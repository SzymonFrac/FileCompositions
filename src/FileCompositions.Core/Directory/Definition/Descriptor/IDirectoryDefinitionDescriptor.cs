using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Directory.Definition.Descriptor;

internal interface IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TBackend>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBackend : class, IStorageBackend
{
    DirectoryDefinitionKey Key { get; }
    
    IDirectoryDefinition<TOwnership, TNecessity> Activate(in IDirectoryContext context);
}
