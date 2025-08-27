using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace StringSlugify;

public static class StringSlugifyExtensions
{
    private static readonly Regex NonAlphanumericRegex = new Regex(@"[^a-z0-9\s-]", RegexOptions.Compiled);
    private static readonly Regex MultiSpaceOrDashRegex = new Regex(@"[\s-]+", RegexOptions.Compiled);

    /// <summary>
    /// Converts a string into a URL-friendly slug.
    /// Null and whitespace become an empty string.
    /// </summary>
    public static string ToSlug(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        // Normalize to decompose accents (FormD), then remove NonSpacingMark categories.
        string normalized = value.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder(capacity: normalized.Length);

        foreach (var c in normalized)
        {
            var uc = CharUnicodeInfo.GetUnicodeCategory(c);
            if (uc != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }

        string noAccents = sb.ToString().Normalize(NormalizationForm.FormC);

        // Lowercase invariant
        string lower = noAccents.ToLowerInvariant();

        // Remove non-alphanumeric except spaces and dashes
        string cleaned = NonAlphanumericRegex.Replace(lower, string.Empty);

        // Replace sequences of space/dash with single '-'
        string slug = MultiSpaceOrDashRegex.Replace(cleaned, "-");

        // Trim dashes
        return slug.Trim('-');
    }
}
