using Icard.Paths;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Icard.SwiftParse.TextBlock
{
    public class TextBlock : ITextBlock
    {
        private static readonly StringBuilder sb = new StringBuilder();
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Reason { get; set; } = "No reason added!!!";
        public string SenderName { get; set; }
        public string SenderBankAccount { get; set; }
        public string RecieverName { get; set; }
        public string RecieverBankAccount { get; set; }

        public void TextBlockParse(List<string> translations)
        {
            for (int i = 0; i < translations.Count; i++)
            {
                string curr = translations[i];
                if (Regex.IsMatch(curr, FolderPath.SWIFT_FORMAT_FIELDS))
                {
                    if (curr.StartsWith(":33B:"))
                    {
                       
                        NumberFormatInfo numberFormatComma = new NumberFormatInfo
                        {
                            NumberDecimalSeparator = ","
                        };
                        Currency = curr.Substring(5, 3);
                        Amount = decimal.Parse(curr.Substring(8, curr.Length - 8), numberFormatComma);
                    }
                    else if (curr.StartsWith(":50K:/"))
                    {
                       
                        SenderBankAccount = curr.Substring(6, curr.Length - 6);
                        SenderName = translations[i + 1];

                    }
                    else if (curr.StartsWith(":59:/"))
                    {
                   
                        RecieverBankAccount = curr.Substring(5, curr.Length - 5);
                        RecieverName = translations[i + 1];
                    }
                    else if (curr.StartsWith(":70:"))
                    {
                        
                        Reason = curr.Substring(4, curr.Length - 4);
                    }
                }
            }
        }
        public string ReturnTranslationText()
        {
            return sb.ToString().TrimEnd();
        }
    }
}