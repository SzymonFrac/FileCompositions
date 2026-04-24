using FileCompositions.Core.File.Definition;

namespace FileCompositions.Core.ResourceSchema.File.Definition.Registrar;

public interface IResourceSchemaFileDefinitionRegistrar
{
    IResourceSchemaFileDefinitionRegistrar Register<TFileDefinition>()
        where TFileDefinition : class, IFileDefinition;
}
