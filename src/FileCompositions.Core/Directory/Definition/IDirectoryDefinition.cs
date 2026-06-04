using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Definition.Init;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Directory.Operator;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.Directory.Definition;

public interface IDirectoryDefinition<TOwnership, TNecessity> : IDirectoryInterface<TOwnership, TNecessity>,
    IDirectoryOperator<TOwnership, TNecessity>,
    IDirectoryDefinitionInit<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    internal IDirectoryContext Context { get; }
}
