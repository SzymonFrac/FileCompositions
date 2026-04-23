using FileCompositions.Core.File.Definition;

namespace FileCompositions.Core.ResourceSchema.File.Definition.Registrar;

public interface IResourceSchemaDefinitionRegistrar
{
    IResourceSchemaDefinitionRegistrar Register<TFileDefinition>()
        where TFileDefinition : class, IFileDefinition;
}
