using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minta_zh
{
    [Table("Receipts")]
    public class Receipt
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsSeductive { get; set; }

        //Navigation property Ezzel lehet lazy loadolni
        //Azért IEnumerable mert több elemhez tartozik
        public virtual IEnumerable<Ingredient> Ingredients { get; set; }

        //Konstruktor
        public Receipt()
        {

        }
        public Receipt(int id, string name, int price, bool isSeductive)
        {
            Id = id;
            Name = name;
            Price = price;
            IsSeductive = isSeductive;
        }
        // Ez ellenőrzéshez hasznos DE kilehet hagyni.
        public override string ToString()
        {
            return $"ID: {Id}; Name: {Name}";
        }
    }
}
