using FileCompositions.Core.FileSystem.Addressing.File;
using FileCompositions.Core.FileSystem.Proxy.File;
using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem.Session;

//internal readonly ref partial struct FileSystemSession
//{
//    public readonly IFileSystemFileProxy RequestProxy(FileSystemFileAddressing addressing) => new FileProxy(_source, addressing);

//    private sealed record FileProxy : IFileSystemFileProxy
//    {
//        private readonly IFileSystemSource _source;
//        private readonly FileSystemFileAddressing _fileAddressing;

//        public FileProxy(IFileSystemSource source, FileSystemFileAddressing fileAddressing) =>
//            (_source, _fileAddressing) = (source, fileAddressing);


//        public Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.OpenReadAsync(_fileAddressing.Location, ct), cancellationToken);
//        public Task<Stream> OpenWriteAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.OpenWriteAsync(_fileAddressing.Location, ct), cancellationToken);
//        public Task<Stream> OpenAppendAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.OpenAppendAsync(_fileAddressing.Location, ct), cancellationToken);
//        public Task<Stream> OpenCreateAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.OpenCreateAsync(_fileAddressing.Location, ct), cancellationToken);

//        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.ExistsAsync(_fileAddressing.Location, ct), cancellationToken);
//        public ValueTask<bool> AddressExistsAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.ExistsAsync(_fileAddressing.Address, ct), cancellationToken);
//        public ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.CreateAsync(_fileAddressing.Location, ct), cancellationToken);
//        public ValueTask DeleteAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.DeleteAsync(_fileAddressing.Location, ct), cancellationToken);

//    }
//}
