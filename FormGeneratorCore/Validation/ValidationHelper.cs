using System;

namespace FormGenerator.Core.Validation
{
    public static class ValidationHelper
    {
        public static string FixClassNames(string inputClassNames)
        {
            string result = inputClassNames.Replace(" invalid", " is-invalid");

            if (inputClassNames.Contains("modified"))
            {
                result = result.Replace(" valid", " is-valid");
            }

            return result;
        }
    }
}
