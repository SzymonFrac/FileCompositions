using FileCompositions.Core.File.Context.Factory;
using FileCompositions.Core.File.Context.Factory.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Implementations;

namespace FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory.Implementations;

internal sealed class HostResourceSchemaFileRegisterBuilderFactory : IHostResourceSchemaFileRegisterBuilderFactory
{
    public IFileContextFactory FileContextFactory { get; init; } = new FileContextFactory();

    public IHostResourceSchemaFileRegisterBuilder Create<TInOwnership, TInNecessity>()
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity =>
            new HostResourceSchemaFileRegisterBuilder<TInOwnership, TInNecessity>()
            {
                FileContextFactory = FileContextFactory
            };
}
