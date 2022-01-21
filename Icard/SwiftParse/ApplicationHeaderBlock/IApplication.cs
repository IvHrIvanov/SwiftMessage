using System.Collections.Generic;

namespace Icard.SwiftParse.ApplicationHeaderBlock
{
    public interface IApplication
    {
        string BlockID { get; }
        string Input { get; set; }
        string MessageType { get; set; }
        string RecieverBIC { get; set; }
        string MessagePriority { get; set; }
        string Delivery { get; set; }
        string Period { get; set; }
        string Priority { get; set; }
        public List<IApplication> ParseMessageApplicationHeaderBlock(string swiftMessage);
       
    }
}