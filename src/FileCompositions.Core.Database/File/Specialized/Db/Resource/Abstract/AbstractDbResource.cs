using FileCompositions.Core.Database.File.Specialized.Db.Name.Ext;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Name;
using FileCompositions.Core.File.Resource.Abstract;

namespace FileCompositions.Core.Database.File.Specialized.Db.Resource.Abstract;

internal abstract class AbstractDbResource(IFileContext context, string name)
    : AbstractFileResource(context, FileName.CreateDb(name)), IDbResource;
