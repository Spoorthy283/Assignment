using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreItem_NutidAB.Model
{
    public class StoreItem
    {
        public StoreItem()
        {
            StoreItemDescriptions = new List<StoreItemDescription>();
            StoreItemPrices = new List<StoreItemPrice>();
            StoreItemStorageAmounts = new List<StoreItemStorageAmount>();
            StoreDepartment = new StoreDepartment();
            Unit = new Unit();
        }
       // public StoreItem()
        public int Id { get; set; }
        public int ItemId { get; set; }
        public List<StoreItemDescription> StoreItemDescriptions { get; set; }
        public List<StoreItemPrice> StoreItemPrices { get; set; }
        public StoreDepartment StoreDepartment { get; set; }
        public string Barcode { get; set; }
        public List<StoreItemStorageAmount> StoreItemStorageAmounts { get; set; }
        public string ItemNumber { get; set; }
        public string CatalogNumber { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Extra5 { get; set; }
        public string Extra6 { get; set; }
        public string Extra7 { get; set; }
        public string Extra8 { get; set; }
        public string Extra9 { get; set; }
        public string Extra10 { get; set; }
        public string Extra11 { get; set; }
        public string Extra12 { get; set; }
        public Unit Unit { get; set; }
        public bool Deleted { get; set; }
    }
}
