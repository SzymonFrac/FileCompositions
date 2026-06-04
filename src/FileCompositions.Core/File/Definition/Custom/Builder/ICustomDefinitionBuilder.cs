using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Custom.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Custom.Builder;

public interface ICustomDefinitionBuilder<TOwnership, TNecessity, TInNecessity> : IFileDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    ICustomDefinitionBuilder<TOwnership, TNecessity, TInNecessity> WithKey(FileDefinitionKey key);
    ICustomDefinitionBuilder<TOwnership, TNecessity, TInNecessity> WithName(string name);

    ICustomDefinitionBuilder<ExternalDefinition, TNecessity, TInNecessity> External();
    ICustomDefinitionBuilder<StrictDefinition, TNecessity, TInNecessity> Strict();
    ICustomDefinitionBuilder<TOwnership, RequiredDefinition, TInNecessity> Required();
    ICustomDefinitionBuilder<TOwnership, OptionalDefinition, TInNecessity> Optional();

    TDefinition Build<TPlacement, TDefinition>(in IFileContext context, ICustomDefinition<TOwnership, TPlacement, TDefinition> definition)
        where TPlacement : DefinitionPlacement
        where TDefinition : ICustomDefinition<TOwnership, TPlacement, TDefinition>;
    ICustomDefinitionDescriptor<TOwnership, TPlacement, TDefinition> BuildDescriptor<TPlacement, TDefinition>(ICustomDefinition<TOwnership, TPlacement, TDefinition> definition)
        where TPlacement : DefinitionPlacement
        where TDefinition : ICustomDefinition<TOwnership, TPlacement, TDefinition>;
}
