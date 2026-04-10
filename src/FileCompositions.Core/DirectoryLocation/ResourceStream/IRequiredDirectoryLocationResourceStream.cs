using FileCompositions.Core.Storage.ResourceName;

namespace FileCompositions.Core.DirectoryLocation.ResourceStream;

// Implementations use StorageConnector, passed to files for them to use.
// Can go either way but Required Files must get a Required Directory:
// RF + RD = valid
// RF + OD = invalid
// OF + RD = valid
// OF + OD = valid. When directory doesn't exist then file propergates? Although could cause issues when creating a file in a dir that isn't there?

// Eg. An Optional file requires some param that isn't there yet, so the file couldn't exist yet either.
// Would I need some kind of dependency map? Each object needs to know whether it can be created?
internal interface IRequiredDirectoryLocationResourceStream
{
    Task<Stream> OpenReadAsync(StorageResourceName name, CancellationToken cancellationToken = default);
    Task<Stream> OpenWriteAsync(StorageResourceName name, CancellationToken cancellationToken = default);
}
