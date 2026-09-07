namespace FileCompositions.Core.Quality;

public abstract record Ownership
{
    public sealed record Internal : Ownership;
    public sealed record External : Ownership;
}
