using FileCompositions.Core.File.Resource.Builder;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Builder;

public interface IFileDefinitionBuilder<TOwnership, TNecessity> : IFileResourceBuilder
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity;
