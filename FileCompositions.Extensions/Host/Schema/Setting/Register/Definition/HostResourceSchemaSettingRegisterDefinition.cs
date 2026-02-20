using FileCompositions.Core.FileResource.Key;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Extensions.Host.Schema.Setting.Register.Definition;

internal delegate void HostResourceSchemaSettingRegisterDefinition(in IServiceCollection services, FileResourceKey key);
