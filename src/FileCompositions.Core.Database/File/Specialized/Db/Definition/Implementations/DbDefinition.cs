using FileCompositions.Core.Database.File.Specialized.Db.Definition.Abstract;
using FileCompositions.Core.Database.File.Specialized.Db.Extension;
using FileCompositions.Core.Database.File.Specialized.Db.Resource;
using FileCompositions.Core.Database.File.Specialized.Db.Resource.Builder.Factory.Implementations;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Extension.Some;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;

internal sealed class DbDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name)
    : AbstractDbDefinition<TOwnership, TPlacement>(context, key, name)
        where TOwnership : Ownership
        where TPlacement : Placement;

internal sealed class DbDefinition : IDbDefinition
{
    public static SomeFileExtension Extension { get; } = new DbExtension();
    private DbDefinition() { }

    public static IDbResource Convert(in IFileContext context, string name) =>
        DbResourceBuilderFactory.Default
            .CreateDefault()
            .WithName(name)
            .Build(context);
}
