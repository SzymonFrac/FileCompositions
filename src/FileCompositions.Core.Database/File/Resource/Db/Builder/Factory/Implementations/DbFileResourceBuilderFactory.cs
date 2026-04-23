using FileCompositions.Core.Database.File.Resource.Db.Builder.Implementations;

namespace FileCompositions.Core.Database.File.Resource.Db.Builder.Factory.Implementations;

internal class DbFileResourceBuilderFactory : IDbResourceBuilderFactory
{
    public IDbResourceBuilder CreateDefault() => new DbResourceBuilder();
}
