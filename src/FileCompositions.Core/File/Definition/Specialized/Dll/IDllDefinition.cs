using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Specialized.Dll.Init;
using FileCompositions.Core.File.Interface.Specialized.Dll;
using FileCompositions.Core.File.Operator.Specialized.Dll;
using FileCompositions.Core.File.Resource.Specialized.Dll;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Dll;

public interface IDllDefinition<TOwnership, TPlacement> : IFileDefinition<TOwnership, TPlacement>,
    IDllInterface<TOwnership, TPlacement>,
    IDllDefinitionInit<TOwnership, TPlacement>,
    IDllOperator<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal interface IDllDefinition : IFileDefinition
{
    abstract static IDllResource Convert(in IFileContext context, string name);
}