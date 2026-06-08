using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.Register;

internal delegate void HostResourceSchemaRegister(in IServiceCollection services);
