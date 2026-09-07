namespace FileCompositions.Core.Quality;

public abstract record Necessity
{
    public sealed record Required : Necessity;
    public sealed record Optional : Necessity;
}
