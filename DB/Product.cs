using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productID { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }

        public string? color { get; set; }
        public string? image { get; set; }
        public DateTime? LaunchDate { get; set; }
        public float price { get; set; }

        [ForeignKey("brandID")]
        public int brandID { get; set; }
        public virtual Brand Brand { get; set; }

        [ForeignKey("characteristicID")]
        public int characteristicID { get; set; }
        public virtual Characteristic Characteristic { get; set; }

        [ForeignKey("categoriesID")]
        public int categoriesID { get; set; }
        public virtual Categories Categories { get; set; }
        public bool? status { get; set; }


    }
}
