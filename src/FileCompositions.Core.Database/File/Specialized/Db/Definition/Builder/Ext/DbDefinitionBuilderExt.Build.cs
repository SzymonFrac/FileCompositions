using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;

//public static partial class DbDefinitionBuilderExt
//{
//    extension<TOwnership, TPlacement>(IFileDefinitionBuilder<TOwnership, TPlacement, IDbOptions> builder)
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement
//    {
//        internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey key) =>
//            ((IDbDefinitionBuilder<TOwnership, TPlacement>)builder).Build(key);
//    }
//}
