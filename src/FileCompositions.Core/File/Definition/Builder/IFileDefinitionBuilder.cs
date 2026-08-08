using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Quality.Necessity;
using FileCompositions.Core.Quality.Ownership;

namespace FileCompositions.Core.File.Definition.Builder;

// good or retard?
// when TInNecessity is Required - lets Optional/Required
// when is Optiona - lets only optional.
//public interface IFileDefinitionBuilder<TOwnership, TInNecessity, TPlacement, TDefinition>
//    where TOwnership : DefinitionOwnership
//    where TInNecessity : DefinitionNecessity
//    where TPlacement : DefinitionPlacement
//    where TDefinition : IFileDefinition<TOwnership, TPlacement>
//{
//    //internal DirectoryDefinitionKey DirectoryKey { get; }


//};
public interface IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
    where TOwnership : DefinitionOwnership
    where TNecessity : DefinitionNecessity
    where TBuilder : IFileDefinitionBuilder<TOwnership, TNecessity, TBuilder>
{
    //internal DirectoryDefinitionKey DirectoryKey { get; }
    //internal IFileDefinition<TOwnership, TPlacement> Definition<TPlacement>(FileDefinitionKey key, IFileContext context)
    //    where TPlacement : DefinitionPlacement;
    //internal TBuilder Create<TNewOwnership, TNewNecessity>(FileDefinitionKey? key = default)
    //    where TNewOwnership : DefinitionOwnership
    //    where TNewNecessity : DefinitionNecessity;

    TBuilder WithKey(FileDefinitionKey key);

    // comment for now - make quality changes in interface as source of truth... (or maybe even in quality definitions...)
    //IFileDefinitionBuilder<ExternalDefinition, TNecessity> External() => Create<ExternalDefinition, TNecessity>();
    //IFileDefinitionBuilder<StrictDefinition, TNecessity> Strict() => Create<StrictDefinition, TNecessity>();
    //IFileDefinitionBuilder<TOwnership, RequiredDefinition> Required() => Create<TOwnership, RequiredDefinition>();
    //IFileDefinitionBuilder<TOwnership, OptionalDefinition> Optional() => Create<TOwnership, OptionalDefinition>();


    // only implementations knows to build

    //internal FileDefinitionDescriptor<TOwnership, TPlacement, TDefinition> Build<TPlacement, TDefinition>()
    //    where TPlacement : DefinitionPlacement
    //    where TDefinition : IFileDefinition<TOwnership, TPlacement>;

    //internal sealed FileDefinitionDescriptor<TOwnership, TPlacement, TDefinition> Build<TPlacement, TDefinition>()
    //    where TPlacement : DefinitionPlacement
    //    where TDefinition : IFileDefinition<TOwnership, TPlacement> =>
    //        Definition;


    // probably have to refactor Placement anyway... now that i know about partial classes/nesting classes/etc.
    //internal class Placement<TPlacement>
    //    where TPlacement : DefinitionPlacement
    //{
    //    public FileDefinitionDescriptor<TOwnership, TPlacement, TDefinition> Build<TDefinition>()
    //        where TDefinition : IFileDefinition<TOwnership, TPlacement> =>
    //            (key, context) => new ;
    //}

    //internal FileDefinitionDescriptor<TOwnership, TPlacement, TDefinition> Build();
};
