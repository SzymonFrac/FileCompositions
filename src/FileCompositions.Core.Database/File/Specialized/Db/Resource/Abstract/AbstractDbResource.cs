using FileCompositions.Core.Database.File.Specialized.Db.Name.Ext;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.Database.File.Specialized.Db.Resource.Abstract;

internal abstract class AbstractDbResource(IFileContext context, string name)
    : AbstractFileResource(context, Filename.CreateDb(name)), IDbResource;
