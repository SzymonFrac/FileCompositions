using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Implementations;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder;
using FileCompositions.Hosting.ResourceSchema.File.Register.Builder.Factory;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Factory.Implementations;

internal sealed class HostResourceSchemaDbRegisterBuilderFactory<TDbContext> : IHostResourceSchemaFileRegisterBuilderFactory
    where TDbContext : DbContext
{
    public IHostResourceSchemaFileRegisterBuilder Create<TInOwnership, TInNecessity>()
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity =>
            new HostResourceSchemaDbRegisterBuilder<TInOwnership, TInNecessity, TDbContext>();
}
