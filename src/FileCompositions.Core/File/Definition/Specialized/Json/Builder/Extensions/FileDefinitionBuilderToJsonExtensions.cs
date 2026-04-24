using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Specialized.Json.Builder.Implementations;
using FileCompositions.Core.File.Resource.Specialized.Json.FormatContext;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Builder.Extensions;

public static class FileDefinitionBuilderToJsonExtensions
{
    extension(IFileDefinitionBuilder builder)
    {
        public IJsonDefinitionBuilder<StrictDefinition, RequiredDefinition, TData> Json<TData>() =>
            new JsonDefinitionBuilder<StrictDefinition, RequiredDefinition, TData>(JsonResourceFormatContext.Default);
    }
}
