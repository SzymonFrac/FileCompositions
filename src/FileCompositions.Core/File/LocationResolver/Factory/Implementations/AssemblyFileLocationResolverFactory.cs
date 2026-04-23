using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.LocationResolver.Implementations;
using FileCompositions.Core.File.Resource;
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
        var definitions = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.Namespace!.StartsWith(_fileDefinitionNamespace))
            .Where(t => typeof(IFileDefinition).IsAssignableFrom(t))
            .ToImmutableDictionary(
                t => (StorageResourceExtension)
                    t.GetProperty("Extension", BindingFlags.Public | BindingFlags.Static)!
                        .GetValue(null)!
                ,
                t =>
                    (Func<IDirectoryLocation, StorageResourceName, IFileResource>)
                        ((directory, name) => (IFileResource)
                            t.GetMethod("Convert", BindingFlags.Public | BindingFlags.Static)!
                                .Invoke(null, [directory, name])!)
            );

        var resolver = new FileLocationResolver(definitions);
        return resolver;
    }
}
