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
    [PrimaryKey(nameof(orderID), nameof(productID))]
    public class OrderDetail
    {
        public int orderID { get; set; }
        public int productID { get; set; }

        [ForeignKey("orderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("productID")]
        public virtual Product Product { get; set; }

        public int quantity { get; set; }
        public decimal price { get; set; }

        public decimal? discount { get; set; }

        public bool? status { get; set; }


    }
}
