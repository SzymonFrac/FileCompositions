using FileCompositions.Core.File.Resource.Builder;
using FileCompositions.Core.File.Resource.Specialized.Db.Builder;
using FileCompositions.Core.File.Resource.Specialized.Db.Builder.Factory.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Db.Specialization.Builder.Extensions;

internal static class ToDbFileResourceBuilderSpecializers
{
    private static IDbFileResourceBuilder GetBuilder(IFileResourceBuilder builder) =>
        new DbFileResourceBuilderFactory().Create(builder.Build());

    extension(IFileResourceBuilder builder)
    {
        public IDbFileResourceBuilder ToDb() => GetBuilder(builder);
    }
}
