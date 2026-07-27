using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder;

public interface IDllDefinitionBuilder<TOwnership, TNecessity> : IFileDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    IDllDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key);
    IDllDefinitionBuilder<TOwnership, TNecessity> WithName(string name);

    IDllDefinitionBuilder<ExternalDefinition, TNecessity> External();
    IDllDefinitionBuilder<StrictDefinition, TNecessity> Strict();
    IDllDefinitionBuilder<TOwnership, RequiredDefinition> Required();
    IDllDefinitionBuilder<TOwnership, OptionalDefinition> Optional();

    internal IDllDefinition<TOwnership, TPlacement> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement;
    internal IDllDefinitionDescriptor<TOwnership, TPlacement> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement;
}
