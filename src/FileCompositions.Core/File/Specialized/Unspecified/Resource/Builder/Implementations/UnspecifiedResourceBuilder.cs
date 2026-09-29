using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder.Abstract;
using FileCompositions.Core.File.Specialized.Unspecified.Resource.Implementations;

namespace FileCompositions.Core.File.Specialized.Unspecified.Resource.Builder.Implementations;

internal sealed class UnspecifiedResourceBuilder : AbstractFileResourceBuilder, IUnspecifiedResourceBuilder
{
    public IUnspecifiedResourceBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public IUnspecifiedResource Build(in IFileContext context)
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var unspecified = new UnspecifiedResource(context, Name);
        return unspecified;
    }
}
