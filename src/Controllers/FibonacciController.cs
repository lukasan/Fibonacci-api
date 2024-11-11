namespace Fibonacci.Controllers;

using Fibonacci.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class FibonacciController(ILogger<FibonacciController> logger)
    : ControllerBase
{
    [HttpGet("{n}")]
    public IActionResult GetFibonacci(int n)
    {
        try
        {
            var result = FibonacciService.CalculateFibonacci(n);
            return Ok(result.ToString());
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}