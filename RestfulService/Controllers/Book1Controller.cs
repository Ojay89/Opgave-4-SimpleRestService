using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleRestService;

namespace RestfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Book1Controller : ControllerBase
    {
        private static readonly List<Book> books = new List<Book>()
        {
            new Book("Omars Bog", "Omar", 124, "1294837261729"),
            new Book("Olivers Bog", "Oliver", 581, "2189271629471"),
            new Book("Talias Bog", "Talia", 183, "4910481634910"),
            new Book("Konrads Bog", "Konrad", 193, "0494820184613"),
            new Book("Jamshids bog", "Jamshid", 981, "1239481638184")
        };

        // GET: api/Items
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;

        }

        //GET: api/Items/5
        [HttpGet("{isbn13}", Name = "Get")]
        public Book Get(string isbn13)
        {
            return books.Find(i => i.Isbn13 == isbn13);
        }

        // POST: api/Items
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            books.Add(value);
        }

        // PUT: api/Items/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Book value)
        {
            Book book = Get(isbn13);
            if (book != null)
            {
                book.Title = value.Title;
                book.Author = value.Author;
                book.PageNo = value.PageNo;
                book.Isbn13 = value.Isbn13;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Book book = Get(isbn13);
            books.Remove(book);
        }
    }
}