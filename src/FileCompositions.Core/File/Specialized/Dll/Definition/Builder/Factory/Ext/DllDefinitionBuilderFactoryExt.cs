using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.File.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Config;
using FileCompositions.Core.File.Specialized.Dll.Config.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Factory.Ext;

public static partial class DllDefinitionBuilderFactoryExt
{
    extension(IFileDefinitionBuilderFactory<RequiredDefinition> factory)
    {
        public DllDefinitionBuilder<StrictDefinition, RequiredDefinition> Dll(Action<IDllConfig> config)
        {
            var dll = new DllConfig();
            config(dll);

            var builder = new DllDefinitionBuilder<StrictDefinition, RequiredDefinition>(dll);
            return builder;
        }
    }

    extension(IFileDefinitionBuilderFactory<OptionalDefinition> factory)
    {
        public DllDefinitionBuilder<StrictDefinition, OptionalDefinition> Dll(Action<IDllConfig> config)
        {
            var dll = new DllConfig();
            config(dll);

            var builder = new DllDefinitionBuilder<StrictDefinition, OptionalDefinition>(dll);
            return builder;
        }
    }
}
