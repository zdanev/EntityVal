namespace EntityVal
{
    public class ValidationError
    {
        public string FieldName { get; }
        public string Message { get; }

        public ValidationError(string fieldName, string message)
        {
            FieldName = fieldName;
            Message = message;
        }
    }
}