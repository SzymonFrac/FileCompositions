using FileCompositions.Core.File.Options.Abstract;

namespace FileCompositions.Core.Database.File.Specialized.Db.Options.Abstract;

internal abstract partial class AbstractDbOptions : AbstractFileOptions<IDbOptions>, IDbOptions
{
    protected override IDbOptions This() => this;
}
