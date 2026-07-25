using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Extensions;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Factory.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Config;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Descriptor;
using FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Registrar;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Registrar;

public static class HostResourceSchemaFileRegistrarHostDb
{
    extension(IHostResourceSchemaFileRegistrar<RequiredDefinition> registrar)
    {
        public IHostResourceSchemaFileRegistrar<RequiredDefinition> DefineDb<TOwnership, TDbContext>(DbDefinitionConfig<TOwnership, RequiredDefinition, RequiredDefinition, TDbContext> config)
            where TOwnership : DefinitionOwnership
            where TDbContext : DbContext
        {
            var builder = new DbDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Store<TOwnership, RequiredInRequired, IDbDefinition<TOwnership, RequiredInRequired, TDbContext>, IDbDefinitionDescriptor<TOwnership, RequiredInRequired, TDbContext>>(descriptor, registerBuilderFactory);
            return registrar;
        }

        public IHostResourceSchemaFileRegistrar<RequiredDefinition> DefineDb<TOwnership, TDbContext>(DbDefinitionConfig<TOwnership, OptionalDefinition, RequiredDefinition, TDbContext> config)
            where TOwnership : DefinitionOwnership
            where TDbContext : DbContext
        {
            var builder = new DbDefinitionBuilderFactory<RequiredDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInRequired();

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Store<TOwnership, OptionalInRequired, IDbDefinition<TOwnership, OptionalInRequired, TDbContext>, IDbDefinitionDescriptor<TOwnership, OptionalInRequired, TDbContext>>(descriptor, registerBuilderFactory);
            return registrar;
        }
    };

    extension(IHostResourceSchemaFileRegistrar<OptionalDefinition> registrar)
    {
        public IHostResourceSchemaFileRegistrar<OptionalDefinition> DefineDb<TOwnership, TDbContext>(DbDefinitionConfig<TOwnership, OptionalDefinition, OptionalDefinition, TDbContext> config)
            where TOwnership : DefinitionOwnership
            where TDbContext : DbContext
        {
            var builder = new DbDefinitionBuilderFactory<OptionalDefinition>(registrar.DirectoryKey);
            var jsonBuilder = config(builder);
            var descriptor = jsonBuilder.BuildDescriptorInOptional();

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Store<TOwnership, OptionalInOptional, IDbDefinition<TOwnership, OptionalInOptional, TDbContext>, IDbDefinitionDescriptor<TOwnership, OptionalInOptional, TDbContext>>(descriptor, registerBuilderFactory);
            return registrar;
        }
    };
}
