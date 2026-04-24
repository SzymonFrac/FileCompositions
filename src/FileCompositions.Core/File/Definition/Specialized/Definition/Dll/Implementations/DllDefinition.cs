using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Dll.Context;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Implementations;

internal class DllDefinition<TOwnership, TNecessity>(FileDefinitionKey key, IDllResourceContext context, StorageResourceName name) :
    AbstractDllDefinition<TOwnership, TNecessity>(key, context, name)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
