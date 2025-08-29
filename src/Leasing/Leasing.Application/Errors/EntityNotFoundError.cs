using FluentResults;

namespace Leasing.Application.Errors
{
    public class EntityNotFoundError(string message) : Error(message)
    {
     
    }
}
