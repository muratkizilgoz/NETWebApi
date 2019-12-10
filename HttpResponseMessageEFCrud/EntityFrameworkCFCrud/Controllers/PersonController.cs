using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityFrameworkCFCrud.Models;

namespace EntityFrameworkCFCrud.Controllers
{
    public class PersonController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public HttpResponseMessage Get(string gender = "", int? take = -1)
        {
            //iqueryable => query oluşturur hemen çekmez.
            IQueryable<Person> query = _context.Persons;

            gender = gender.ToLower();

            switch (gender)
            {
                case "":
                    break;
                case "male":
                    query = query.Where(x => x.Gender.ToLower() == "male");
                    break;
                case "female":
                    query = query.Where(x => x.Gender.ToLower() == "female");
                    break;
                default:
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                        $"{gender} not valid. 'male' or 'female' kullanabilirsiniz");
            }

            // ?gender=male&take=3 || ?take=3&gender=male => sorgusunda dönen sonuçta
            // ilk 3 verisi 1 kadın, 2 erkek olan tabloda hatasız sonuç => önce gender sonra take

            if (take > 0) query = query.Take(take.Value);

            return Request.CreateResponse(HttpStatusCode.OK, query.ToList());
        }

        public HttpResponseMessage Get(int id)
        {
            var person = _context.Persons.Find(id);
            if (person == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kişi bulunamadı");
            return Request.CreateResponse(HttpStatusCode.OK, person);
        }

        public HttpResponseMessage Post(Person person)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model geçersiz");

            _context.Persons.Add(person);
            _context.SaveChanges();

            var message = Request.CreateResponse(HttpStatusCode.Created, person);
            message.Headers.Location = new Uri($"{Request.RequestUri}/{person.Id}");

            return message;
        }

        //FromBody birden fazla olamaz.
        public HttpResponseMessage SampleFromBodyandUri([FromBody] SampleFromBody body, [FromUri] Person person)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(int id, Person person)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Geçersiz model");
            if (!PersonExists(id))
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kişi bulunamadı");

            if (id != person.Id)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request id ile model id farklı");

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, person);
        }

        public HttpResponseMessage Delete(int id)
        {
            var person = _context.Persons.Find(id);

            if (person == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kişi bulunamadı");

            _context.Persons.Remove(person);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Count(x => x.Id == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _context.Dispose();
            base.Dispose(disposing);
        }

        public class SampleFromBody
        {
            public int Id { get; set; }
            public string MiddleName { get; set; }
        }
    }
}