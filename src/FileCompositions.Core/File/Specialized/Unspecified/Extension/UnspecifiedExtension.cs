using FileCompositions.Core.File.Extension.Some;

namespace FileCompositions.Core.File.Specialized.Unspecified.Extension;

internal sealed record UnspecifiedExtension() : SomeFileExtension(string.Empty);
