using DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;

        public CategoriesController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Insert(Categories categories) 
        {
            _databaseContext.Categories.Add(categories);
            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                BadRequest("Something went wrong");
            }

            return Ok(categories);
        }

        [HttpGet]
        public async Task<ActionResult<List<Categories>>> GetCategories()
        {
            try
            {
                return await _databaseContext.Categories.Where(cat => cat.Status == true).ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Categories>>> Update(Categories category)
        {
            try
            {
                var dbCategory = await _databaseContext.Categories.FindAsync(category.CategoriesID);
                if (dbCategory == null)
                {
                    return NotFound("Category does not exist");
                }

                dbCategory.Name = category.Name;
            }
            catch (Exception ex)
            {
                BadRequest("Something went wrong");
            }

            await _databaseContext.SaveChangesAsync();
            return Ok("The category has been updated");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var dbCategory = await _databaseContext.Categories.FindAsync(id);
                if (dbCategory == null)
                {
                    return NotFound("Category does not exist");
                }

                dbCategory.Status = false;
            }
            catch (Exception ex)
            {
                BadRequest("Something went wrong");
            }

            await _databaseContext.SaveChangesAsync();
            return Ok("The category has been deleted");
        }
    }
}
