using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.Storage.Location;

namespace FileCompositions.Core.Exception.ExternalRequiredMissing;

internal class ExternalRequiredFileMissingException : System.Exception
{
    public required StorageLocation Location { get; init; }
    public required FileDefinitionKey Key { get; init; }

    public ExternalRequiredFileMissingException() : base() { }
    public ExternalRequiredFileMissingException(string message) : base(message) { }
    public ExternalRequiredFileMissingException(string message, System.Exception inner) : base(message, inner) { }

}