using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Hosting.ResourceSchema.Initializer;
using FileCompositions.Hosting.ResourceSchema.Initializer.Implementations;
using FileCompositions.Hosting.ResourceSchema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Implementations;

internal sealed class HostResourceSchemaFileRegisterBuilder<TInOwnership, TInNecessity> : IHostResourceSchemaFileRegisterBuilder
        where TInOwnership : Ownership
        where TInNecessity : Necessity
{
    public HostResourceSchemaRegister Build<TOwnership, TPlacement, TDefinition>(ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> request)
        where TOwnership : Ownership
        where TPlacement : Placement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement> =>
            new((in services) => services
                .AddKeyedSingleton<TDefinition>(request.FileKey, (sp, key) =>
                    sp.GetRequiredKeyedService<IDirectoryDefinition<TInOwnership, TInNecessity>>(request.DirectoryKey)
                        .RequestFileDefinition(request.Request)
                )
                .AddSingleton<IHostResourceSchemaInitializer>(
                    new HostResourceSchemaFileInitializer<TDefinition, TOwnership, TPlacement>(request.FileKey)));
}
