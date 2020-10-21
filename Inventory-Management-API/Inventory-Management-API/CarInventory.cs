using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management_API
{
    public class CarInventory
    {
        public int InventoryId { get; set; }
        public string CarName { get; set; }

        public string Model { get; set; }

        public int StockQty { get; set; }
    }
}
