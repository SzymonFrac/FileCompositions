using FileCompositions.Core.File.Resource.Specialized.Json;
using FileCompositions.Core.Validation.Handler.Ensure.Json.Builder;
using FileCompositions.Core.Validation.Handler.Ensure.Json.Builder.Implementations;
using FileCompositions.Core.Validation.Specialized.Builder;
using FileCompositions.Core.Validation.Specialized.Json.Builder;

namespace FileCompositions.Core.Validation.Specialized.Implementations.Ensure.Extensions;

public static class EnsureResourceBuilderExtensions
{
    extension<TBuilder>(TBuilder builder)
        where TBuilder : ISpecializedResourceValidationBuilder
    {
        public TBuilder Ensure()
        {
            builder.With(EnsureResource.Validate);
            return builder;
        }
    }
    
    extension<TData>(IJsonResourceValidationBuilder<TData> builder)
    {
        public IJsonResourceValidationBuilder<TData> Ensure(Action<IEnsureJsonResourceValidationHandlerBuilder<TData>> config)
        {
            var handlerBuilder = new EnsureJsonResourceValidationHandlerBuilder<TData>();
            config(handlerBuilder);
            var handler = handlerBuilder.Build();

            var validation = async (IJsonResource<TData> fileResource) =>
            {
                var result = await EnsureResource.Validate(fileResource);
                if (result)
                    await handler.Ok(fileResource);
                else
                    await handler.Fail(fileResource);
            };

            builder.With(validation);
            return builder;
        }
    }
}
