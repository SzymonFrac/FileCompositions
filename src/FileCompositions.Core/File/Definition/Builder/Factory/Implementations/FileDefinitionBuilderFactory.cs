using FileCompositions.Core.Quality.Necessity;

namespace FileCompositions.Core.File.Definition.Builder.Factory.Implementations;

public class FileDefinitionBuilderFactory<TInNecessity> : IFileDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity;
