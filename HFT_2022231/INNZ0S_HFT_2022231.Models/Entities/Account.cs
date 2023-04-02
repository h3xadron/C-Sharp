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
    [Table("Accounts")]
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Account_Id { get; set; }
        public int Client_Id { get; set; }
        public double AccountSum { get; set; }
        public bool DebitCard { get; set; }
        public double DebitLimit { get; set; }
        public bool CreditCard { get; set; }
        public double CreditLimit { get; set; }
        public CreditCurrencyType CreditType { get; set; }
        public DebitCurrencyType DebitType { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Transaction> Transactions { get; set; }
        public Account()
        {

        }
        public Account(int account_Id, int client_Id, double accountSum, bool debitCard, double debitLimit, bool creditCard, double creditLimit, CreditCurrencyType creditType, DebitCurrencyType debitType)
        {
            Account_Id = account_Id;
            Client_Id = client_Id;
            AccountSum = accountSum;
            DebitCard = debitCard;
            DebitLimit = debitLimit;
            CreditCard = creditCard;
            CreditLimit = creditLimit;
            CreditType = creditType;
            DebitType = debitType;
        }
        public Account(int account_Id,Client client, double accountSum, bool debitCard, double debitLimit, bool creditCard, double creditLimit, CreditCurrencyType creditType, DebitCurrencyType debitType)
        {
            Account_Id = account_Id;
            Client_Id = client.Id;
            AccountSum = accountSum;
            DebitCard = debitCard;
            DebitLimit = debitLimit;
            CreditCard = creditCard;
            CreditLimit = creditLimit;
            CreditType = creditType;
            DebitType = debitType;
        }
        public enum CreditCurrencyType
        {
            none,
            standard,
            star,
            diamond
        }
        public enum DebitCurrencyType
        {
            none,
            standard,
            newcommer,
            blackcard
        }
        public override string ToString()
        {
            return $"Id: {Account_Id}; Client Id: {Client_Id}; AccountSum: {AccountSum}; DebitCard: {DebitCard}; DebitLimit: {DebitLimit}; CreditCard: {CreditCard}; CreditLimit: {CreditLimit}; CreditType: {CreditType.ToString()}; DebitType: {DebitType.ToString()}; ";
        }
    }
}
