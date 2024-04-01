using Bookeventapplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookeventapplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public static List<Book> _books = new List<Book>(); 

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_books);
        }

        [HttpPost("add")]
        public IActionResult AddNewBook([FromBody] Book newBook)
        {
            _books.Add(newBook);  
            return Ok(true); 
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
           
            var existingBook = _books.FirstOrDefault(b => b.Id == id);

            if (existingBook == null)
            {
                return NotFound("Book not found"); 
            }

            
            existingBook.Name = updatedBook.Name;
            existingBook.Author = updatedBook.Author;
            existingBook.Rating = updatedBook.Rating;
            existingBook.Genre = updatedBook.Genre;
            existingBook.Description = updatedBook.Description;
           

            return Ok(true); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
          
            var bookToDelete = _books.FirstOrDefault(b => b.Id == id);

            if (bookToDelete == null)
            {
                return NotFound("Book not found"); 
            }

            _books.Remove(bookToDelete);

            return Ok(true); 
        }
    }
}

