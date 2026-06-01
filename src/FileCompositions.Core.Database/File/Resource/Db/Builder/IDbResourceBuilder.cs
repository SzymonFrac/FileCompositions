using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder;

namespace FileCompositions.Core.Database.File.Resource.Db.Builder;

public interface IDbResourceBuilder : IFileResourceBuilder
{
    IDbResourceBuilder WithName(string name);

    internal IDbResource Build(in IFileContext context);
}
