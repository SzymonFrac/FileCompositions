using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.ResourceSchema.File.Registrar;
using FileCompositions.Extensions.Host.Schema.File.Register;
using FileCompositions.Extensions.Host.Schema.File.Register.Factory;

namespace FileCompositions.Extensions.Host.Schema.File.Registrar.Implementations;

internal class HostResourceSchemaFileRegistrar(IHostResourceSchemaFileRegisterFactory factory) : IResourceSchemaFileRegistrar
{
    private readonly IHostResourceSchemaFileRegisterFactory _factory = factory;
    private HostResourceSchemaFileRegister? register;
    public IResourceSchemaFileRegistrar Store<TOwnership, TNecessity, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
        where TDefinition : class, IFileDefinition<TOwnership, TNecessity>
        where TDescriptor : IFileDefinitionDescriptor<TDefinition, TOwnership, TNecessity>
    {
        var reg = _factory.Create<TOwnership, TNecessity, TDefinition, TDescriptor>(descriptor);
        register += reg;

        return this;
    }
}
