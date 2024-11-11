namespace Fibonacci.Tests;

using Fibonacci.Services;
using System.Numerics;
using Xunit;

public class FibonacciServiceTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 5)]
    [InlineData(10, 55)]
    [InlineData(20, 6765)]
    [InlineData(50, 12586269025)]
    public void CalculateFibonacci_ValidInput_ReturnsCorrectResult(int input, long expected)
    {
        // Act
        var result = FibonacciService.CalculateFibonacci(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculateFibonacci_AboveInt64Boundary_ReturnsCorrectResult()
    {
        // Arrange
        int input = 93; // Fibonacci(93) exceeds Int64.MaxValue
        var expected = new BigInteger(12200160415121876738);
        // Act
        var result = FibonacciService.CalculateFibonacci(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CalculateFibonacci_NegativeInput_ThrowsArgumentException()
    {
        // Arrange
        int negativeInput = -1;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => FibonacciService.CalculateFibonacci(negativeInput));
    }

    [Fact]
    public void CalculateFibonacci_MaxInt64Boundary_ReturnsCorrectResult()
    {
        // Arrange
        int input = 92; // the largest Fibonacci number within the range of long
        long expected = 7540113804746346429;

        // Act
        var result = FibonacciService.CalculateFibonacci(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(93, "12200160415121876738")]
    [InlineData(1000, "43466557686937456435688527675040625802564660517371780402481729089536555417949051890403879840079255169295922593080322634775209689623239873322471161642996440906533187938298969649928516003704476137795166849228875")]
    public void CalculateFibonacci_VeryLargeInput_ReturnsCorrectResult(int input, string expectedStr)
    {
        // Arrange
        BigInteger expected = BigInteger.Parse(expectedStr);

        // Act
        var result = FibonacciService.CalculateFibonacci(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
