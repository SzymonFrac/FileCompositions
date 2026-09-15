using FileCompositions.Core.Directory.Definition.Builder;
using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.FileSystem.Local.Addressing.Common;
using FileCompositions.Core.Quality;
using static System.Environment;

namespace FileCompositions.Core.FileSystem.Local.Ext;

public static partial class LocalFileSystemExt
{
    extension(IDirectoryDefinitionBuilderFactory factory)
    {
        public IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, LocalFileSystem> CreateLocal(LocalAddress address) =>
            factory.CreateDefault<LocalFileSystem>(address);
        public IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, LocalFileSystem> CreateLocal(params ReadOnlySpan<string> path) =>
            factory.CreateDefault<LocalFileSystem>(LocalAddress.Create(path));
        public IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, LocalFileSystem> CreateLocal(SpecialFolder logical) =>
            factory.CreateDefault<LocalFileSystem>(LocalAddress.Create(logical));
        public IDirectoryDefinitionBuilder<Ownership.Internal, Necessity.Required, LocalFileSystem> CreateLocal(SpecialFolder logical, params ReadOnlySpan<string> path) =>
            factory.CreateDefault<LocalFileSystem>(LocalAddress.Create(logical, path));
    }
}
