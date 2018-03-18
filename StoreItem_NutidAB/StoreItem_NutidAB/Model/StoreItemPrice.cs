using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreItem_NutidAB.Model
{
    public class StoreItemPrice
    {
        public int Id { get; set; }
        public int LandId { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
