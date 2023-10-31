using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Common.DTOs.Master
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string? ProductName { get; set; }

        public string ProductDescription { get; set; }
        public string ProductCateogry { get; set; }
        public bool IsActive { get; set; }

    }
}



