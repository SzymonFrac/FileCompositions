using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.File.Context;
using FileCompositions.Core.File.Definition.Descriptor.Abstract;
using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.File.Specialized.Json.Definition.Implementations;
using FileCompositions.Core.File.Specialized.Json.Definition.Init.Policy;
using FileCompositions.Core.File.Specialized.Json.Format;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Descriptor.Implementations;

//internal sealed class JsonDefinitionDescriptor<TOwnership, TPlacement, TData>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name, JsonFormat format, TData? @default = default)
//    : AbstractFileDefinitionDescriptor<TOwnership, TPlacement, IJsonDefinition<TOwnership, TPlacement, TData>>(directoryKey, key, name),
//    IJsonDefinitionDescriptor<TOwnership, TPlacement, TData>
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement
//{
//    private readonly JsonFormat format = format;
//    private readonly TData? @default = @default;
    
//    public required IJsonInitPolicy<TOwnership, TPlacement, TData> InitPolicy { get; init; }

//    public override IJsonDefinition<TOwnership, TPlacement, TData> Activate(in IFileContext context) =>
//        new JsonDefinition<TOwnership, TPlacement, TData>(context, Key, Name, format, @default)
//        {
//            InitPolicy = InitPolicy
//        };
//}
