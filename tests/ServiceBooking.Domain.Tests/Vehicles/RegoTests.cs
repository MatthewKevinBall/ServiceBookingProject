namespace ServiceBooking.Domain.Tests.Vehicles;
using ServiceBooking.Domain.Vehicles;
public class RegoTests
{
    [Theory]
    [InlineData("abc123", "ABC123")]
    public void CreateWithLowercaseInputStoresUppercaseValue(string input, string expected)
    {
        var rego = Rego.Create(input);

        Assert.Equal(expected, rego.Value);
    }
    
    [Theory]
    [InlineData("AB 123",  "AB 123")]
    [InlineData("AB 23",  "AB 23")]

    public void CreateWithSpaceInputStoresWithoutThrow(string input, string expected)
    {
        var rego = Rego.Create(input);

        Assert.Equal(expected, rego.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("1234")]
    [InlineData("1234567")]
    public void CreateWithInvalidLengthThrowsArgumentException(string input)
    {
        var ex = Assert.Throws<ArgumentException>(() => Rego.Create(input));
        Assert.Contains("invalid length", ex.Message);
    }
    
    [Theory]
    [InlineData("123$45")]
    [InlineData("12--45")]
    [InlineData("À23456")]
    [InlineData("!23456")]

    public void CreateWithInvalidCharacterThrowsArgumentException(string input)
    {
        var ex = Assert.Throws<ArgumentException>(() => Rego.Create(input));
        Assert.Contains("invalid character", ex.Message);
    }

    [Theory]
    [InlineData(" 12345")]
    [InlineData("12345 ")]
    [InlineData("1 3 56")]
    [InlineData("12  56")]
    [InlineData("     ")]
    [InlineData("      ")]
    public void CreateWithInvalidSpacesThrowsArgumentException(string input)
    {
        var ex = Assert.Throws<ArgumentException>(() => Rego.Create(input));
        Assert.Contains("invalid spaces", ex.Message);
    }

    [Fact]
    public void CreateWithNullRegoThrowsArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => Rego.Create(null!));
        Assert.Contains("input", ex.ParamName);
    }
    
    [Fact]
    public void CreateMatchingRegosAssertEquality()
    {
        Assert.Equal(Rego.Create("abc123"), Rego.Create("ABC123"));
    }
    
    [Fact]
    public void CreateNonMatchingRegosAssertNonEquality()
    {
        Assert.NotEqual(Rego.Create("ab 123"), Rego.Create("AB123"));
    }
}
