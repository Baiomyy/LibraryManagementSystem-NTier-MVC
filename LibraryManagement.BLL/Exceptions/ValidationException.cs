namespace LibraryManagement.BLL.Exceptions;

public class ValidationException : Exception
{
    public string PropertyName { get; }
    public string ErrorMessage { get; }

    public ValidationException(string propertyName, string errorMessage)
        : base(errorMessage)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }
}