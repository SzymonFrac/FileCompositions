using FileCompositions.Core.ResourceSchema;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema;

internal interface IHostResourceSchema : IResourceSchema
{
    IHostResourceSchema Init(ref IServiceCollection services);
};
