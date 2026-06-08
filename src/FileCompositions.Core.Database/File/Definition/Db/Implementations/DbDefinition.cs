using FileCompositions.Core.Database.File.Definition.Db.Abstract;
using FileCompositions.Core.Database.File.Resource.Db;
using FileCompositions.Core.Database.File.Resource.Db.Builder.Factory.Implementations;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem.Resource.Extension;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Definition.Db.Implementations;

internal sealed class DbDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractDbDefinition<TOwnership, TPlacement>(context, key, name)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;

internal sealed class DbDefinition : IDbDefinition
{
    public static FileSystemResourceExtension Extension { get; } = new(".db");
    private DbDefinition() { }

    public static IDbResource Convert(in IFileContext context, string name) =>
        DbResourceBuilderFactory.Default
            .CreateDefault()
            .WithName(name)
            .Build(context);
}
