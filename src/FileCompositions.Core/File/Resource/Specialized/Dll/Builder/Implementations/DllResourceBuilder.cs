using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder.Abstract;
using FileCompositions.Core.File.Resource.Specialized.Dll.Implementations;

namespace FileCompositions.Core.File.Resource.Specialized.Dll.Builder.Implementations;

internal sealed class DllResourceBuilder : AbstractFileResourceBuilder, IDllResourceBuilder
{
    public IDllResourceBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public IDllResource Build(in IFileContext context)
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        var dll = new DllResource(context, Name);
        return dll;
    }
}
