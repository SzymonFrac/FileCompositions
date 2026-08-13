using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Options;
using Microsoft.EntityFrameworkCore;

namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Builder.Abstract;

internal abstract partial class AbstractDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
    : AbstractFileDefinitionBuilder<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>, IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>>,
    IDbDefinitionBuilder<TOwnership, TPlacement, TDbContext>
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
        where TDbContext : DbContext
{
    protected IDbOptions<TDbContext> Options { get; set; }

    public AbstractDbDefinitionBuilder(IDbOptions<TDbContext> options) => Options = options;
    protected AbstractDbDefinitionBuilder(IDbOptions<TDbContext> options, FileDefinitionKey? key = default) : base(key) => Options = options;

    public abstract IDbDefinitionBuilder<TNewOwnership, TNewPlacement, TDbContext> Create<TNewOwnership, TNewPlacement>()
        where TNewOwnership : DefinitionOwnership
        where TNewPlacement : DefinitionPlacement;
}
