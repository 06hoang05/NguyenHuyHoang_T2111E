using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductController : BaseProductController
    {
        private readonly DemoDbContext _context;

        public ProductController(DemoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Course model)
        {

            _context.Products.Add(model);
            var roweff = _context.SaveChanges();

            return roweff > 0 ? Ok(model) : BadRequest("loi roi");
        }
        [HttpGet("List")]
        public IActionResult GetList([FromQuery] Course model)
        {
            var res = _context.Products.Where(
                m => (m.Name.ToLower().Contains(model.Name.ToLower()) || model.Name == "")

                && (m.Primare == model.Primare || model.Primare == 0)
                && (m.Amount == model.Amount || model.Amount == 0)

                );
            return Ok(res);
        }
        [HttpGet("Details/{id}")]
        public IActionResult GetDetail([FromRoute] int id)
        {
            return Ok(_context.Products.Find(id));
        }

        [HttpPut("edit")]
        public IActionResult Edit(Course model)
        {

            _context.Products.Update(model);
            var roweff = _context.SaveChanges();

            return roweff > 0 ? Ok(model) : BadRequest("loi roi");
        }


        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var model = _context.Products.Find(id);
            if (model == null)
            {
                return BadRequest("no data found");
            }

            _context.Products.Remove(model);
            var roweff = _context.SaveChanges();

            return roweff > 0 ? Ok("success") : BadRequest("loi roi");
        }
    }
}
