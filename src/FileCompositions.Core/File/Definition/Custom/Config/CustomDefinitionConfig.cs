using FileCompositions.Core.File.Definition.Custom.Builder.Factory;
using FileCompositions.Core.File.Definition.Custom.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Custom.Config;

public delegate ICustomDefinitionDescriptor<TOwnership, TPlacement, TDefinition> CustomDefinitionConfig<TOwnership, TPlacement, TInNecessity, TDefinition>(ICustomDefinitionBuilderFactory<TInNecessity> config)
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TInNecessity : DefinitionNecessity
    where TDefinition : ICustomDefinition<TOwnership, TPlacement, TDefinition>;
