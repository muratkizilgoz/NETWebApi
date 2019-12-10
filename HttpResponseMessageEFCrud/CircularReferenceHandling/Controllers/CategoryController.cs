using System.Collections.Generic;
using System.Web.Http;
using CircularReferenceHandling.Models;

namespace CircularReferenceHandling.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Category> Get()
        {
            return _context.Categories;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _context.Dispose();
            base.Dispose(disposing);
        }
    }
}