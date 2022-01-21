using Icard.Paths;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Icard.SwiftParse.ApplicationHeaderBlock
{
    public class ApplicationHeader : IApplication
    {
        private string result = "";

        private static readonly List<IApplication> applicationHeader = new List<IApplication>();
        private static ApplicationHeader application = new ApplicationHeader();

        public string BlockID { get { return FolderPath.BLOCK_ID_2; } }
        public string Input { get; set; }
        public string MessageType { get; set; }
        public string RecieverBIC { get; set; }
        public string MessagePriority { get; set; }
        public string Delivery { get; set; }
        public string Period { get; set; }
        public string Priority { get; set; }

        public List<IApplication> ParseMessageApplicationHeaderBlock(string swiftMessage)
        {

            var matchInput = Regex.Match(swiftMessage, FolderPath.INPUT_PATTERN);
            var matchOutput = Regex.Match(swiftMessage, FolderPath.OUTPUT_PATTERN);
            var address = Regex.Match(swiftMessage, FolderPath.SENDER_ADDRESS);

            if (matchInput.Success)
            {

                Input = matchInput.Groups[1].Value;
                MessageType = matchInput.Groups[2].Value;
                RecieverBIC = address.Value;
                MessagePriority = matchInput.Groups[4].Value;
                Delivery = matchInput.Groups[5].Value;
                Period = matchInput.Groups[6].Value;

                applicationHeader.Add(new ApplicationHeader
                {
                    Input = matchInput.Groups[1].Value,
                    MessageType = matchInput.Groups[2].Value,
                    RecieverBIC = address.Value,
                    MessagePriority = matchInput.Groups[4].Value,
                    Delivery = matchInput.Groups[5].Value,
                    Period = matchInput.Groups[6].Value
                });
                AddParsetDataApplicationBlockInput(applicationHeader);
            }
            else if (matchOutput.Success)
            {

                Input = matchOutput.Groups[2].Value;
                MessageType = matchOutput.Groups[3].Value;
                RecieverBIC = address.Value;
                MessagePriority = matchOutput.Groups[5].Value;
                Delivery = matchOutput.Groups[6].Value;
                Period = matchOutput.Groups[7].Value;
                Priority = matchOutput.Groups[8].Value;

                applicationHeader.Add(new ApplicationHeader
                {
                    Input = matchOutput.Groups[2].Value,
                    MessageType = matchOutput.Groups[3].Value,
                    RecieverBIC = address.Value,
                    MessagePriority = matchOutput.Groups[5].Value,
                    Delivery = matchOutput.Groups[6].Value,
                    Period = matchOutput.Groups[7].Value,
                    Priority = matchOutput.Groups[8].Value
                });
                AddParsetDataApplicationBlockOutput(applicationHeader);
            }
            return applicationHeader;
        }
        private void AddParsetDataApplicationBlockInput(List<IApplication> aplicationHeader)
        {
            foreach (var item in aplicationHeader)
            {
                result = string.Concat(
                    item.BlockID.ToString(),
                    item.Input.ToString(),
                    item.RecieverBIC.ToString(),
                    item.MessageType.ToString(),
                    item.MessagePriority.ToString(),
                    item.Delivery.ToString(),
                    item.Period.ToString()
                    );
            }
        }
        private void AddParsetDataApplicationBlockOutput(List<IApplication> aplicationHeader)
        {
            foreach (var item in aplicationHeader)
            {
                result = string.Concat(
                    item.BlockID.ToString(),
                    item.Input.ToString(),
                    item.RecieverBIC.ToString(),
                    item.MessageType.ToString(),
                    item.MessagePriority.ToString(),
                    item.Delivery.ToString(),
                    item.Period.ToString(),
                    item.Priority.ToString()
                    );
            }
        }
        public ApplicationHeader ReturnApplicationHeaderBlock()
        {
            return application;
        }
        public string ReturnResult()
        {
            return result;
        }
    }
}