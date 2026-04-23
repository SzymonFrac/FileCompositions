using FileCompositions.Core.File.Resource.Specialized.Json;

namespace FileCompositions.Core.Validation.Handler.Ensure.Json;

public class EnsureJsonResourceValidationHandler<TData>(Func<IJsonResource<TData>, Task>? ok, Func<IJsonResource<TData>, Task>? fail)
{
    private readonly Func<IJsonResource<TData>, Task>? _ok = ok;
    private readonly Func<IJsonResource<TData>, Task>? _fail = fail;

    public async Task Ok(IJsonResource<TData> fileResource)
    {
        if (_ok is not null)
            await _ok(fileResource);
    }
    public async Task Fail(IJsonResource<TData> fileResource)
    {
        if (_fail is not null)
            await _fail(fileResource);
    }
}
