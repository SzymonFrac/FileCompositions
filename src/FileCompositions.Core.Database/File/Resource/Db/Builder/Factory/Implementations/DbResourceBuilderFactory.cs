using FileCompositions.Core.Database.File.Resource.Db.Builder.Implementations;

namespace FileCompositions.Core.Database.File.Resource.Db.Builder.Factory.Implementations;

internal sealed class DbResourceBuilderFactory : IDbResourceBuilderFactory
{
    public static DbResourceBuilderFactory Default { get; } = new();

    public IDbResourceBuilder CreateDefault() => new DbResourceBuilder();
}
