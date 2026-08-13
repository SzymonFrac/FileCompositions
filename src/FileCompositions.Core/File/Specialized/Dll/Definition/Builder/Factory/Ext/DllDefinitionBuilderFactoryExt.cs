using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.File.Specialized.Dll.Options.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Factory.Ext;

public static partial class DllDefinitionBuilderFactoryExt
{
    extension(IFileDefinitionBuilderFactory<RequiredDefinition> factory)
    {
        public IDllDefinitionBuilder<StrictDefinition, RequiredInRequired> Dll(Action<IDllOptions> config)
        {
            var dll = new DllOptions();
            config(dll);

            var builder = new DllDefinitionBuilder<StrictDefinition, RequiredInRequired>(dll);
            return builder;
        }
    }

    extension(IFileDefinitionBuilderFactory<OptionalDefinition> factory)
    {
        public IDllDefinitionBuilder<StrictDefinition, OptionalInOptional> Dll(Action<IDllOptions> config)
        {
            var dll = new DllOptions();
            config(dll);

            var builder = new DllDefinitionBuilder<StrictDefinition, OptionalInOptional>(dll);
            return builder;
        }
    }
}
