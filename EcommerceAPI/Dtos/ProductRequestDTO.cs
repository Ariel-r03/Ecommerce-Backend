using DB;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace EcommerceAPI.Dtos
{
    public class ProductRequestDTO
    {

        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Color { get; set; }

        public DateTime? LaunchDate { get; set; }
        public float Price { get; set; }
        public int UnitsInStock { get; set; }

        public int BrandID { get; set; }
        public ICollection<CharacteristicRequestDTO> Characteristics { get; set; }
        public int CategoriesID { get; set; }
        /*[MaxFileSize(1 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]*/
        public IFormFile Image { get; set; }
    }
}
