using System;
using System.Text;

namespace Utilities.ExtensionMethods
{
    public static class ExtentString
    {
        public static Boolean IsNullOrEmpty(this string text)
        {
            return String.IsNullOrEmpty(text);
        }

        public static Boolean IsNullOrWhitespace(this string text)
        {
            return String.IsNullOrWhiteSpace(text);
        }

        public static String RemoveAll(this string sourceText, string findText)
        {
            while (sourceText.Contains(findText))
                sourceText = sourceText.Remove(sourceText.IndexOf(findText, StringComparison.Ordinal), findText.Length);

            return sourceText;
        }

        public static String Fill(this string sourceText, string filler, int maxLength)
        {
            var sb = new StringBuilder(sourceText);

            if (sourceText.Length >= maxLength)
                return sb.ToString();

            var iCurrentLength = sourceText.Length;
            while ((iCurrentLength) < maxLength)
            {
                iCurrentLength += filler.Length;
                sb.Append(filler);
            }

            sb.Remove(maxLength, iCurrentLength - maxLength);

            return sb.ToString();
        }
    }
}
