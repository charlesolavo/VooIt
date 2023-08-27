namespace VooIt.Domain.Models;

public class ErrorResponse
{
    public ErrorResponse()
    {
        Messages = new List<string> { };
    }

    public ErrorResponse(string message)
    {
        Messages = new List<string> { message };
    }

    public ErrorResponse(List<string> messages)
    {
        Messages = messages;
    }

    public IList<string> Messages { get; private set; }
}
