using FileCompositions.Core.FileSystem;

namespace FileCompositions.Core.ResourceSchema.FileSystem.Registrar;

public interface IResourceSchemaFileSystemRegistrar
{
    IResourceSchemaFileSystemRegistrar Register<TFileSystem>()
        where TFileSystem : class, IFileSystem;
}
