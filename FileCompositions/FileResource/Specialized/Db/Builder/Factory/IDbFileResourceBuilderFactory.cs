namespace FileCompositions.Core.FileResource.Specialized.Db.Builder.Factory;

internal interface IDbFileResourceBuilderFactory
{
    IDbFileResourceBuilder Create(IFileResource baseFile);
}
