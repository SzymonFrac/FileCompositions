using FileCompositions.Core.Database.File.Specialized.Db.Resource.Builder;

namespace FileCompositions.Core.Database.File.Specialized.Db.Resource.Builder.Factory;

internal interface IDbResourceBuilderFactory
{
    IDbResourceBuilder CreateDefault();
}
