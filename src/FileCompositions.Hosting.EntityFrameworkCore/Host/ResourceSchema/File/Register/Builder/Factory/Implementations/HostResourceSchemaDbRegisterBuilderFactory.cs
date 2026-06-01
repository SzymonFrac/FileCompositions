using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Extensions.Host.Schema.File.Register.Builder;
using FileCompositions.Extensions.Host.Schema.File.Register.Builder.Factory;
using FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Implementations;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.Host.ResourceSchema.File.Register.Builder.Factory.Implementations;

internal class HostResourceSchemaDbRegisterBuilderFactory<TDbContext> : IHostResourceSchemaFileRegisterBuilderFactory
    where TDbContext : DbContext
{
    public IHostResourceSchemaFileRegisterBuilder Create<TInOwnership, TInNecessity>()
        where TInOwnership : DefinitionOwnership
        where TInNecessity : DefinitionNecessity =>
            new HostResourceSchemaDbRegisterBuilder<TInOwnership, TInNecessity, TDbContext>();
}
