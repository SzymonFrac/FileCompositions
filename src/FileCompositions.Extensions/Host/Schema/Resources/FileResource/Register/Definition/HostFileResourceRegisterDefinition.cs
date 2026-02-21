using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.FileResource.Builder;
using FileCompositions.Core.FileResource.Key;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Definition;

public delegate IHostFileResourceRegister HostFileResourceRegisterDefinition(DirectoryLocationKey directoryKey, FileResourceKey fileKey, Action<IFileResourceBuilder> baseConfig);
