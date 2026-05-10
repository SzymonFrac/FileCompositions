using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Register;

internal delegate void HostResourceSchemaRegister(in IServiceCollection services);
