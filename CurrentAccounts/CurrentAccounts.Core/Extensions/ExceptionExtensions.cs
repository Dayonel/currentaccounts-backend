using System;

namespace CurrentAccounts.Core.Extensions
{
    public static class ExceptionExtensions
    {
        public static string Message(this Exception ex)
        {
            return $"{ex.Message}{GetSeparator()}{ex.InnerException}{GetSeparator()}{ex.StackTrace}";
        }

        private static string GetSeparator()
        {
            return $"{Environment.NewLine}========================================{Environment.NewLine}";
        }
    }
}
