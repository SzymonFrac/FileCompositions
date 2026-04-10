using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.LocationResolver.Implementations;
using FileCompositions.Core.File.Resource.Specialized;
using FileCompositions.Core.Storage.ResourceName;
using FileCompositions.Core.Storage.ResourceName.Extension;
using System.Collections.Immutable;
using System.Reflection;

namespace FileCompositions.Core.File.LocationResolver.Factory.Implementations;

internal class AssemblyFileLocationResolverFactory : IFileLocationResolverFactory
{
    private readonly string _fileDefinitionNamespace = "FileCompositions.Core.File.Definition";
    public IFileLocationResolver Create()
    {
        var definitionsByExtension = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.Namespace!.StartsWith(_fileDefinitionNamespace))
            .Where(t => typeof(IFileDefinition).IsAssignableFrom(t))
            .ToImmutableDictionary(
                t => (StorageResourceExtension)
                    t.GetProperty("Extension", BindingFlags.Public | BindingFlags.Static)!
                        .GetValue(null)!
                ,
                t =>
                    (Func<IDirectoryLocation, StorageResourceName, ISpecializedFileResource>)
                        ((directory, name) => (ISpecializedFileResource)
                            t.GetMethod("Convert", BindingFlags.Public | BindingFlags.Static)!
                                .Invoke(null, [directory, name])!)
            );

        var resolver = new FileLocationResolver(definitionsByExtension);
        return resolver;
    }
}
