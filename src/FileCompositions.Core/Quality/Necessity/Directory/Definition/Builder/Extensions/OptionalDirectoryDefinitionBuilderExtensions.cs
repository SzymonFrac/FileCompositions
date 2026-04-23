using FileCompositions.Core.Directory.Definition.Builder;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Storage.Backend;

namespace FileCompositions.Core.Quality.Necessity.Directory.Definition.Builder.Extensions;

public static class OptionalDirectoryDefinitionBuilderExtensions
{
    extension<TOwnership>(IDirectoryDefinitionBuilder<TOwnership, OptionalDefinition> builder)
        where TOwnership : DefinitionOwnership
    {
        
    }

    extension<TOwnership, TBackend>(IDirectoryDefinitionBuilder<TOwnership, OptionalDefinition, TBackend> builder)
        where TOwnership : DefinitionOwnership
        where TBackend : class, IStorageBackend
    {
        
    }
}
