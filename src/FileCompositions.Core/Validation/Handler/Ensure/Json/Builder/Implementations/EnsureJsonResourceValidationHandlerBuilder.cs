using FileCompositions.Core.File.Resource.Specialized.Json;
using System.Diagnostics;

namespace FileCompositions.Core.Validation.Handler.Ensure.Json.Builder.Implementations;

internal class EnsureJsonResourceValidationHandlerBuilder<TData> : IEnsureJsonResourceValidationHandlerBuilder<TData>
{
    private Func<IJsonResource<TData>, Task>? ok;
    private Func<IJsonResource<TData>, Task>? fail;

    public IEnsureJsonResourceValidationHandlerBuilder<TData> OnOk(Func<IJsonResource<TData>, Task> k)
    {
        ok = k;
        return this;
    }
    public IEnsureJsonResourceValidationHandlerBuilder<TData> OnFail(Func<IJsonResource<TData>, Task> f)
    {
        fail = f;
        return this;
    }
    public IEnsureJsonResourceValidationHandlerBuilder<TData> DefaultOnFail(TData @default)
    {
        fail = async (fileResource) => await fileResource.Write(@default).ConfigureAwait(false);
        return this;
    }

    public EnsureJsonResourceValidationHandler<TData> Build() => new(ok, fail);
}
