using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.File.Context.Factory.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Quality.Ext;
using FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.Initialize.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder;
using FileCompositions.Hosting.ResourceSchema.Initializer;
using FileCompositions.Hosting.ResourceSchema.Register;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Implementations;

internal sealed class HostResourceSchemaDbRegisterBuilder<TInOwnership, TInNecessity, TDbContext> : IHostResourceSchemaFileRegisterBuilder
    where TInOwnership : DefinitionOwnership
    where TInNecessity : DefinitionNecessity
    where TDbContext : DbContext
{
    private readonly FileContextFactory _fileContextFactory = new();

    public HostResourceSchemaRegister Build<TOwnership, TPlacement, TDefinition, TDescriptor>(TDescriptor descriptor)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement>
        where TDescriptor : IFileDefinitionDescriptor<TOwnership, TPlacement, TDefinition> =>
            new((in services) => services
                .AddKeyedSingleton<TDefinition>(descriptor.Key, (sp, key) =>
                {
                    var directory = sp.GetRequiredKeyedService<IDirectoryDefinition<TInOwnership, TInNecessity>>(descriptor.DirectoryKey);
                    var context = _fileContextFactory.Create(directory);

                    var file = descriptor.Activate(context);
                    return file;
                })
                .AddDbContext<TDbContext>((sp, options) =>
                {
                    var db = sp.GetRequiredKeyedService<IDbDefinition<TOwnership, TPlacement, TDbContext>>(descriptor.Key);
                    var connectionString = db.GetConnectionStringBuilder().ConnectionString;

                    options.UseSqlite(connectionString);
                })
                .AddSingleton<IHostResourceSchemaInitializer>(
                    new HostResourceSchemaDbInitializer<TOwnership, TPlacement, TDbContext>(descriptor.Key)));
}
