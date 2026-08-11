using FileCompositions.Core.File.Definition.Builder.Factory.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Ext;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Config;
using FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Registrar;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension(IHostResourceSchemaFileRegistrar<RequiredDefinition> registrar)
    {
        public IHostResourceSchemaFileRegistrar<RequiredDefinition> Define<TOwnership, TDbContext>(DbDefinitionConfig<TOwnership, RequiredDefinition, RequiredDefinition, TDbContext> config)
            where TOwnership : DefinitionOwnership
            where TDbContext : DbContext
        {
            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var db = config(factory);
            var request = db.BuildInRequired(registrar.DirectoryKey);

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Define(request, registerBuilderFactory);
            return registrar;
        }

        public IHostResourceSchemaFileRegistrar<RequiredDefinition> Define<TOwnership, TDbContext>(DbDefinitionConfig<TOwnership, OptionalDefinition, RequiredDefinition, TDbContext> config)
            where TOwnership : DefinitionOwnership
            where TDbContext : DbContext
        {
            var factory = new FileDefinitionBuilderFactory<RequiredDefinition>();
            var db = config(factory);
            var request = db.BuildInRequired(registrar.DirectoryKey);

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Define(request, registerBuilderFactory);
            return registrar;
        }
    };

    extension(IHostResourceSchemaFileRegistrar<OptionalDefinition> registrar)
    {
        public IHostResourceSchemaFileRegistrar<OptionalDefinition> Define<TOwnership, TDbContext>(DbDefinitionConfig<TOwnership, OptionalDefinition, OptionalDefinition, TDbContext> config)
            where TOwnership : DefinitionOwnership
            where TDbContext : DbContext
        {
            var factory = new FileDefinitionBuilderFactory<OptionalDefinition>();
            var db = config(factory);
            var request = db.BuildInOptional(registrar.DirectoryKey);

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Define(request, registerBuilderFactory);
            return registrar;
        }
    };
}
