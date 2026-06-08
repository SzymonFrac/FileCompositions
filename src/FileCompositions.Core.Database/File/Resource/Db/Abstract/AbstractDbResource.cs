using FileCompositions.Core.Database.File.Definition.Db.Extensions;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.Database.File.Resource.Db.Abstract;

internal abstract class AbstractDbResource(IFileContext context, string name)
    : AbstractFileResource(context, FileSystemResourceName.CreateDb(name)), IDbResource;
