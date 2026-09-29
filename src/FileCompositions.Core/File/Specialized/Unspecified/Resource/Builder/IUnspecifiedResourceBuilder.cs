using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Resource.Builder;

namespace FileCompositions.Core.File.Specialized.Unspecified.Resource.Builder;

public interface IUnspecifiedResourceBuilder : IFileResourceBuilder
{
    IUnspecifiedResourceBuilder WithName(string name);

    internal IUnspecifiedResource Build(in IFileContext context);
};
