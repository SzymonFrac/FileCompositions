using FileCompositions.Core.Directory.Location;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.LocationResolver.Implementations;
using System.Collections.Immutable;
using System.Reflection;
using FileCompositions.Core.File.Resource;
using FileCompositions.Core.Storage.Resource.Name;
using FileCompositions.Core.Storage.Resource.Extension;

namespace FileCompositions.Core.File.LocationResolver.Factory.Implementations;

internal class AssemblyFileLocationResolverFactory : IFileLocationResolverFactory
{
    public IFileLocationResolver Create()
    {
        var definitions = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IFileDefinition).IsAssignableFrom(t))
            .Where(t => t.IsClass)
            .ToImmutableDictionary(
                t => (StorageResourceExtension)
                    t.GetProperty("Extension")!.GetValue(null)!
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
