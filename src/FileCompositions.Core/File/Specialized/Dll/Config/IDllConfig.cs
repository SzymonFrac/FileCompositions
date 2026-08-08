using FileCompositions.Core.File.Specialized.Dll.Definition.Descriptor;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Config;

public interface IDllConfig
{
    IDllConfig WithName(string name);

    internal DllDefinitionDescriptor<TOwnership, TPlacement> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement;
}
