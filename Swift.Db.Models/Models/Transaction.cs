using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swift.Db.Models.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0,15)]
        public decimal Amount { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        [MaxLength(60)]
        public string SenderName { get; set; }
        [Required]
        [MaxLength(12)]
        public string BICSender { get; set; }

        [Required]
        public string SenderBankAccount { get; set; }

        [Required]
        [MaxLength(60)]
        public string RecieverName { get; set; }

        [Required]
        [MaxLength(12)]
        public string BICReciever { get; set; }
        [Required]
        public string RecieverBankAccount { get; set; }
        [Required]
        [MaxLength(35)]
        public string Reason { get; set; }

        [ForeignKey(nameof(File))]
        public int FileId { get; set; }
        public FileTxt File { get; set; }
    }
}