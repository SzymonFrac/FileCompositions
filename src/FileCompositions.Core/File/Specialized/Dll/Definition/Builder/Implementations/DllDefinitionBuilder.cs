using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.File.Definition.Builder.Abstract;
using FileCompositions.Core.File.Definition.Descriptor;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Dll.Config;
using FileCompositions.Core.File.Specialized.Dll.Definition.Descriptor;
using FileCompositions.Core.File.Specialized.Dll.Definition.Descriptor.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Dll.Definition.Init.Policy.Implementations;
using FileCompositions.Core.File.Specialized.Json.Config;
using FileCompositions.Core.File.Specialized.Json.Definition;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Dll.Definition.Builder.Implementations;

//internal sealed class DllDefinitionBuilder<TOwnership, TNecessity>
//    : AbstractFileDefinitionBuilder<TOwnership, TNecessity>, IDllDefinitionBuilder<TOwnership, TNecessity>
//        where TOwnership : DefinitionOwnership
//        where TNecessity : DefinitionNecessity
//{
//    internal DllDefinitionBuilder(DirectoryDefinitionKey directoryKey) : base(directoryKey) { }
//    private DllDefinitionBuilder(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string? name) : base(directoryKey, key, name) { }

//    public IDllDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key)
//    {
//        Key = key;
//        return this;
//    }
//    public IDllDefinitionBuilder<TOwnership, TNecessity> WithName(string name)
//    {
//        Name = name;
//        return this;
//    }

//    public IDllDefinitionBuilder<ExternalDefinition, TNecessity> External() =>
//        new DllDefinitionBuilder<ExternalDefinition, TNecessity>(DirectoryKey, Key, Name);
//    public IDllDefinitionBuilder<StrictDefinition, TNecessity> Strict() =>
//        new DllDefinitionBuilder<StrictDefinition, TNecessity>(DirectoryKey, Key, Name);
//    public IDllDefinitionBuilder<TOwnership, RequiredDefinition> Required() =>
//        new DllDefinitionBuilder<TOwnership, RequiredDefinition>(DirectoryKey, Key, Name);
//    public IDllDefinitionBuilder<TOwnership, OptionalDefinition> Optional() =>
//        new DllDefinitionBuilder<TOwnership, OptionalDefinition>(DirectoryKey, Key, Name);

//    public IDllDefinition<TOwnership, TPlacement> Build<TPlacement>(in IFileContext context)
//        where TPlacement : DefinitionPlacement
//    {
//        if (Name is null)
//            throw new NullReferenceException("File must have a non-empty name.");

//        return new DllDefinition<TOwnership, TPlacement>(context, Key, Name)
//        {
//            InitPolicy = new DefaultDllInitPolicy<TOwnership, TPlacement>()
//        };
//    }

//    public IDllDefinitionDescriptor<TOwnership, TPlacement> BuildDescriptor<TPlacement>()
//        where TPlacement : DefinitionPlacement
//    {
//        if (Name is null)
//            throw new NullReferenceException("File must have a non-empty name.");

//        return new DllDefinitionDescriptor<TOwnership, TPlacement>(DirectoryKey, Key, Name)
//        {
//            InitPolicy = new DefaultDllInitPolicy<TOwnership, TPlacement>()
//        };
//    }
//}

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

        // get config's delegate
        // partially apply here...
        var descriptor = _config.Build<TOwnership, TPlacement>();
        var partialDescriptor = new FileDefinitionRequestDescriptor<TOwnership, TPlacement, IDllDefinition<TOwnership, TPlacement>>((IFileContext context) => descriptor(Key, context));

        return partialDescriptor;
    }

    //public IFileDefinition<TOwnership, TPlacement> Definition<TPlacement>(FileDefinitionKey key, IFileContext context)
    //    where TPlacement : DefinitionPlacement
    //        => new JsonDefinition<TOwnership, TPlacement, TData>(context, key);
};