using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Ext;

//public static partial class DllDefinitionBuilderExt
//{
//    extension<TOwnership, TPlacement>(IFileDefinitionBuilder<TOwnership, TPlacement, IDllOptions> builder)
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement
//    {
//        internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey key) =>
//            ((IDllDefinitionBuilder<TOwnership, TPlacement>)builder).Build(key);
//    }
//}
