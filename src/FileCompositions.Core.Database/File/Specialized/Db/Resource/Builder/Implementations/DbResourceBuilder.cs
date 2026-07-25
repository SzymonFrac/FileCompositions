using FileCompositions.Core.Database.File.Specialized.Db.Resource.Implementations;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder.Abstract;

namespace FileCompositions.Core.Database.File.Specialized.Db.Resource.Builder.Implementations;

internal sealed class DbResourceBuilder : AbstractFileResourceBuilder, IDbResourceBuilder
{
    public IDbResourceBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public IDbResource Build(in IFileContext context)
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var db = new DbResource(context, Name);
        return db;
    }
}
