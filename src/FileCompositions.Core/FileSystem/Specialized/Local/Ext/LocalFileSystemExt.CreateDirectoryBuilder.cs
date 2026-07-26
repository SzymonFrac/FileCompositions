using FileCompositions.Core.Directory.Definition.Builder;
using FileCompositions.Core.Directory.Definition.Builder.Factory;
using FileCompositions.Core.FileSystem.Address.Implementations;
using FileCompositions.Core.FileSystem.Specialized.Local.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;
using static System.Environment;

namespace FileCompositions.Core.FileSystem.Specialized.Local.Ext;

public static partial class LocalFileSystemExt
{
    extension(IDirectoryDefinitionBuilderFactory factory)
    {
        public IDirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition, LocalFileSystem> CreateLocal(LocalFileSystemAddress address) =>
            factory.CreateDefault<LocalFileSystem>(address);
        public IDirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition, LocalFileSystem> CreateLocal(params ReadOnlySpan<string> path) =>
            factory.CreateDefault<LocalFileSystem>(LocalFileSystemAddress.Create(path));
        public IDirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition, LocalFileSystem> CreateLocal(SpecialFolder logical) =>
            factory.CreateDefault<LocalFileSystem>(LocalFileSystemAddress.Create(logical));
        public IDirectoryDefinitionBuilder<StrictDefinition, RequiredDefinition, LocalFileSystem> CreateLocal(SpecialFolder logical, params ReadOnlySpan<string> path) =>
            factory.CreateDefault<LocalFileSystem>(LocalFileSystemAddress.Create(logical, path));
    }
}
