namespace EntityVal
{
    public class MinAttribute : ValidationAttribute
    {
        public int MinValue { get; }

        public string Message { get; }

        public MinAttribute(int minValue, string message = null)
        {
            MinValue = minValue;
            Message = message;
        }
    }
}