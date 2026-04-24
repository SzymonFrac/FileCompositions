using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Specialized.Json.Abstract;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Descriptor;

internal interface IJsonDefinitionDescriptor<TOwnership, TNecessity, TData>
    : IFileDefinitionDescriptor<JsonDefinition<TOwnership, TNecessity, TData>, TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity;
