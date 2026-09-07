using FileCompositions.Core.File.No.Definition.Builder.Implementations;
using FileCompositions.Core.Quality;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Config;
using FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Factory.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Registrar;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Ext;

public static partial class DbDefinitionExt
{
    extension(IHostResourceSchemaFileRegistrar<Necessity.Required> registrar)
    {
        public IHostResourceSchemaFileRegistrar<Necessity.Required> DefineInRequired<TOwnership, TPlacement, TDbContext>(DbDefinitionConfig<TOwnership, TPlacement, Placement.RequiredInRequired, TDbContext> config)
            where TOwnership : Ownership
            where TPlacement : Placement
            where TDbContext : DbContext
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.RequiredInRequired>();
            var db = config(noBuilder);
            var request = db.Build(registrar.DirectoryKey);

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Define(request, registerBuilderFactory);
            return registrar;
        }
    }

    extension(IHostResourceSchemaFileRegistrar<Necessity.Optional> registrar)
    {
        public IHostResourceSchemaFileRegistrar<Necessity.Optional> DefineInOptional<TOwnership, TPlacement, TDbContext>(DbDefinitionConfig<TOwnership, TPlacement, Placement.OptionalInOptional, TDbContext> config)
            where TOwnership : Ownership
            where TPlacement : Placement
            where TDbContext : DbContext
        {
            var noBuilder = new NoFileDefinitionBuilder<Ownership.Internal, Placement.OptionalInOptional>();
            var db = config(noBuilder);
            var request = db.Build(registrar.DirectoryKey);

            var registerBuilderFactory = new HostResourceSchemaDbRegisterBuilderFactory<TDbContext>();

            registrar.Define(request, registerBuilderFactory);
            return registrar;
        }
    }
}
