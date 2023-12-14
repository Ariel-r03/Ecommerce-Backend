using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    [PrimaryKey(nameof(OrderID), nameof(ProductID))]
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public bool? Status { get; set; }


    }
}
