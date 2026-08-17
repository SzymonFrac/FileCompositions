using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

//public static partial class JsonDefinitionBuilderExt
//{
//    extension<TOwnership, TPlacement, TData>(IFileDefinitionBuilder<TOwnership, TPlacement, IJsonOptions<TData>> builder)
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement
//    {
//        internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>> Build(DirectoryDefinitionKey key) =>
//            ((IJsonDefinitionBuilder<TOwnership, TPlacement, TData>)builder).Build(key);
//    }
//}
