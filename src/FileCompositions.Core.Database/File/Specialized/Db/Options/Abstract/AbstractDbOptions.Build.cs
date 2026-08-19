using FileCompositions.Core.Database.File.Specialized.Db.Definition;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Init.Policy.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Resource;
using FileCompositions.Core.Database.File.Specialized.Db.Resource.Implementations;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Options.Abstract;
using FileCompositions.Core.File.Resource.Request;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.Database.File.Specialized.Db.Options.Abstract;

internal abstract partial class AbstractDbOptions : AbstractFileOptions<IDbOptions>, IDbOptions
{
    public FileResourceRequest<IDbResource> Build() =>
        (in context) => new DbResource(context, Name);
    public FileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>> Build<TOwnership, TPlacement>()
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement =>
            key => (in context) => new DbDefinition<TOwnership, TPlacement>(context, key, Name)
            {
                InitPolicy = new DefaultDbInitPolicy<TOwnership, TPlacement>()
            };
}
