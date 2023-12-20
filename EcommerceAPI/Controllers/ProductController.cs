using DB;
using EcommerceAPI.Dtos;
using EcommerceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly DatabaseContext _dbContext;
        private readonly IAzureStorageService _azureStorageService;
        public ProductController(DatabaseContext dbContext, IAzureStorageService azureStorageService)
        {
            _dbContext = dbContext;
            _azureStorageService = azureStorageService;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Insert([FromForm] ProductRequestDTO productRequest)
        {
            try
            {
                var product = new Product
                {
                    Name = productRequest.Name,
                    Description = productRequest.Description,
                    Color = productRequest.Color,
                    LaunchDate = productRequest.LaunchDate,
                    Price = productRequest.Price,
                    UnitsInStock = productRequest.UnitsInStock,
                    BrandID = productRequest.BrandID,
                    CategoriesID = productRequest.CategoriesID,
                    Status = true,
                };

                if (productRequest.Image != null)
                {
                    product.ImagePath = await _azureStorageService.UploadAsync(productRequest.Image, "images");
                }

                if (productRequest.Characteristics != null)
                {
                    List<Characteristic> newCharacteristics = new List<Characteristic>();
                    foreach (CharacteristicRequestDTO characteristic in productRequest.Characteristics)
                    {
                        var newCharacteristic = new Characteristic
                        {
                            Value = characteristic.Value,
                            ProductID = product.ProductID,
                        };
                        //_dbContext.Characteristic.Add(newCharacteristic);
                        //product.Characteristics.Add(newCharacteristic);
                        newCharacteristics.Add(newCharacteristic);
                        //_dbContext.Characteristic.Add(newCharacteristic);

                    }
                    product.Characteristics = newCharacteristics;
                }

                _dbContext.Add(product);
                _dbContext.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
                return await _dbContext.Product.Where(product => product.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update([FromRoute] int id, [FromForm] ProductRequestDTO productRequestDTO)
        {
            try
            {
                var product = _dbContext.Product.Find(id);

                if (product != null)
                {
                    product.BrandID = productRequestDTO.BrandID;
                    //product.Characteristics = productRequestDTO.Characteristics;
                    product.CategoriesID = productRequestDTO.CategoriesID;
                    product.Color = productRequestDTO.Color;
                    product.Description = productRequestDTO.Description;
                    product.UnitsInStock = productRequestDTO.UnitsInStock;
                    product.Price = productRequestDTO.Price;
                    product.LaunchDate = productRequestDTO.LaunchDate;
                }

                if (productRequestDTO.Image != null)
                {
                    product.ImagePath = await _azureStorageService.UploadAsync(productRequestDTO.Image, "images", product.ImagePath);
                }

                _dbContext.Update(product);
                _dbContext.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var product = await _dbContext.Product.FindAsync(id);

                if (product == null)
                {
                    return NotFound("The Product does not exist");
                }

                product.Status = false;
            }
            catch (Exception ex)
            {
                BadRequest("Something went wrong");
            }

            await _dbContext.SaveChangesAsync();
            return Ok("The Product has been deleted");
        }


    }
}
