using FileCompositions.Core.File.Resource.Specialized;

namespace FileCompositions.Core.File.Definition.Builder;

// Builder for definitions.
// I think definitions need to just worry about optional/required.
// Maybe in the future encryption and stuff...
public interface IFileDefinitionBuilder
{
    IFileDefinitionBuilder WithName(string name);
    IFileDefinition Build(); // params maybe...
    // Descriptor?
}
