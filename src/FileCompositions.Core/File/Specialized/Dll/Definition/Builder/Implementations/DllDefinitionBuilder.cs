using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Config;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;

public class DllDefinitionBuilder<TOwnership, TNecessity>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity, DllDefinitionBuilder<TOwnership, TNecessity>>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    private readonly IDllConfig _config;

    public DllDefinitionBuilder(IDllConfig config) => _config = config;
    protected DllDefinitionBuilder(IDllConfig config, FileDefinitionKey? key = default) : base(key) => _config = config;

    protected override DllDefinitionBuilder<TOwnership, TNecessity> Create<TNewOwnership, TNewNecessity>() => new(_config, Key);

    public override DllDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }

    public DllDefinitionBuilder<ExternalDefinition, TNecessity> External() => new(_config, Key);
    public DllDefinitionBuilder<StrictDefinition, TNecessity> Strict() => new(_config, Key);
    public DllDefinitionBuilder<TOwnership, RequiredDefinition> Required() => new(_config, Key);
    public DllDefinitionBuilder<TOwnership, OptionalDefinition> Optional() => new(_config, Key);


    internal FileDefinitionRequestDescriptor<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>> Build<TPlacement>(out FileDefinitionKey key)
        where TPlacement : DefinitionPlacement
    {
        if (Key is null)
            throw new NullReferenceException("File must have a key.");

        key = Key;

        var descriptor = _config.Build<TOwnership, TPlacement>();
        var partialDescriptor = new FileDefinitionRequestDescriptor<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>>((IFileContext context) => descriptor(Key, context));

        return partialDescriptor;
    }
}
