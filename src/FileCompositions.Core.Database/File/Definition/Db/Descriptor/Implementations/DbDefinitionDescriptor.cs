using FileCompositions.Core.Database.File.Definition.Db.Implementations;
using FileCompositions.Core.Database.File.Definition.Db.Init.Policy;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Definition.Db.Descriptor.Implementations;

internal sealed class DbDefinitionDescriptor<TOwnership, TPlacement>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
    : AbstractFileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>>(directoryKey, key, name),
    IDbDefinitionDescriptor<TOwnership, TPlacement>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
{
    public required IDbDefinitionInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

    public override IDbDefinition<TOwnership, TPlacement> Activate(in IFileContext context) =>
        new DbDefinition<TOwnership, TPlacement>(context, Key, Name)
        {
            InitPolicy = InitPolicy
        };
}
