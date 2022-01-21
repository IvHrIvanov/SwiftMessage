using Swift.Db;
using Swift.Db.Models;

namespace Swift.Initializator.InsertDataToDB
{
    public class InsertData
    {
        private static readonly SwiftContext context = new SwiftContext();
        public static void FileTxtSeed(FileTxt fileData)
        {
            context.FilesTxts.AddRange(fileData);
            context.SaveChanges();        
        }     
    }
}