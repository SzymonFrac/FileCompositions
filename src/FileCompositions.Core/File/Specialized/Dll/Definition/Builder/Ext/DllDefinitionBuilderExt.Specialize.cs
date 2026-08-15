using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.File.Specialized.Dll.Options.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;

public static partial class DllDefinitionBuilderExt
{
    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, RequiredInRequired, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, RequiredInRequired>
        where TBuilder : IFileDefinitionBuilder<TOwnership, RequiredInRequired, TDefinition, TBuilder>
    {
        public IDllDefinitionBuilder<StrictDefinition, RequiredInRequired> Dll(Action<IDllOptions> config)
        {
            var dll = new DllOptions();
            config(dll);

            return new DllDefinitionBuilder<StrictDefinition, RequiredInRequired>(dll);
        }
    }

    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, OptionalInRequired, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, OptionalInRequired>
        where TBuilder : IFileDefinitionBuilder<TOwnership, OptionalInRequired, TDefinition, TBuilder>
    {
        public IDllDefinitionBuilder<StrictDefinition, OptionalInRequired> Dll(Action<IDllOptions> config)
        {
            var dll = new DllOptions();
            config(dll);

            return new DllDefinitionBuilder<StrictDefinition, OptionalInRequired>(dll);
        }
    }

    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, OptionalInOptional, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, OptionalInOptional>
        where TBuilder : IFileDefinitionBuilder<TOwnership, OptionalInOptional, TDefinition, TBuilder>
    {
        public IDllDefinitionBuilder<StrictDefinition, OptionalInOptional> Dll(Action<IDllOptions> config)
        {
            var dll = new DllOptions();
            config(dll);

            return new DllDefinitionBuilder<StrictDefinition, OptionalInOptional>(dll);
        }
    }
}
