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
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Color { get; set; }
        public string? Image { get; set; }

        public DateTime? LaunchDate { get; set; }
        public float Price { get; set; }

        [ForeignKey("BrandID")]
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }

        public ICollection<Characteristic> Characteristics { get; set; }

        [ForeignKey("CategoriesID")]
        public int CategoriesID { get; set; }
        public virtual Categories Categories { get; set; }
        public bool? Status { get; set; }


    }
}
