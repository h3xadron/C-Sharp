using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class Product
    {
        [DisplayName("Termék neve")]
        public string Name { get; set; }
        [DisplayName("Termék mennyisége")]
        public int Amount { get; set; }

    }
}
