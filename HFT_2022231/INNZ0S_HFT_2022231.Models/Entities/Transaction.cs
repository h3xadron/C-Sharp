using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace INNZ0S_HFT_2022231.Models.Entities
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Transaction_Id { get; set; }
        [Required]
        public int Account_Id { get; set; }
        public DateTime CreditTransactionTime { get; set; }
        public int CreditTransaction { get; set; }
        public DateTime DebitTransactionTime { get; set; }
        public int DebitTransaction { get; set; }
        public DateTime CashTime { get; set; }
        public int Cash { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        public Transaction()
        {

        }
        public Transaction(int transaction_Id, int account_Id, DateTime creditTransactionTime, int creditTransaction, DateTime debitTransactionTime, int debitTransaction, DateTime cashTime, int cash)
        {
            Transaction_Id = transaction_Id;
            Account_Id = account_Id;
            CreditTransactionTime = creditTransactionTime;
            CreditTransaction = creditTransaction;
            DebitTransactionTime = debitTransactionTime;
            DebitTransaction = debitTransaction;
            CashTime = cashTime;
            Cash = cash;
        }

        public Transaction(int transaction_Id, Account account, DateTime creditTransactionTime, int creditTransaction, DateTime debitTransactionTime, int debitTransaction, DateTime cashTime, int cash)
        {
            Transaction_Id = transaction_Id;
            Account_Id = account.Account_Id;
            CreditTransactionTime = creditTransactionTime;
            CreditTransaction = creditTransaction;
            DebitTransactionTime = debitTransactionTime;
            DebitTransaction = debitTransaction;
            CashTime = cashTime;
            Cash = cash;
        }
        public override string ToString()
        {
            return $"Id: {Transaction_Id}; Account Id: {Account_Id}; CreditTransactionTime: {CreditTransactionTime.ToString()}; CreditTransaction: {CreditTransaction}; DebitTransactionTime: {DebitTransactionTime.ToString()}; DebitTransaction: {DebitTransaction}; CashTime: {CashTime}; Cash: {Cash};";
        }
    }
}
