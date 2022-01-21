using Swift.Db;
using Swift.Db.Models;
using Swift.Db.Models.Models;
using Swift.Initializator.InsertDataToDB;
using System;
using System.Collections.Generic;

namespace Icard.FileObject
{
    public class FileCreated
    {
        private static FileTxt fileTxt = new FileTxt();
        public static void FileCreate(string fileName, DateTime time, List<Transaction> transaction)
        {
            fileTxt = new FileTxt
            {
                Name = fileName,
                Time = time,
                TransactionCount = transaction.Count,
                Transactions = transaction
            };

            InsertData.FileTxtSeed(fileTxt);
        }

        public static FileTxt ReturnFile()
        {
            return fileTxt;
        }
    }
}