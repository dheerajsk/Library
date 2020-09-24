using Library.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<BookModel> Books { get; set; }

        public BookController()
        {
            Books = new List<BookModel>();

            Books.Add(new BookModel { ID = 1, Name = "Clean Architecture", Genre = "Programming", Author = "Robert Martin", PublishedYear = "2017" });
            Books.Add(new BookModel { ID = 2, Name = "Dependency Injection in .NET", Genre = "Programming", Author = "Mark Seemann", PublishedYear = "2019" });
            Books.Add(new BookModel { ID = 3, Name = "Refactoring", Genre = "Programming", Author = "Martin Fowler", PublishedYear = "1999" });
            Books.Add(new BookModel { ID = 4, Name = "India After Gandhi", Genre = "History", Author = "Ramachandra Guha", PublishedYear = "2007" });
            Books.Add(new BookModel { ID = 5, Name = "Gitanjali", Genre = "Poetry", Author = "Rabindranath Tagore", PublishedYear = "1910" });
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = Books.Where(i => i.ID == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] BookModel book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            Books.Add(book);
            return Ok(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] BookModel book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            var existingBook = Books.Where(i => i.ID == book.ID).FirstOrDefault();
            if (existingBook == null)
            {
                return NotFound();
            }
            Books.Remove(existingBook);
            Books.Add(book);

            return Ok(existingBook);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var existingBook = Books.Where(i => i.ID == id).FirstOrDefault();
            if (existingBook == null)
            {
                return NotFound();
            }
            Books.Remove(existingBook);

            return Ok();
        }
    }
}
