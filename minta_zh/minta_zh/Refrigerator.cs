using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class Refrigerator
    {
        [DisplayName("Márka")]
        public string Brand { get; set; }
        [DisplayName("Kapacitás")]
        public int Capacity { get; set; }
        public List<Product> Products { get; set; }

    }
}
