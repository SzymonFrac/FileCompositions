using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Descriptor;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Definition.Builder;

public interface IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TFileSystem : class, IFileSystem
{
    IDirectoryDefinitionBuilder<TOwnership, TNecessity, TFileSystem> WithKey(DirectoryDefinitionKey key);

    IDirectoryDefinitionBuilder<ExternalDefinition, TNecessity, TFileSystem> External();
    IDirectoryDefinitionBuilder<StrictDefinition, TNecessity, TFileSystem> Strict();
    IDirectoryDefinitionBuilder<TOwnership, RequiredDefinition, TFileSystem> Required();
    IDirectoryDefinitionBuilder<TOwnership, OptionalDefinition, TFileSystem> Optional();

    internal IDirectoryDefinition<TOwnership, TNecessity> Build(in IDirectoryContext context);
    internal IDirectoryDefinitionDescriptor<TOwnership, TNecessity, TFileSystem> BuildDescriptor();
}
