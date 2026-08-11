using FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Implementations;
using FileCompositions.Core.Database.File.Specialized.Db.Options;
using FileCompositions.Core.Database.File.Specialized.Db.Options.Implementations;
using FileCompositions.Core.File.Definition.Builder.Factory;
using FileCompositions.Core.Quality.Necessity.Implementations;
using FileCompositions.Core.Quality.Ownership.Implementations;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder.Factory.Ext;

public static partial class DbDefinitionBuilderFactoryExt
{
    extension(IFileDefinitionBuilderFactory<RequiredDefinition> factory)
    {
        public DbDefinitionBuilder<StrictDefinition, RequiredDefinition> Db(Action<IDbOptions> config)
        {
            var db = new DbOptions();
            config(db);

            var builder = new DbDefinitionBuilder<StrictDefinition, RequiredDefinition>(db);
            return builder;
        }
    }

    extension(IFileDefinitionBuilderFactory<OptionalDefinition> factory)
    {
        public DbDefinitionBuilder<StrictDefinition, OptionalDefinition> Db(Action<IDbOptions> config)
        {
            var db = new DbOptions();
            config(db);

            var builder = new DbDefinitionBuilder<StrictDefinition, OptionalDefinition>(db);
            return builder;
        }
    }
}
