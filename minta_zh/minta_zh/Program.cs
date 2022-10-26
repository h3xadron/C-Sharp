using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace minta_zh
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("ConsolApp Run");

            var DbContent = new FoodRecieptsDbContext();

            System.Console.WriteLine("DB initialized!");

            var receipt = DbContent.Receipts;
            var ingredeintList = DbContent.Ingredients;

            //System.Console.WriteLine(AttributeHelper.GetPropertyDisplayName<Product>(nameof(Product.Name)));
            Refrigerator refrigerator = GetData(@"C:\Users\Szeba\source\repos\minta_zh\minta_zh\frigo.xml");

            #region Recept mennyiség
            Console.WriteLine("\nReceptek száma:");
            int CountOfReceipt = receipt.Count();
            System.Console.WriteLine(CountOfReceipt);
            #endregion

            #region Csajozós Receptek
            System.Console.WriteLine("\nCsajozós receptek:");
            var SeductiveFoodName =
                 receipt.Where(x => x.IsSeductive == true)
                 .Select(x => x.Name).ToList();
            foreach (var item in SeductiveFoodName)
            {
                System.Console.WriteLine(item);
            }
            #endregion


            System.Console.WriteLine("\nRecept Olajjal Árszerint");
            var ReceiptWithOil =
                receipt.Where(x => x.Ingredients.FirstOrDefault(y => y.Name == "Olaj") != null).OrderByDescending(x => x.Price).Select(x => x.Name);
            foreach (var item in ReceiptWithOil)
            {
                System.Console.WriteLine(item);
            }


            Console.WriteLine("\n Összes recepet elkészítése");
            var AllRecept =
                ingredeintList.GroupBy(x => x.Name, y => y.Amount, (name, amounts) => new
                {
                    Name = name,
                    Amount = amounts.Sum()
                }).OrderBy(x => x.Amount);
            foreach (var item in AllRecept)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("\n Hűtő tartalma");
            foreach (var item in refrigerator.Products)
            {
                Console.WriteLine($"{AttributeHelper.GetPropertyDisplayName<Product>(nameof(Product.Name))} : {item.Name},  {AttributeHelper.GetPropertyDisplayName<Product>(nameof(Product.Amount))} : {item.Amount}");
            }
        }
        static Refrigerator GetData(string file)
        {
            var XML = XDocument.Load(file);
            Refrigerator output = new Refrigerator();
            //List<XAttribute> outputAttributes = XML.Element("refrigerator").Attributes().ToList();

            //output.Brand =XML.Element("refrigerator").Element("brand").Value;

             output.Brand = XML.Element("refrigerator")
              .Attributes()
              .Where(t => t.Name == "brand")
              .Select(x => x.Value)
              .FirstOrDefault();

            output.Capacity =
                int.Parse(XML.Element("refrigerator")
                .Attributes()
                .Where(t => t.Name == "capacity")
                .Select(x => x.Value)
                .FirstOrDefault());

            List<Product> outputProductList = new List<Product>();


            foreach (var item in XML.Descendants("products").Elements("product"))
            {
                Product temp = new Product()
                {
                    Name = item.Value,
                    Amount =
                        int.Parse(item.Attributes()
                        .Where(t => t.Name == "amount")
                        .Select(x => x.Value)
                        .FirstOrDefault())
                };

                outputProductList.Add(temp);
            }

            output.Products = outputProductList;

            return output;
        }
    }

}