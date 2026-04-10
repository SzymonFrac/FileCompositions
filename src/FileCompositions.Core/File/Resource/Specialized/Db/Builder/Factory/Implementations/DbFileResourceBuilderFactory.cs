using FileCompositions.Core.File.Resource.Specialized.Db.Builder.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Db.Builder.Factory.Implementations;

internal class DbFileResourceBuilderFactory : IDbFileResourceBuilderFactory
{
    public IDbFileResourceBuilder Create(IFileResource baseFile) =>
        new DbFileResourceBuilder(baseFile);
}
