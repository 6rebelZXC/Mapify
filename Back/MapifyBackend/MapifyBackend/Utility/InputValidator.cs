using MapifyBackend.Controllers;
using MapifyBackend.Utility.DTOs;

namespace MapifyBackend.Utility;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
}

public static class InputValidator
{
    private static void ValidateString(string value, string fieldName, int maxLength = 500)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException($"{fieldName} is required");

        if (value.Length > maxLength)
            throw new ValidationException($"{fieldName} must be less than {maxLength} characters");
    }

    public static void ValidateStratRequest(StratRequest request)
    {
        ValidateString(request.Name, "Name", 100);
        ValidateString(request.VideoUrl, "VideoUrl", 500);
        ValidateString(request.MapName, "MapName", 100);
    }

    public static void ValidateCategoryRequest(CategoryRequest request)
    {
        ValidateString(request.Name, "Name", 100);
        ValidateString(request.Side, "Side", 7);
        if (request.Side != "Attack" && request.Side != "Defense")
        {
            throw new ValidationException("Side must be only 'Attack' or 'Defense'");
        }
    }
}