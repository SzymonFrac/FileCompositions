using FileCompositions.Core.Database.File.Specialized.Db.Options.Implementations;
using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Abstract;

internal abstract partial class AbstractDbDefinitionBuilder<TOwnership, TPlacement> : IDbDefinitionBuilder<TOwnership, TPlacement>
    where TOwnership : DefinitionOwnership
    where TPlacement : DefinitionPlacement
{
    public ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>> Build(DirectoryDefinitionKey directoryKey)
    {
        var options = new DbOptions();
        _config(options);

        var key = _inner.BuildKey();

        var descriptor = options.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
