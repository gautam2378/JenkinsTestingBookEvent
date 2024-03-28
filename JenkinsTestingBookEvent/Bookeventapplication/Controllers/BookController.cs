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
        public static List<Book> _books = new List<Book>(); // In-memory list for books

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_books); // Return the entire list of books
        }

        [HttpPost("add")]
        public IActionResult AddNewBook([FromBody] Book newBook)
        {
            _books.Add(newBook);  // Add the new book to the in-memory list
            return Ok(true);  // Return success indicator
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            // Find the book by ID
            var existingBook = _books.FirstOrDefault(b => b.Id == id);

            if (existingBook == null)
            {
                return NotFound("Book not found"); // Handle book not found scenario
            }

            // Update existing book properties
            existingBook.Name = updatedBook.Name;
            existingBook.Author = updatedBook.Author;
            existingBook.Rating = updatedBook.Rating;
            existingBook.Genre = updatedBook.Genre;
            existingBook.Description = updatedBook.Description;
            // Update other book properties as needed

            return Ok(true); // Return success indicator
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            // Find the book by ID
            var bookToDelete = _books.FirstOrDefault(b => b.Id == id);

            if (bookToDelete == null)
            {
                return NotFound("Book not found"); // Handle book not found scenario
            }

            _books.Remove(bookToDelete); // Remove the book from the list

            return Ok(true); // Return success indicator
        }
    }
}

