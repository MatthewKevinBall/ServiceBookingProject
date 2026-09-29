namespace ServiceBooking.Domain.Vehicles;

using System.Linq;

public sealed record Rego
{
    public string Value { get; }

    private Rego(string value)
    {
        Value = value;
    }

    public static Rego Create(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        if (input.Length > 6 || input.Length < 5)
        {
            throw new ArgumentException("invalid length");
        }

        if (!CheckSpaces(input)) throw new ArgumentException("invalid spaces");
        
        foreach (char c in input)
        {
            if (!IsLetterDigitOrSpace(c)) throw new ArgumentException("invalid character");
        }
        
        string regoNormal = NormalizeName(input);
        return new Rego(regoNormal);
    }

    private static string NormalizeName(string input)
    {
        return input.ToUpperInvariant();
    }

    private static bool CheckSpaces(string input)
    {
        if (input[0] == ' ' || input[^1] == ' ')
        {
            return false;
        }
        int spaces = input.Count(c => c == ' ');
        return !(spaces > 1);
    }

    private static bool IsLetterDigitOrSpace(char c)
    {
        return ((char.IsLetterOrDigit(c) && char.IsAscii(c)) || c == ' ');
    }
}
