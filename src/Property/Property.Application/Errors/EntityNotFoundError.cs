using FluentResults;

namespace Property.Application.Errors
{
    public class EntityNotFoundError(string message) : Error(message)
    {
     
    }
}
