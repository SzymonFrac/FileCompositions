using FileCompositions.Core.FileSystem.Address.Implementations;
using FileCompositions.Core.FileSystem.Specialized.Local.Implementations;
using FileCompositions.Core.Quality;
using static System.Environment;

namespace FileCompositions.Core.Directory.Definition.Builder.Factory.Ext;

public static partial class LocalFileSystemExt
{
    extension(IDirectoryDefinitionBuilderFactory factory)
    {
        public IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, LocalFileSystem> CreateLocal(LocalFileSystemAddress address) =>
            factory.CreateDefault<LocalFileSystem>(address);
        public IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, LocalFileSystem> CreateLocal(params ReadOnlySpan<string> path) =>
            factory.CreateDefault<LocalFileSystem>(LocalFileSystemAddress.Create(path));
        public IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, LocalFileSystem> CreateLocal(SpecialFolder logical) =>
            factory.CreateDefault<LocalFileSystem>(LocalFileSystemAddress.Create(logical));
        public IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, LocalFileSystem> CreateLocal(SpecialFolder logical, params ReadOnlySpan<string> path) =>
            factory.CreateDefault<LocalFileSystem>(LocalFileSystemAddress.Create(logical, path));
    }
}
