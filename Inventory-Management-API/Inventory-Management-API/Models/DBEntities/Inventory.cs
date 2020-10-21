using System;
using System.Collections.Generic;

namespace Inventory_Management_API.Models.DbEntities
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public string CarName { get; set; }
        public string Model { get; set; }
        public int StockQty { get; set; }
    }
}
