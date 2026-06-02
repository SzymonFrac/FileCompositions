using FileCompositions.Core.ResourceSchema;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema;

internal interface IHostResourceSchema : IResourceSchema
{
    IHostResourceSchema Init(in IServiceCollection services);
};
