using System.Collections.Generic;

namespace Icard.SwiftParse
{
    public interface IBasicBlock
    {
        string BlockId { get; }
        string ApplicationID { get; set; }
        string ServiceId { get; set; }
        string SenderBIC { get; set; }
        string SessionNumber { get; set; }
        string SequenceNumber { get; set; }
        List<IBasicBlock> ParseMessageBasicHeaderBlock(string swiftMessage);
    }
}