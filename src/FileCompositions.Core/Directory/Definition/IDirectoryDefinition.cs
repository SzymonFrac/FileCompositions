using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Definition;

public interface IDirectoryDefinition<TOwnership, TNecessity> : IDirectoryInterface<TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    internal IDirectoryContext Context { get; }

    DirectoryDefinitionKey Key { get; }
}
