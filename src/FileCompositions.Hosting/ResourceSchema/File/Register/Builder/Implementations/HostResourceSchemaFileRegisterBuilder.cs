using FileCompositions.Core.Directory.Definition;
using FileCompositions.Core.File.Context.Factory;
using FileCompositions.Core.File.Context.Factory.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;
using FileCompositions.Hosting.ResourceSchema.Initializer;
using FileCompositions.Hosting.ResourceSchema.Initializer.Implementations;
using FileCompositions.Hosting.ResourceSchema.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Implementations;

internal sealed class HostResourceSchemaFileRegisterBuilder<TInOwnership, TInNecessity> : IHostResourceSchemaFileRegisterBuilder
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity
{
    // This should be in DI:
    // Similarly, pass the init trigger/policy as DI to all definitions too. Or as descriptor?
    public IFileContextFactory FileContextFactory { get; init; } = new FileContextFactory();


    public HostResourceSchemaRegister Build<TOwnership, TPlacement, TDefinition>(ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> request)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDefinition : class, IFileDefinition<TOwnership, TPlacement> =>
            new((in services) => services
                .AddKeyedSingleton<TDefinition>(request.FileKey, (sp, key) =>
                {
                    var directory = sp.GetRequiredKeyedService<IDirectoryDefinition<TInOwnership, TInNecessity>>(request.DirectoryKey);
                    var context = FileContextFactory.Create(directory);

                    var file = request.Request(context);

                    return file;
                })
                .AddSingleton<IHostResourceSchemaInitializer>(
                    new HostResourceSchemaFileInitializer<TDefinition, TOwnership, TPlacement>(request.FileKey)));
}
