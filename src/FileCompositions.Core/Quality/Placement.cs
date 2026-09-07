namespace FileCompositions.Core.Quality;

public abstract record Placement
{
    public sealed record RequiredInRequired : Placement;
    public sealed record OptionalInRequired : Placement;
    public sealed record OptionalInOptional : Placement;
}