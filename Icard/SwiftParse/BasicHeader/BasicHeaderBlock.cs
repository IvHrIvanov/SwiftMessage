using Icard.Paths;
using Icard.SwiftParse;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Icard
{
    public class BasicHeaderBlock : IBasicBlock
    {
        private string result = "";

        public string ApplicationID { get; set; }
        public string ServiceId { get; set; }
        public string SenderBIC { get; set; }
        public string SessionNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string BlockId { get { return FolderPath.BLOCK_ID_1; } }

        public List<IBasicBlock> ParseMessageBasicHeaderBlock(string swiftMessage)//Parse the current message
        {
            List<IBasicBlock> basicHeaderBlock = new List<IBasicBlock>();

            var match = Regex.Match(swiftMessage, FolderPath.BASIC_HEADER_PATTERN);
            if (match.Success)
            {
             
                ApplicationID = match.Groups[2].Value;
                ServiceId = match.Groups[3].Value;
                SenderBIC = match.Groups[4].Value;
                SessionNumber = match.Groups[5].Value;
                SequenceNumber = match.Groups[6].Value;
                basicHeaderBlock.Add(new BasicHeaderBlock
                {
                    ApplicationID = match.Groups[2].Value,
                    ServiceId = match.Groups[3].Value,
                    SenderBIC = match.Groups[4].Value,
                    SessionNumber = match.Groups[5].Value,
                    SequenceNumber = match.Groups[6].Value
                });
                ConverToString(basicHeaderBlock);
            }
           
            return basicHeaderBlock;

        }
        private void ConverToString(List<IBasicBlock> basicHeaderBlock)
        {
            foreach (var item in basicHeaderBlock)
            {
                result = string.Concat(
                    item.BlockId.ToString(),
                    item.ApplicationID.ToString(),
                    item.ServiceId.ToString(),
                    item.SenderBIC.ToString(),
                    item.SessionNumber.ToString(),
                    item.SequenceNumber.ToString()
                    );
            }
        }
        public string ReturnResult()
        {
            return result;
        }
    }
}