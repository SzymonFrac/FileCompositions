namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Descriptor.Implementations;

//internal sealed class DbDefinitionDescriptor<TOwnership, TPlacement>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
//    : AbstractFileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement>>(directoryKey, key, name),
//    IDbDefinitionDescriptor<TOwnership, TPlacement>
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement
//{
//    public required IDbInitPolicy<TOwnership, TPlacement> InitPolicy { get; init; }

//    public override IDbDefinition<TOwnership, TPlacement> Activate(in IFileContext context) =>
//        new DbDefinition<TOwnership, TPlacement>(context, Key, Name)
//        {
//            InitPolicy = InitPolicy
//        };
//}
