using FileCompositions.Core.File.Config;
using FileCompositions.Core.File.Specialized.Json.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using System.Text.Json;

namespace FileCompositions.Core.File.Specialized.Json.Config;

// should have some IFileConfig to have sealed name...
public interface IJsonConfig<TData>
{
    IJsonConfig<TData> WithName(string name);
    IJsonConfig<TData> UseSerializerOptions(JsonSerializerOptions options);
    IJsonConfig<TData> UseDefault(TData @default);

    internal JsonDefinitionDescriptor<TOwnership, TPlacement, TData> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
}
