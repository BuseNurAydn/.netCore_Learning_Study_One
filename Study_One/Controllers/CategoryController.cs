using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study_One.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study_One.Controllers
{ 
        [Route("api/[controller]")]
        [ApiController]
        public class CategoryController : ControllerBase
        {
            private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;

            // Seed the database with sample data
            if (_context.Categories.Count() == 0)
            {
                _context.Categories.Add(new Category { Title = "Web Geliştirme", Description = "HTML,React.js" });
                _context.Categories.Add(new Category { Title = "Android Geliştirme", Description = "Kotlin" });
                _ = _context.SaveChanges();
            }

        }



            //Tüm kategorileri listelemek için 
            // GET: api/category
            [HttpGet]   //get isteği
            public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
            {
                return await _context.Categories.ToListAsync();
            }
             
            //Belirli bir kategoriye ait bilgileri almak için kullanılır
            // GET: api/category/2
            [HttpGet("{id}")]
            public async Task<ActionResult<Category>> GetCategory(int id)
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    return NotFound();
                }

                return category;
            }
            //Yeni kategori eklemek için
            // POST: api/category
            [HttpPost]  //post isteği
            public async Task<ActionResult<Category>> PostCategory(Category category) //category nesnesi
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCategory", new { id = category.Id }, category);
            }

            //Kategoriyi güncellemek için 
            // PUT: api/category/2
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCategory(int id, Category category)
            {
                if (id != category.Id)
                {
                    return BadRequest();
                }

                _context.Entry(category).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
             //Belirli kategoriyi silmek için
            // DELETE: api/category/2
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCategory(int id)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();//veritabanına işlemek için

                return NoContent();
            }
            //Kategori veritabanında var mı yok mu kontrolünü yapmak için
            private bool CategoryExists(int id)
            {
                return _context.Categories.Any(e => e.Id == id);
            }
        }

    
}
