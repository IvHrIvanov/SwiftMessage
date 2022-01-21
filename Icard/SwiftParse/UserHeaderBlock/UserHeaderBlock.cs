using Icard.Paths;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Icard.SwiftParse.UserHeaderBlock
{
    public class UserHeaderBlock : IUserHeaderBlock
    {
        public string BlockId { get { return FolderPath.BLOCK_ID_3; } }
        public string BankingPriorityCode { get; set; }
        public string MessageUserReferenc { get; set; }

        private static List<IUserHeaderBlock> messages;

        private static List<string> allMessages;
        public void ParseMessageUserHeaderBlock(string swiftMessages) // Parse messages to List<string>
        {
            messages = new List<IUserHeaderBlock>();
            allMessages = new List<string>();
            string subString = swiftMessages.Substring(3, swiftMessages.Length - 4);
            for (int i = 0; i < subString.Length; i++) // I use for loop and substring to take the fields one by one
            {
                string result = "";
                string currentString = subString[i].ToString();
                if (currentString == "{")
                {
                    for (int a = i; a < subString.Length; a++)
                    {
                        result += subString[a];
                        if (subString[a] == '}')
                        {
                            allMessages.Add(result);
                            break;
                        }
                    }
                }
            }
            AddMessageToUserHeaderBlockList();
        }
        public List<IUserHeaderBlock> ReturnAllMessages()
        {
            return messages;
        }

        private static void AddMessageToUserHeaderBlockList()
        {
            foreach (var currentMessage in allMessages)
            {
                var match = Regex.Match(currentMessage, FolderPath.USER_HEADER_REGEX);
                if (match.Success)
                {
                    for (int i = 1; i < match.Length; i++)// When the Regex have match and have empty groups i skip them and pick only groups with value
                    {
                        if (match.Groups[i].Value != "")
                        {
                            messages.Add(new UserHeaderBlock
                            {
                                BankingPriorityCode = match.Groups[i].Value,
                                MessageUserReferenc = match.Groups[i + 1].Value

                            });
                            break;
                        }
                    }
                }
                else
                {
                    messages = new List<IUserHeaderBlock>();
                    break;
                }
            }
        }
    }
}