using FileCompositions.Core.DirectoryLocation;
using FileCompositions.Core.DirectoryLocation.Descriptor;
using FileCompositions.Core.DirectoryLocation.Key;
using FileCompositions.Core.Storage.Backend.ActivationContext;

namespace FileCompositions.Extensions.Host.Schema.Implementation;

internal class HostResourceSchema(IStorageBackendActivationContext activationContext,
    IReadOnlyList<IDirectoryLocationDescriptor>? directoryDescriptors) : IHostResourceSchema
{
    private readonly IReadOnlyList<IDirectoryLocationDescriptor>? _directoryDescriptors = directoryDescriptors;

    public IStorageBackendActivationContext ActivationContext { get; } = activationContext;

    public IDirectoryLocation? GetDirectoryLocation(DirectoryLocationKey key) =>
        _directoryDescriptors?.FirstOrDefault(d => d.Key == key)?
            .Activate(ActivationContext);
}
