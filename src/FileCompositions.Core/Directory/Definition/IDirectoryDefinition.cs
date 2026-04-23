using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Definition;

internal interface IDirectoryDefinition<TOwnership, TNecessity> : IDirectoryLocation
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    DirectoryDefinitionKey Key { get; }
}
