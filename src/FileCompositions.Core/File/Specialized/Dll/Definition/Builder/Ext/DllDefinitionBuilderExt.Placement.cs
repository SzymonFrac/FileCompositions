using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;

public static partial class DllDefinitionBuilderExt
{
    extension<TOwnership>(IDllDefinitionBuilder<TOwnership, RequiredInRequired> builder)
        where TOwnership : DefinitionOwnership
    {
        public IDllDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public IDllDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership>(IDllDefinitionBuilder<TOwnership, OptionalInRequired> builder)
        where TOwnership : DefinitionOwnership
    {
        public IDllDefinitionBuilder<TOwnership, OptionalInRequired> Optional() =>
            builder.Create<TOwnership, OptionalInRequired>();
        public IDllDefinitionBuilder<TOwnership, RequiredInRequired> Required() =>
            builder.Create<TOwnership, RequiredInRequired>();
    }

    extension<TOwnership>(IDllDefinitionBuilder<TOwnership, OptionalInOptional> builder)
        where TOwnership : DefinitionOwnership
    {

    }
}
