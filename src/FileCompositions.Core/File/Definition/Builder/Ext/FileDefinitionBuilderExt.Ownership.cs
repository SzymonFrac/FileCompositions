using FileCompositions.Core.File.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Builder.Ext;

//public static partial class FileDefinitionBuilderExt
//{
//    extension<TOwnership, TPlacement, TOptions>(IFileDefinitionBuilder<TOwnership, TPlacement, TOptions> builder)
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement
//        where TOptions  : IFileOptions<TOptions>
//    {
//        public IFileDefinitionBuilder<StrictDefinition, TPlacement, TOptions> Strict() =>
//            builder.Create<StrictDefinition, TPlacement>();
//        public IFileDefinitionBuilder<ExternalDefinition, TPlacement, TOptions> External() =>
//            builder.Create<ExternalDefinition, TPlacement>();
//    }
//}
