namespace EntityVal
{
    public static class StringExtMethods
    {
        public static string FormatWith(this string s, params object[] args)
        {
            return string.Format(s, args);
        }

        public static string PascalCaseToTitleCase(this string s)
        {
            // TODO: use string builder
            
            var result = "";

            foreach (var c in s)
            {
                if (result != string.Empty && 'A' <= c && c <= 'Z')
                {
                    result += " ";
                }

                result += c;
            }
           
           return result;
        }
    }
}