using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Registrar.Implementations;

namespace FileCompositions.Hosting.ResourceSchema.File.Registrar.Factory.Implementations;

internal sealed class HostResourceSchemaFileRegistrarFactory : IHostResourceSchemaFileRegistrarFactory
{
    public IHostResourceSchemaFileRegisterBuilderFactory RegisterBuilderFactory { get; init; } = new HostResourceSchemaFileRegisterBuilderFactory();

    public IHostResourceSchemaFileRegistrar<TNecessity> Create<TOwnership, TNecessity>(DirectoryDefinitionKey key)
        where TOwnership : Ownership
        where TNecessity : Necessity =>
            new HostResourceSchemaFileRegistrar<TOwnership, TNecessity>(key)
            {
                RegisterBuilderFactory = RegisterBuilderFactory
            };
}
