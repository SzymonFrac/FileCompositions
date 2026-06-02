using FileCompositions.Core.Database.File.Resource.Db.Abstract;
using FileCompositions.Core.File.Context;

namespace FileCompositions.Core.Database.File.Resource.Db.Implementations;

internal sealed class DbResource(IFileContext context, string name) : AbstractDbResource(context, name);
