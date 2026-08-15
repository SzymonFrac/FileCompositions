using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.Database.File.Specialized.Db.Options.Implementations;
using FileCompositions.Core.File.Definition;
using FileCompositions.Core.File.Definition.Builder;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Ext;

public static partial class DbDefinitionBuilderExt
{
    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, RequiredInRequired, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, RequiredInRequired>
        where TBuilder : IFileDefinitionBuilder<TOwnership, RequiredInRequired, TDefinition, TBuilder>
    {
        public IDbDefinitionBuilder<StrictDefinition, RequiredInRequired> Db(Action<IDbOptions> config)
        {
            var db = new DbOptions();
            config(db);

            return new DbDefinitionBuilder<StrictDefinition, RequiredInRequired>(db);
        }
    }

    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, OptionalInRequired, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, OptionalInRequired>
        where TBuilder : IFileDefinitionBuilder<TOwnership, OptionalInRequired, TDefinition, TBuilder>
    {
        public IDbDefinitionBuilder<StrictDefinition, OptionalInRequired> Db(Action<IDbOptions> config)
        {
            var db = new DbOptions();
            config(db);

            return new DbDefinitionBuilder<StrictDefinition, OptionalInRequired>(db);
        }
    }

    extension<TOwnership, TDefinition, TBuilder>(IFileDefinitionBuilder<TOwnership, OptionalInOptional, TDefinition, TBuilder> builder)
        where TOwnership : DefinitionOwnership
        where TDefinition : IFileDefinition<TOwnership, OptionalInOptional>
        where TBuilder : IFileDefinitionBuilder<TOwnership, OptionalInOptional, TDefinition, TBuilder>
    {
        public IDbDefinitionBuilder<StrictDefinition, OptionalInOptional> Db(Action<IDbOptions> config)
        {
            var db = new DbOptions();
            config(db);

            return new DbDefinitionBuilder<StrictDefinition, OptionalInOptional>(db);
        }
    }
}
