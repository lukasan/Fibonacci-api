# Fibonacci-api
A .NET web API for serving a Fibonacci number.

## Implementation

The implementation supports **any** size number. Using `BigInteger` and fast multiplication, the computing time is not too bad.

## Usage
To use the API, run the project and access `/fibonacci` endpoint. Calling:
```
/fibonacci/10
```
would result in a response of a plain number `55`.

### Further development
The solution can be improved by:
* Adding async operations (Hangfire, queues)
* Adding parallelism
* Adding caching / distributed cache

This would result in a more sustainable API consumption in this particular case.

Also for general improvements:
* Serilog
* Custom exception handling
* Standartised resposne model
