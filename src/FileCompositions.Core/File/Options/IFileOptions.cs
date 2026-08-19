namespace FileCompositions.Core.File.Options;

public interface IFileOptions<TOptions>
    where TOptions : IFileOptions<TOptions>
{
    TOptions WithName(string name);
}
