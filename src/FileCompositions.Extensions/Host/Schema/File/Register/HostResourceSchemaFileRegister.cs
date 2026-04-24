using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.File.Register;

internal delegate void HostResourceSchemaFileRegister(in IServiceCollection services);
