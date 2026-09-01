using FileCompositions.Core.FileSystem.Addressing.Directory;
using FileCompositions.Core.FileSystem.Proxy.Directory;
using FileCompositions.Core.FileSystem.Source;

namespace FileCompositions.Core.FileSystem.Session;

//internal readonly ref partial struct FileSystemSession
//{
//    public readonly IFileSystemDirectoryProxy RequestProxy(FileSystemDirectoryAddressing addressing) => new DirectoryProxy(_source, addressing);

//    private sealed record DirectoryProxy : IFileSystemDirectoryProxy
//    {
//        private readonly IFileSystemSource _source;
//        private readonly FileSystemDirectoryAddressing _directoryAddressing;

//        public DirectoryProxy(IFileSystemSource source, FileSystemDirectoryAddressing directoryAddressing) =>
//            (_source, _directoryAddressing) = (source, directoryAddressing);


//        public ValueTask<bool> ExistsAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.ExistsAsync(_directoryAddressing.Address, ct), cancellationToken);
//        public ValueTask CreateAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.CreateAsync(_directoryAddressing.Address, ct), cancellationToken);
//        public ValueTask DeleteAsync(CancellationToken cancellationToken = default) =>
//            _source.RequestAsync((in fs, ct) => fs.DeleteAsync(_directoryAddressing.Address, ct), cancellationToken);
//    }
//}
