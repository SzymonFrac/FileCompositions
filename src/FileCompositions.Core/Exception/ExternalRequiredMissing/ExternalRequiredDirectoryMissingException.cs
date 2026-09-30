using FileCompositions.Core.Directory.Definition.Key;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.Exception.ExternalRequiredMissing;

public sealed class ExternalRequiredDirectoryMissingException : System.Exception
{
    public required Address Address { get; init; }
    public required DirectoryDefinitionKey Key { get; init; }

    public ExternalRequiredDirectoryMissingException() : base() { }
    public ExternalRequiredDirectoryMissingException(string message) : base(message) { }
    public ExternalRequiredDirectoryMissingException(string message, System.Exception inner) : base(message, inner) { }

}
