using FileCompositions.Core.FileResource.Specialized.Json;

namespace FileCompositions.Core.Validation.Handler.Ensure.Json;

public class EnsureJsonResourceValidationHandler<TData>(Func<IJsonFileResource<TData>, Task>? ok, Func<IJsonFileResource<TData>, Task>? fail)
{
    private readonly Func<IJsonFileResource<TData>, Task>? _ok = ok;
    private readonly Func<IJsonFileResource<TData>, Task>? _fail = fail;

    public async Task Ok(IJsonFileResource<TData> fileResource)
    {
        if (_ok is not null)
            await _ok(fileResource);
    }
    public async Task Fail(IJsonFileResource<TData> fileResource)
    {
        if (_fail is not null)
            await _fail(fileResource);
    }
}
