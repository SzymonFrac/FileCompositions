using FileCompositions.Core.File.Specialized.Dll.Definition.Descriptor;
using FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Init.Policy.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Config.Implementations;

internal class DllConfig : IDllConfig
{
    private string? name;

    public IDllConfig WithName(string n)
    {
        name = n;
        return this;
    }

    public DllDefinitionDescriptor<TOwnership, TPlacement> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        if (name is null)
            throw new NullReferenceException("File must have a name.");

        return (key, context) => new DllDefinition<TOwnership, TPlacement>(context, key, name)
        {
            InitPolicy = new DefaultDllInitPolicy<TOwnership, TPlacement>()
        };
    }
            
}
