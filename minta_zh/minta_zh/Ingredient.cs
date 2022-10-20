using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minta_zh
{
    /*
    * CodeFirst módszerrel hozza létre az előző pontban létrehozott adatbázisban a Receipts és Ingredients táblákat (3 pont)
    */
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        public int Amount { get; set; }
        public int ReceiptId { get; set; }

        //Navigation property Ezzel lehet lazy loadolni
        public virtual Receipt Receipt { get; set; }

        //Konstruktor
        public Ingredient()
        {

        }
        public Ingredient(int id, string name, int amount, int receiptId)
        {
            Id = id;
            Name = name;
            Amount = amount;
            ReceiptId = receiptId;
        }
        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name}; Amount: {Amount}; ReceipID: {ReceiptId}";
        }
    }
}
