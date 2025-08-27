using Xunit;
using StringSlugify;

namespace StringSlugify.Tests;

public class ToSlugTests
{
    [Theory]
    [InlineData("Café crème", "cafe-creme")]
    [InlineData("Hello, World!", "hello-world")]
    [InlineData("Déjà Vu", "deja-vu")]
    [InlineData("---Multiple   Spaces---", "multiple-spaces")]
    [InlineData("", "")]
    [InlineData(null, "")]
    public void ToSlug_BasicCases(string? input, string expected)
    {
        var actual = input.ToSlug();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToSlug_TrimDashes_StartEndRemoved()
    {
        var s = "--a--b--";
        Assert.Equal("a-b", s.ToSlug());
    }

    [Fact]
    public void ToSlug_Unicode_LeavesValidLettersAfterNormalization()
    {
        var s = "Łódź"; // After normalization without transliteration, removes diacritics on typical Latin letters
        var slug = s.ToSlug();
        Assert.True(slug.Length > 0);
    }
}
