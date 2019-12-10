using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using IHttpActionResultEF.Models;

namespace IHttpActionResultEF.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: api/Products
        //public IQueryable<Product> GetProducts()
        //{
        //    return _context.Products;
        //}
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProducts(string priceRange = "")
        {
            IQueryable<Product> query = _context.Products;
            switch (priceRange)
            {
                case "":
                    break;
                case "<500":
                    query = query.Where(x => x.Price < 500m);
                    break;
                case "500<1000":
                    query = query.Where(x => x.Price < 1000 && x.Price > 500);
                    break;
                case "1000<2000":
                    query = query.Where(x => x.Price < 2000 & x.Price > 1000);
                    break;
                default:
                    return Content(HttpStatusCode.BadRequest,
                        $"{priceRange} not valid. <500 or 500<1000 or 1000<2000 kullanabilirsiniz");
            }

            return Ok(query.ToList());
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Count(e => e.Id == id) > 0;
        }
    }
}