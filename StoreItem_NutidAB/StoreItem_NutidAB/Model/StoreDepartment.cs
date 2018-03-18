using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreItem_NutidAB.Model
{
    public class StoreDepartment
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int storeId { get; set; }
        public bool Sales { get; set; }
        public List<StoreDepartmentName> StoreDepartmentNames { get; set; }
        public string account { get; set; }
        public string IncomeAccount { get; set; }
        public string SalesAccount { get; set; }
        public bool Vmb { get; set; }
        public string SpcsAccount { get; set; }
    }
}
