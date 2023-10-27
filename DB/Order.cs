using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderID { get; set; }
        public DateTime date { get; set; }
        public decimal total { get;set; }
        [ForeignKey("userID")]
        public int userID { get; set; }
        public virtual User User { get; set; }

        public bool? status { get; set; }

    }
}
