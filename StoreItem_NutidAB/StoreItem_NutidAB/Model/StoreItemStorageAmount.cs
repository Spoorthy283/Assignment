using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreItem_NutidAB.Model
{
    public class StoreItemStorageAmount
    {
        public int Id { get; set; }
        public StorageSpot storagespot { get; set; }
        public decimal Amount { get; set; }
    }
}
