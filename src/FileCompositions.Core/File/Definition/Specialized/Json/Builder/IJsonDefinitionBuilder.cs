using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Json.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using System.Text.Json;

namespace FileCompositions.Core.File.Definition.Specialized.Json.Builder;

public interface IJsonDefinitionBuilder<TOwnership, TNecessity, TData> : IFileDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithKey(FileDefinitionKey key);
    IJsonDefinitionBuilder<TOwnership, TNecessity, TData> WithName(string name);
    IJsonDefinitionBuilder<TOwnership, TNecessity, TData> UseSerializerOptions(JsonSerializerOptions options);

    IJsonDefinitionBuilder<ExternalDefinition, TNecessity, TData> External();
    IJsonDefinitionBuilder<StrictDefinition, TNecessity, TData> Strict();
    IJsonDefinitionBuilder<TOwnership, RequiredDefinition, TData> Required();
    IJsonDefinitionBuilder<TOwnership, OptionalDefinition, TData> Optional();

    internal IJsonDefinition<TOwnership, TPlacement, TData> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement;
    internal IJsonDefinitionDescriptor<TOwnership, TPlacement, TData> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement;
}
