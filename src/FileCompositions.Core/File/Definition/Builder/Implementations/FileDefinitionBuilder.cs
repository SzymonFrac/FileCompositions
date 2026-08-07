using FileCompositions.Core.File.Config;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Builder.Implementations;

public sealed class FileDefinitionBuilder<TOwnership, TNecessity>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
{
    private readonly FileDefinitionKey? _key;
    private IFileConfig config;

    private FileDefinitionBuilder(FileDefinitionKey? key) => _key = key;
    public FileDefinitionBuilder() { }

    public FileDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key) => new(key);
    internal FileDefinitionBuilder<TOwnership, TNecessity> Type<TPlacement>(IFileConfig c/*Func<FileDefinitionKey, IFileContext, IFileDefinition<TOwnership, TPlacement>> descriptor*/)
        where TPlacement : DefinitionPlacement
    {
        // so extensions get implementations...
        config = c;
        return this;
    }

    public FileDefinitionBuilder<ExternalDefinition, TNecessity> External() => new(_key);
    public FileDefinitionBuilder<StrictDefinition, TNecessity> Strict() => new(_key);
    public FileDefinitionBuilder<TOwnership, RequiredDefinition> Required() => new(_key);
    public FileDefinitionBuilder<TOwnership, OptionalDefinition> Optional() => new(_key);

    internal Func<IFileContext, IFileDefinition<TOwnership, TPlacement>> Build<TPlacement>()
        where TPlacement : DefinitionPlacement
    {
        if (_key is null)
            throw new NullReferenceException("File definition must have a Key.");

        //config
        var descriptor = config.Build<TOwnership, TPlacement>();
        var partialAppliedDel = (IFileContext context) => descriptor(_key, context);
        return partialAppliedDel;
    }
}
