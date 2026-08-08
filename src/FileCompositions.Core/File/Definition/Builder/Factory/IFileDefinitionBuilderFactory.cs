using FileCompositions.Core.Quality.Necessity;

namespace FileCompositions.Core.File.Definition.Builder.Factory;

public interface IFileDefinitionBuilderFactory<TInNecessity>
    where TInNecessity : DefinitionNecessity;
