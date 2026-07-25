using FileCompositions.Core.Database.File.Specialized.Db.Resource.Builder.Implementations;

namespace FileCompositions.Core.Database.File.Specialized.Db.Resource.Builder.Factory.Implementations;

internal sealed class DbResourceBuilderFactory : IDbResourceBuilderFactory
{
    public static DbResourceBuilderFactory Default { get; } = new();

    public IDbResourceBuilder CreateDefault() => new DbResourceBuilder();
}
