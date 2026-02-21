using FileCompositions.Core.FileResource.Specialized.Db.Builder.Implementations;

namespace FileCompositions.Core.FileResource.Specialized.Db.Builder.Factory.Implementations;

internal class DbFileResourceBuilderFactory : IDbFileResourceBuilderFactory
{
    public IDbFileResourceBuilder Create(IFileResource baseFile) =>
        new DbFileResourceBuilder(baseFile);
}
