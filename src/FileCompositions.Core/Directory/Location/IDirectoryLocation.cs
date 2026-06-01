using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Directory.Operator;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Directory.Location;

internal interface IDirectoryLocation : IDirectoryInterface<ExternalDefinition, RequiredDefinition>,
    IDirectoryOperator<ExternalDefinition, RequiredDefinition>
{
    IDirectoryContext Context { get; }
}
