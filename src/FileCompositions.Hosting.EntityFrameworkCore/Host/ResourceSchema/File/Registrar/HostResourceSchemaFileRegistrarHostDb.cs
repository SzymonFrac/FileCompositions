using FileCompositions.Core.Database.File.Definition.Db.Builder.Extensions;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Extensions.Host.Schema.File.Registrar;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Builder.Extensions;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Builder.Factory.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Config;
using FileCompositions.Hosting.EntityFrameworkCore.File.Definition.Db.Descriptor;
using FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Factory.Implementations;
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
