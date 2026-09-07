using FileCompositions.Core.Database.File.Specialized.Db.Definition;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Definition.Init.Policy.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Resource;
using FileCompositions.Core.Database.File.Specialized.Db.Resource.Implementations;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Options.Abstract;
using FileCompositions.Core.File.Resource.Request;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Options.Abstract;

internal abstract partial class AbstractDbOptions : AbstractFileOptions<IDbOptions>, IDbOptions
{
    public FileResourceRequest<IDbResource> Build() =>
        (in context) => new DbResource(context, Name);
    public FileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>> Build<TOwnership, TPlacement>()
        where TOwnership : Ownership
        where TPlacement : Placement =>
            key => (in context) => new DbDefinition<TOwnership, TPlacement>(context, key, Name)
            {
                InitPolicy = new DefaultDbInitPolicy<TOwnership, TPlacement>()
            };
}
