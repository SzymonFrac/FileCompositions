using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Definition.Specialized.Dll.Descriptor;
using FileCompositions.Core.File.Definition.Specialized.Dll.Descriptor.Implementations;
using FileCompositions.Core.File.Definition.Specialized.Dll.Implementations;
using FileCompositions.Core.File.Init.Specialized.Dll.Policy.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Specialized.Dll.Builder.Implementations;

internal sealed class DllDefinitionBuilder<TOwnership, TNecessity>
    : AbstractFileDefinitionBuilder<TOwnership, TNecessity>, IDllDefinitionBuilder<TOwnership, TNecessity>
        where TOwnership : DefinitionOwnership
        where TNecessity : DefinitionNecessity
{
    internal DllDefinitionBuilder(DirectoryDefinitionKey directoryKey) : base(directoryKey) { }
    private DllDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name) : base(directoryKey, key, name) { }

    public IDllDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key)
    {
        Key = key;
        return this;
    }
    public IDllDefinitionBuilder<TOwnership, TNecessity> WithName(string name)
    {
        Name = name;
        return this;
    }

    public IDllDefinitionBuilder<ExternalDefinition, TNecessity> External() =>
        new DllDefinitionBuilder<ExternalDefinition, TNecessity>(DirectoryKey, Key, Name);
    public IDllDefinitionBuilder<StrictDefinition, TNecessity> Strict() =>
        new DllDefinitionBuilder<StrictDefinition, TNecessity>(DirectoryKey, Key, Name);
    public IDllDefinitionBuilder<TOwnership, RequiredDefinition> Required() =>
        new DllDefinitionBuilder<TOwnership, RequiredDefinition>(DirectoryKey, Key, Name);
    public IDllDefinitionBuilder<TOwnership, OptionalDefinition> Optional() =>
        new DllDefinitionBuilder<TOwnership, OptionalDefinition>(DirectoryKey, Key, Name);

    public IDllDefinition<TOwnership, TPlacement> Build<TPlacement>(in IFileContext context)
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        return new DllDefinition<TOwnership, TPlacement>(context, Key, Name)
        {
            InitPolicy = new DefaultDllInitPolicy<TOwnership, TPlacement>()
        };
    }

    public IDllDefinitionDescriptor<TOwnership, TPlacement> BuildDescriptor<TPlacement>()
        where TPlacement : DefinitionPlacement
    {
        if (Name is null)
            throw new NullReferenceException("File must have a non-empty name.");

        return new DllDefinitionDescriptor<TOwnership, TPlacement>(DirectoryKey, Key, Name)
        {
            InitPolicy = new DefaultDllInitPolicy<TOwnership, TPlacement>()
        };
    }

}
