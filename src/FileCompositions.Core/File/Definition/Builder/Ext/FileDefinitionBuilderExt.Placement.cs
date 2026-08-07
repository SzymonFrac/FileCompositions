using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Definition;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.File.Definition.Builder.Ext;

// Can't place yet...

//internal static partial class FileDefinitionBuilderExt
//{
//    extension<TOwnership>(IFileDefinitionBuilder<TOwnership, RequiredDefinition, RequiredDefinition> builder)
//        where TOwnership : DefinitionOwnership
//    {
//        public IFileDefinitionBuilder<TOwnership, RequiredDefinition, RequiredDefinition>.Placement<RequiredInRequired> Place() => new();

//        public FileDefinitionDescriptor<TOwnership, RequiredInRequired, TDefinition> BuildInRequired<TDefinition>()
//            where TDefinition : IFileDefinition<TOwnership, RequiredInRequired> =>
//                builder.Place();//builder.Build<RequiredInRequired>(context);
//    }

//    extension<TOwnership, TData>(IJsonDefinitionBuilder<TOwnership, OptionalDefinition, TData> builder)
//        where TOwnership : DefinitionOwnership
//    {
//        public IJsonDefinition<TOwnership, OptionalInRequired, TData> BuildInRequired(in IFileContext context) =>
//            builder.Build<OptionalInRequired>(context);
//        public IJsonDefinition<TOwnership, OptionalInOptional, TData> BuildInOptional(in IFileContext context) =>
//            builder.Build<OptionalInOptional>(context);

//        public IJsonDefinitionDescriptor<TOwnership, OptionalInRequired, TData> BuildDescriptorInRequired() =>
//            builder.BuildDescriptor<OptionalInRequired>();
//        public IJsonDefinitionDescriptor<TOwnership, OptionalInOptional, TData> BuildDescriptorInOptional() =>
//            builder.BuildDescriptor<OptionalInOptional>();
//    }
//}
