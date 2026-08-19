namespace FileCompositions.Core.File.Options.Abstract;

internal abstract partial class AbstractFileOptions<TOptions> : IFileOptions<TOptions>
    where TOptions : IFileOptions<TOptions>
{
    protected string Name
    {
        get => field ?? throw new NullReferenceException("File must have a name.");
        set;
    }

    protected abstract TOptions This();

    public TOptions WithName(string name)
    {
        Name = name;
        return This();
    }
}
