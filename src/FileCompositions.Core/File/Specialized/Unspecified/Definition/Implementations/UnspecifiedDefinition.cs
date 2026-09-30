using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Unspecified.Definition.Abstract;
using FileCompositions.Core.File.Specialized.Unspecified.Resource;
using FileCompositions.Core.File.Specialized.Unspecified.Resource.Builder.Factory.Implementations;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Implementations;

internal sealed class UnspecifiedDefinition<TOwnership, TPlacement>(IFileContext context, FileDefinitionKey key, string name) :
    AbstractUnspecifiedDefinition<TOwnership, TPlacement>(context, key, name)
        where TOwnership : Ownership
        where TPlacement : Placement;

internal sealed class UnspecifiedDefinition : IUnspecifiedDefinition
{
    private UnspecifiedDefinition() { }

    public static IUnspecifiedResource Convert(in IFileContext context, string name) =>
        UnspecifiedResourceBuilderFactory.Default
            .CreateDefault()
            .WithName(name)
            .Build(context);
}
