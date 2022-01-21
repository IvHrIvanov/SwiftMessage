using System.Collections.Generic;

namespace Icard.SwiftParse.TextBlock
{
    public interface ITextBlock
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Reason { get; set; } 
        public string SenderName { get; set; }
        public string SenderBankAccount { get; set; }
        public string RecieverName { get; set; }
        public string RecieverBankAccount { get; set; }

        public void TextBlockParse(List<string> translations);
        
    }
}