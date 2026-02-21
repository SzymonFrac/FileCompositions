using FileCompositions.Core.FileResource.Builder;
using FileCompositions.Core.FileResource.Specialized.Db.Builder;
using FileCompositions.Core.FileResource.Specialized.Db.Builder.Factory.Implementations;

namespace FileCompositions.Core.FileResource.Specialized.Db.Specialization.Builder.Extensions;

internal static class ToDbFileResourceBuilderSpecializers
{
    private static IDbFileResourceBuilder GetBuilder(IFileResourceBuilder builder) =>
        new DbFileResourceBuilderFactory().Create(builder.Build());

    extension(IFileResourceBuilder builder)
    {
        public IDbFileResourceBuilder ToDb() => GetBuilder(builder);
    }
}
