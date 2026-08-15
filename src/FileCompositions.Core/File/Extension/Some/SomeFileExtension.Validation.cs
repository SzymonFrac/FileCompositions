using System.Text.RegularExpressions;

namespace FileCompositions.Core.File.Extension.Some;

public abstract partial record SomeFileExtension
{
    [GeneratedRegex(@"^\.[a-zA-Z0-9\-]+$", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    private static partial Regex ValidExtension();
}
