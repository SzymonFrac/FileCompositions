using FileCompositions.Core.FileResource.Builder;
using FileCompositions.Core.FileResource.Specialized.Json.Builder;
using FileCompositions.Core.FileResource.Specialized.Json.Specialization.Context;

namespace FileCompositions.Core.FileResource.Specialized.Json.Specialization.Builder.Extensions;

internal static class ToDbFileResourceBuilderSpecializers
{
    private static IJsonFileResourceBuilder<TData> GetBuilder<TData>(IFileResourceBuilder builder, JsonFileResourceSpecializationContext context) =>
        context.CreateBuilder<TData>(builder.Build());

    extension(IFileResourceBuilder builder)
    {
        public IJsonFileResourceBuilder<TData> ToJson<TData>(JsonFileResourceSpecializationContext context) => GetBuilder<TData>(builder, context);
        public IJsonFileResourceBuilder<TData> ToJsonDefault<TData>() => GetBuilder<TData>(builder, JsonFileResourceSpecializationContext.Default);
        public IJsonFileResourceBuilder<TData> ToJsonIndented<TData>() => GetBuilder<TData>(builder, JsonFileResourceSpecializationContext.Indented);
    }
}
