using FileCompositions.Core.File.Resource.Specialized.Json;

namespace FileCompositions.Core.Validation.Handler.Ensure.Json.Builder;

public interface IEnsureJsonResourceValidationHandlerBuilder<TData>
{
    public IEnsureJsonResourceValidationHandlerBuilder<TData> OnOk(Func<IJsonFileResource<TData>, Task> ok);
    public IEnsureJsonResourceValidationHandlerBuilder<TData> OnFail(Func<IJsonFileResource<TData>, Task> fail);
    public IEnsureJsonResourceValidationHandlerBuilder<TData> DefaultOnFail(TData @default);
    public EnsureJsonResourceValidationHandler<TData> Build();
}
