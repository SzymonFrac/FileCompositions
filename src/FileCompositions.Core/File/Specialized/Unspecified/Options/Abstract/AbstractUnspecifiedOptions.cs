using FileCompositions.Core.File.Options.Abstract;

namespace FileCompositions.Core.File.Specialized.Unspecified.Options.Abstract;

internal abstract partial class AbstractUnspecifiedOptions : AbstractFileOptions<IUnspecifiedOptions>, IUnspecifiedOptions
{
    protected override IUnspecifiedOptions This() => this;
}
