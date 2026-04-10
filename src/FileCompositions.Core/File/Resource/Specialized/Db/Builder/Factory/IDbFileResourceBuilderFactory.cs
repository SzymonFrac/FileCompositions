using FileCompositions.Core.File.Resource;
using FileCompositions.Core.File.Resource.Specialized.Db.Builder;

namespace FileCompositions.Core.File.Resource.Specialized.Db.Builder.Factory;

internal interface IDbFileResourceBuilderFactory
{
    IDbFileResourceBuilder Create(IFileResource baseFile);
}
