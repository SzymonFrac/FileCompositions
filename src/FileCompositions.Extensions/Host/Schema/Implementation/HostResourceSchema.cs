using FileCompositions.Extensions.Host.Schema.Register;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace FileCompositions.Extensions.Host.Schema.Implementation;

internal class HostResourceSchema(HostResourceSchemaRegister? register) : IHostResourceSchema
{
    private readonly HostResourceSchemaRegister? _register = register;
    public IHostResourceSchema Init(in IServiceCollection services)
    {
        Debug.WriteLine(_register?.GetInvocationList().Length);
        _register?.Invoke(in services);
        return this;
    }
}
