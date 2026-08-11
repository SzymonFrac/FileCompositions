using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Options;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;
using FileCompositions.Core.ResourceSchema.File.Register.Request;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;

public class DllDefinitionBuilder<TOwnership, TNecessity>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity, DllDefinitionBuilder<TOwnership, TNecessity>>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private readonly IDllOptions _config;

    public DllDefinitionBuilder(IDllOptions config) => _config = config;
    protected DllDefinitionBuilder(IDllOptions config, FileDefinitionKey? key = default) : base(key) => _config = config;

    public override DllDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }

    public DllDefinitionBuilder<ExternalDefinition, TNecessity> External() => new(_config, Key);
    public DllDefinitionBuilder<StrictDefinition, TNecessity> Strict() => new(_config, Key);
    public DllDefinitionBuilder<TOwnership, RequiredDefinition> Required() => new(_config, Key);
    public DllDefinitionBuilder<TOwnership, OptionalDefinition> Optional() => new(_config, Key);


    internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>> Build<TPlacement>(DirectoryDefinitionKey directoryKey)
        where TPlacement : DefinitionPlacement
    {
        var key = BuildKey();

        var descriptor = _config.Build<TOwnership, TPlacement>();
        var request = descriptor(key);

        return new(directoryKey, key, request);
    }
}
