using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;

//public static partial class DbDefinitionBuilderExt
//{
//    extension<TOwnership, TPlacement, TDbContext>(IFileDefinitionBuilder<TOwnership, TPlacement, IDbOptions<TDbContext>> builder)
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement
//        where TDbContext : DbContext
//    {
//        internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>> Build(DirectoryDefinitionKey key) =>
//            ((IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>)builder).Build(key);
//    }
//}
