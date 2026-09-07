using FileCompositions.Core.Database.File.Specialized.Db.Definition;
using FileCompositions.Core.Database.File.Specialized.Db.Resource;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Resource.Request;
using FileCompositions.Core.Quality;

namespace FileCompositions.Core.Database.File.Specialized.Db.Options;

public partial interface IDbOptions
{
    internal FileResourceRequest<IDbResource> Build();
    internal FileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>> Build<TOwnership, TPlacement>()
        where TOwnership : Ownership
        where TPlacement : Placement;
}
