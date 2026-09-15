using FileCompositions.Core.File.Definition.Key;
using FileCompositions.Core.FileSystem.Abstractions.Addressing;

namespace FileCompositions.Core.Exception.ExternalRequiredMissing;

internal sealed class ExternalRequiredFileMissingException : System.Exception
{
    public required Location Location { get; init; }
    public required FileDefinitionKey? Key { get; init; }

    public ExternalRequiredFileMissingException() : base() { }
    public ExternalRequiredFileMissingException(string message) : base(message) { }
    public ExternalRequiredFileMissingException(string message, System.Exception inner) : base(message, inner) { }

}