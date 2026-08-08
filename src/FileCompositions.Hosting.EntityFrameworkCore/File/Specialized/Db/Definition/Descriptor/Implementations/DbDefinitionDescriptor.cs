namespace FileCompositions.Hosting.EntityFrameworkCore.File.Specialized.Db.Definition.Descriptor.Implementations;

//internal sealed class DbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>(DirectoryDefinitionKey directoryKey, FileDefinitionKey key, string name)
//    : AbstractFileDefinitionDescriptor<TOwnership, TPlacement, IDbDefinition<TOwnership, TPlacement, TDbContext>>(directoryKey, key, name),
//    IDbDefinitionDescriptor<TOwnership, TPlacement, TDbContext>
//        where TOwnership : DefinitionOwnership
//        where TPlacement : DefinitionPlacement
//        where TDbContext : DbContext
//{
//    public required IDbInitPolicy<TOwnership, TPlacement, TDbContext> InitPolicy { get; init; }

//    public override IDbDefinition<TOwnership, TPlacement, TDbContext> Activate(in IFileContext context) =>
//        new DbDefinition<TOwnership, TPlacement, TDbContext>(context, Key, Name)
//        {
//            InitPolicy = InitPolicy
//        };
//}
