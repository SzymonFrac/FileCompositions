using FileCompositions.Core.File.No.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Config;
using FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Registrar;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension(IHostResourceSchemaFileRegistrar<RequiredDefinition> registrar)
    {
        public IHostResourceSchemaFileRegistrar<RequiredDefinition> Define<TOwnership, TDbContext>(DbDefinitionConfig<TOwnership, RequiredInRequired, RequiredInRequired, TDbContext> config)
            where TOwnership : DefinitionOwnership
            where TDbContext : DbContext
        {
            var noBuilder = new NoDefinitionBuilder<StrictDefinition, RequiredInRequired>();
            var db = config(noBuilder);
            var request = db.Build(registrar.DirectoryKey);

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Define(request, registerBuilderFactory);
            return registrar;
        }

        public IHostResourceSchemaFileRegistrar<RequiredDefinition> Define<TOwnership, TDbContext>(DbDefinitionConfig<TOwnership, OptionalInRequired, RequiredInRequired, TDbContext> config)
            where TOwnership : DefinitionOwnership
            where TDbContext : DbContext
        {
            var noBuilder = new NoDefinitionBuilder<StrictDefinition, RequiredInRequired>();
            var db = config(noBuilder);
            var request = db.Build(registrar.DirectoryKey);

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Define(request, registerBuilderFactory);
            return registrar;
        }
    };

    extension(IHostResourceSchemaFileRegistrar<OptionalDefinition> registrar)
    {
        public IHostResourceSchemaFileRegistrar<OptionalDefinition> Define<TOwnership, TDbContext>(DbDefinitionConfig<TOwnership, OptionalInOptional, OptionalInOptional, TDbContext> config)
            where TOwnership : DefinitionOwnership
            where TDbContext : DbContext
        {
            var noBuilder = new NoDefinitionBuilder<StrictDefinition, OptionalInOptional>();
            var db = config(noBuilder);
            var request = db.Build(registrar.DirectoryKey);

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Define(request, registerBuilderFactory);
            return registrar;
        }
    };
}
