using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
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
    public HostResourceSchemaRegister Build<TOwnership, TPlacement, TDefinition>(ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> request)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement> =>
            new((in services) => services
                .AddKeyedSingleton<TDefinition>(request.FileKey, (sp, key) =>
                    sp.GetRequiredKeyedService<IDirectoryDefinition<TInOwnership, TInNecessity>>(request.DirectoryKey)
                        .RequestFileDefinition(request.Request)
                )
                .AddDbContext<TDbContext>((sp, options) =>
                {
                    var db = sp.GetRequiredKeyedService<IDbDefinition<TOwnership, TPlacement, TDbContext>>(request.FileKey);
                    var connectionString = db.GetConnectionStringBuilder().ConnectionString;

                    options.UseSqlite(connectionString);
                })
                .AddSingleton<IHostResourceSchemaInitializer>(
                    new HostResourceSchemaDbInitializer<TOwnership, TPlacement, TDbContext>(request.FileKey)));
}
