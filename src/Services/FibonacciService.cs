namespace Fibonacci.Services;

using System.Numerics;

public static class FibonacciService
{
    /// <inheritdoc cref="FibonacciDoubling(int)"/>
    public static BigInteger CalculateFibonacci(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Index must be a non-negative integer.");
        }
        
        return FibonacciDoubling(n).Item1;
    }

    /// <summary>
    /// Calculate Fibonacci sequence using fast doubling.
    /// </summary>
    /// <param name="n">Fibonacci index</param>
    /// <returns>Fibonacci number</returns>
    private static (BigInteger, BigInteger) FibonacciDoubling(int n)
    {
        if (n == 0)
        {
            return (0, 1);
        }

        var (a, b) = FibonacciDoubling(n / 2);
        var c = a * ((2 * b) - a);
        var d = (a * a) + (b * b);

        return (n % 2 == 0) ? (c, d) : (d, c + d);
    }

    // TODO paralellism
    // TODO result caching (Memoization), hash table database?
}

