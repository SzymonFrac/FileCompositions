namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Builder;

//public interface IDbDefinitionBuilder<TOwnership, TNecessity> : IFileDefinitionBuilder<TOwnership, TNecessity>
//    where TOwnership : DefinitionOwnership
//    where TNecessity : DefinitionNecessity
//{
//    IDbDefinitionBuilder<TOwnership, TNecessity> WithKey(FileDefinitionKey key);
//    IDbDefinitionBuilder<TOwnership, TNecessity> WithName(string name);

//    IDbDefinitionBuilder<ExternalDefinition, TNecessity> External();
//    IDbDefinitionBuilder<StrictDefinition, TNecessity> Strict();
//    IDbDefinitionBuilder<TOwnership, RequiredDefinition> Required();
//    IDbDefinitionBuilder<TOwnership, OptionalDefinition> Optional();

//    internal IDbDefinition<TOwnership, TPlacement> Build<TPlacement>(in IFileContext context)
//        where TPlacement : DefinitionPlacement;
//    internal IDbDefinitionDescriptor<TOwnership, TPlacement> BuildDescriptor<TPlacement>()
//        where TPlacement : DefinitionPlacement;
//}
