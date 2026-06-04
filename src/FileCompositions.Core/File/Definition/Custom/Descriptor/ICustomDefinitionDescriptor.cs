using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Custom.Descriptor;

public interface ICustomDefinitionDescriptor<TOwnership, TPlacement, TDefinition> : IFileDefinitionDescriptor<TOwnership, TPlacement, TDefinition>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDefinition : ICustomDefinition<TOwnership, TPlacement, TDefinition>;
