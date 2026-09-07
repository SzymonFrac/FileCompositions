using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Specialized.Json.Quality;
using FileCompositions.Core.File.Specialized.Json.Resource;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Json.Definition;

public interface IJsonDefinition<TOwnership, TPlacement, TData> : IFileDefinition<TOwnership, TPlacement>,
    IJsonQuality<TOwnership, TPlacement, TData>
        where TOwnership : Ownership
        where TPlacement : Placement
{
    TData? Default { get; }
}

internal interface IJsonDefinition : IFileDefinition
{
    abstract static IJsonResource<TData> Convert<TData>(in IFileContext context, string name);
}
