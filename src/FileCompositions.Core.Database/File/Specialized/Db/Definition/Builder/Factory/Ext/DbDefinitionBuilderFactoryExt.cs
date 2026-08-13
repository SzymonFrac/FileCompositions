using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.Database.File.Specialized.Db.Options.Implementations;
using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;
using FileCompositions.Core.Quality.Placement.Implementations;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Factory.Ext;

public static partial class DbDefinitionBuilderFactoryExt
{
    extension(IFileDefinitionBuilderFactory<RequiredDefinition> factory)
    {
        public IDbDefinitionBuilder<StrictDefinition, RequiredInRequired> Db(Action<IDbOptions> config)
        {
            var db = new DbOptions();
            config(db);

            var builder = new DbDefinitionBuilder<StrictDefinition, RequiredInRequired>(db);
            return builder;
        }
    }

    extension(IFileDefinitionBuilderFactory<OptionalDefinition> factory)
    {
        public IDbDefinitionBuilder<StrictDefinition, OptionalInOptional> Db(Action<IDbOptions> config)
        {
            var db = new DbOptions();
            config(db);

            var builder = new DbDefinitionBuilder<StrictDefinition, OptionalInOptional>(db);
            return builder;
        }
    }
}
