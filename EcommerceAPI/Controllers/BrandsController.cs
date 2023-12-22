using DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public BrandsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Insert(Brand brand)
        {
            _databaseContext.Brand.Add(brand);
            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok(brand);
        }

        [HttpGet]
        public async Task<ActionResult<List<Brand>>> GetBrands()
        {
            try
            {
                return await _databaseContext.Brand.Where(brand => brand.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Brand>>> Update(Brand brand)
        {
            try
            {
                var dbBrand = await _databaseContext.Brand.FindAsync(brand.BrandID);
                if (dbBrand == null)
                {
                    return NotFound("Brand does not exist");
                }

                dbBrand.Name = brand.Name;
            }
            catch (Exception ex)
            {
                BadRequest("Something went wrong");
            }

            await _databaseContext.SaveChangesAsync();
            return Ok("The brand has been updated");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var dbBrand = await _databaseContext.Brand.FindAsync(id);
                if (dbBrand == null)
                {
                    return NotFound("Brand does not exist");
                }

                dbBrand.Status = false;
            }
            catch (Exception ex)
            {
                BadRequest("Something went wrong");
            }

            await _databaseContext.SaveChangesAsync();
            return Ok("The brand has been deleted");
        }
    }
}
