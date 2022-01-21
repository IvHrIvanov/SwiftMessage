using Swift.Db.Models.Models;

namespace Swift.Initializator.InsertDataToDB
{
    public class TransactionCreate
    {
        private static Transaction transaction = new Transaction();
      
        public static Transaction TransactionCreated(
            decimal amount, string currency, string reason,
            string senderName, string senderBIC, string senderBankAccount,
            string recieverName, string recieverBIC, string recieverBankAccount)
        {
            transaction = new Transaction()
            {
                Amount = amount,
                Currency = currency,
                Reason = reason,
                SenderName = senderName,
                BICSender = senderBIC,
                SenderBankAccount = senderBankAccount,
                RecieverName = recieverName,
                BICReciever = recieverBIC,
                RecieverBankAccount = recieverBankAccount
            };
           
            return transaction;
        }
    }
}