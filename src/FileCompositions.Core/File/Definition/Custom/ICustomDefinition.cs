using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Custom.Init;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Interface.Custom;
using FileCompositions.Core.File.Operator.Specialized.Custom;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.Storage.Resource.Name;

namespace FileCompositions.Core.File.Definition.Custom;

public interface ICustomDefinition<TOwnership, TPlacement, TDefinition> : IFileDefinition<TOwnership, TPlacement>,
    ICustomInterface<TOwnership, TPlacement>,
    ICustomDefinitionInit<TOwnership, TPlacement>,
    ICustomOperator<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : ICustomDefinition<TOwnership, TPlacement, TDefinition>;

public interface ICustomDefinitionFactory<TOwnership, TPlacement, TDefinition>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
    where TDefinition : ICustomDefinition<TOwnership, TPlacement, TDefinition>
{
    TDefinition Create(in IFileContext context, FileDefinitionKey key, StorageResourceName name);
}

public interface ICustomDefinitionFactory
{
    abstract static TDefinition Create<TOwnership, TPlacement, TDefinition>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : ICustomDefinition<TOwnership, TPlacement, TDefinition>;
}
