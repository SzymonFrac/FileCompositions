using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.FileSystem.Local.Addressing.Common;

public sealed record LocalLocation : Location
{
    private LocalLocation(Address address, Filename name) : base(address, name) { }
    public static LocalLocation Create(LocalAddress address, Filename name) => new(address, name);

    public override string ToString() => Path.Combine(Address.ToString(), Name.ToString());
}
