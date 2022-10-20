using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace minta_zh
{
    class Program
    {
        static void Main(string[] args)
        {
            Refrigerator refrigerator = GetData(@"C:\Users\Szeba\source\repos\minta_zh\minta_zh\frigo.xml");

        }

        static Refrigerator GetData(string file)
        {
            var XML = XDocument.Load(file);
            Refrigerator output = new Refrigerator();
            List<XAttribute> outputAttributes = XML.Element("refrigerator").Attributes().ToList();

            output.Brand = XML.Element("refrigerator").Attributes().Where(t => t.Name == "brand").Select(x => x.Value).FirstOrDefault();
            output.Capacity = int.Parse(XML.Element("refrigerator").Attributes().Where(t => t.Name == "capacity").Select(x => x.Value).FirstOrDefault());

            List<Product> outputProductList = new List<Product>();


            foreach (var item in XML.Descendants("products").Elements("product"))
            {
                Product temp = new Product()
                {
                    Name = item.Value,
                    Amount = int.Parse(item.Attributes().Where(t => t.Name == "amount").Select(x => x.Value).FirstOrDefault())
                };

                outputProductList.Add(temp);
            }

            output.Products = outputProductList;

            return output;
        }
    }
}