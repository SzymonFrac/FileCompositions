using FileCompositions.Core.File.No.Definition.Builder;
using FileCompositions.Core.File.Specialized.Json.Definition.Builder.Implementations;
using FileCompositions.Core.File.Specialized.Json.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Specialized.Json.Definition.Builder.Ext;

public static partial class JsonDefinitionBuilderExt
{
    extension<TOwnership, TPlacement>(INoFileDefinitionBuilder<TOwnership, TPlacement> inner)
        where TOwnership : DefinitionOwnership
        where TPlacement : DefinitionPlacement
    {
        // might not work cause of generics....
        public IJsonDefinitionBuilder<TOwnership, TPlacement, TData> Json<TData>(Action<IJsonOptions<TData>> config) =>
            new JsonDefinitionBuilder<TOwnership, TPlacement, TData>(inner, config);
    }
}
