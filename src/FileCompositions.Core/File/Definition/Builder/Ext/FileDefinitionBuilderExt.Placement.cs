using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Builder.Ext;

//public static partial class FileDefinitionBuilderExt
//{
//    extension<TOwnership, TOptions>(IFileDefinitionBuilder<TOwnership, RequiredInRequired, TOptions> builder)
//        where TOwnership : DefinitionOwnership
//        where TOptions : IFileOptions<TOptions>
//    {
//        public IFileDefinitionBuilder<TOwnership, OptionalInRequired, TOptions> Optional() =>
//            builder.Create<TOwnership, OptionalInRequired>();
//        public IFileDefinitionBuilder<TOwnership, RequiredInRequired, TOptions> Required() =>
//            builder.Create<TOwnership, RequiredInRequired>();
//    }

//    extension<TOwnership, TOptions>(IFileDefinitionBuilder<TOwnership, OptionalInRequired, TOptions> builder)
//        where TOwnership : DefinitionOwnership
//        where TOptions : IFileOptions<TOptions>
//    {
//        public IFileDefinitionBuilder<TOwnership, OptionalInRequired, TOptions> Optional() =>
//            builder.Create<TOwnership, OptionalInRequired>();
//        public IFileDefinitionBuilder<TOwnership, RequiredInRequired, TOptions> Required() =>
//            builder.Create<TOwnership, RequiredInRequired>();
//    }

//    extension<TOwnership, TOptions>(IFileDefinitionBuilder<TOwnership, OptionalInOptional, TOptions> builder)
//        where TOwnership : DefinitionOwnership
//        where TOptions : IFileOptions<TOptions>
//    {

//    }


//    extension<TOptions>(IFileDefinitionBuilder<StrictDefinition, RequiredInRequired, TOptions> builder)
//        where TOptions : IFileOptions<TOptions>
//    {
//        public IFileDefinitionBuilder<StrictDefinition, OptionalInRequired> Optional() =>
//            builder.Create<StrictDefinition, OptionalInRequired>();
//        public IFileDefinitionBuilder<StrictDefinition, RequiredInRequired> Required() =>
//            builder.Create<StrictDefinition, RequiredInRequired>();
//    }

//    extension(INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> builder)
//    {
//        public INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> Optional() =>
//            builder.Create<ExternalDefinition, OptionalInRequired>();
//        public INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> Required() =>
//            builder.Create<ExternalDefinition, RequiredInRequired>();
//    }

//    extension(INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> builder)
//    {
//        public INoFileDefinitionBuilder<StrictDefinition, OptionalInRequired> Optional() =>
//            builder.Create<StrictDefinition, OptionalInRequired>();
//        public INoFileDefinitionBuilder<StrictDefinition, RequiredInRequired> Required() =>
//            builder.Create<StrictDefinition, RequiredInRequired>();
//    }

//    extension(INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> builder)
//    {
//        public INoFileDefinitionBuilder<ExternalDefinition, OptionalInRequired> Optional() =>
//            builder.Create<ExternalDefinition, OptionalInRequired>();
//        public INoFileDefinitionBuilder<ExternalDefinition, RequiredInRequired> Required() =>
//            builder.Create<ExternalDefinition, RequiredInRequired>();
//    }

//    extension<TOwnership>(INoFileDefinitionBuilder<TOwnership, OptionalInOptional> builder)
//        where TOwnership : DefinitionOwnership
//    {

//    }
//}
