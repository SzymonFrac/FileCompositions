using FileCompositions.Core.Directory.Context;
using FileCompositions.Core.Directory.Interface;
using FileCompositions.Core.Quality.Necessity.Implementations;

namespace FileCompositions.Core.Directory.Location;

internal interface IDirectoryLocation : IDirectoryInterface<RequiredDefinition>
{
    IDirectoryContext Context { get; }
}
