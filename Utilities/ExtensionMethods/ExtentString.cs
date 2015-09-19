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
            if (sourceText.Length >= maxLength)
                return sourceText;

            var sb = new StringBuilder(sourceText);       

            var iCurrentLength = sourceText.Length;
            while ((iCurrentLength) < maxLength)
            {
                iCurrentLength += filler.Length;
                sb.Append(filler);
            }

            sb.Remove(maxLength, iCurrentLength - maxLength);

            return sb.ToString();
        }

        public static String Center(this string sourceText, string filler, int maxLength)
        {
            if (sourceText.Length >= maxLength)
                return sourceText;

            var sb = new StringBuilder(sourceText);

            var iCurrentLength = sourceText.Length;
            var bToggle = false;

            while (iCurrentLength < maxLength)
            {
                bToggle ^= true;
                iCurrentLength += filler.Length;

                if (bToggle)
                    sb.Insert(0, filler);

                else
                    sb.Append(filler);
            }

            return sb.ToString();
        }

        public static String DecodeUrlString(this string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }
    }
}
