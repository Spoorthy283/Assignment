using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreItem_NutidAB.Model
{
    public class StoreItemDescription
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int LandId { get; set; }
        public string Description { get; set; }
    }
}
