using FileCompositions.Core.Database.File.Specialized.Db.Definition;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Abstract;
using FileCompositions.Core.Database.File.Specialized.Db.Resource;
using FileCompositions.Core.Database.File.Specialized.Db.Resource.Builder.Factory.Implementations;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem.Resource.Extension;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;

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
