namespace FileCompositions.Core.FileSystem.Abstractions.Addressing;

public abstract record Extension
{
    public Index DotIndex => ^ToString().Length;
}
