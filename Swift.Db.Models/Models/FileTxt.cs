using Swift.Db.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swift.Db.Models
{
    public class FileTxt
    {
        public FileTxt()
        {
            this.Transactions = new HashSet<Transaction>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int TransactionCount { get; set; }
 
        public ICollection<Transaction> Transactions { get; set; }
    }
}