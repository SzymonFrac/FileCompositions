using FileCompositions.Core.File.Options.Abstract;

namespace FileCompositions.Core.File.Specialized.Dll.Options.Abstract;

internal abstract partial class AbstractDllOptions : AbstractFileOptions<IDllOptions>, IDllOptions
{
    protected override IDllOptions This() => this;
}
