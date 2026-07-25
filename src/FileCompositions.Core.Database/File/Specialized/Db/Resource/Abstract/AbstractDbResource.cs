using FileCompositions.Core.Database.File.Specialized.Db.Definition.Extensions;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Abstract;
using FileCompositions.Core.FileSystem.Resource.Name;

namespace FileCompositions.Core.Database.File.Specialized.Db.Resource.Abstract;

internal abstract class AbstractDbResource(IFileContext context, string name)
    : AbstractFileResource(context, FileSystemResourceName.CreateDb(name)), IDbResource;
