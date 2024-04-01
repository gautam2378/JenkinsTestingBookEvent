using Bookeventapplication.Controllers;
using Bookeventapplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jenkinstestcases

{
    public class BookControllerTests
    {
        private BookController _controller = new BookController();

        [Fact]
        public void GetAllBooks_ReturnsEmptyListIfNoBooksAdded()
        {

            var result = _controller.GetAllBooks();


            if (_controller.GetAllBooks() is OkObjectResult okResult)
            {
                var books = okResult.Value as List<Book>;

                Assert.Empty(books);
            }
        }

        [Fact]
        public void AddNewBook_AddsBookToList()
        {

            Book newBook = new Book { Name = "Test Book", Author = "Test Author" };


            var addResult = _controller.AddNewBook(newBook);


            Assert.IsType<OkObjectResult>(addResult);


            if (addResult is OkObjectResult okResult)
            {
                Assert.Null(okResult.Value);
            }


            // var books = ((OkObjectResult)addResult).Value as List<Book>;

            var books = _controller.GetAllBooks() as List<Book>;
            Assert.Single(books);
            Assert.Equal(newBook.Name, books[0].Name);
            Assert.Equal(newBook.Author, books[0].Author);
        }
        [Fact]
        public void UpdateBook_UpdatesExistingBookProperties()
        {

            Book newBook = new Book { Name = "Test Book", Author = "Test Author" };
            _controller.AddNewBook(newBook);

            int bookId = newBook.Id;
            Book updatedBook = new Book { Id = bookId, Name = "Updated Book", Author = "Updated Author" };


            var updateResult = _controller.UpdateBook(bookId, updatedBook);


            Assert.IsType<OkObjectResult>(updateResult);


            if (updateResult is OkObjectResult okResult)
            {
                Assert.Null(okResult.Value);
            }


            var books = ((OkObjectResult)updateResult).Value as List<Book>;

            // var books = _controller.GetAllBooks().Value as List<Book>;
            Assert.Single(books);
            Assert.Equal(updatedBook.Name, books[0].Name);
            Assert.Equal(updatedBook.Author, books[0].Author);

        }
        [Fact]
        public void DeleteBook_RemovesBookFromList()
        {

            Book newBook = new Book { Name = "Test Book", Author = "Test Author" };
            _controller.AddNewBook(newBook);

            int bookId = newBook.Id;


            var deleteResult = _controller.DeleteBook(bookId);


            Assert.IsType<OkObjectResult>(deleteResult);


            if (deleteResult is OkObjectResult okResult)
            {
                Assert.Null(okResult.Value);
            }


            var books = ((OkObjectResult)deleteResult).Value as List<Book>;

            // var books = _controller.GetAllBooks().Value as List<Book>;
            Assert.Empty(books);
        }

        [Fact]
        public void UpdateBook_ReturnsNotFoundIfBookDoesntExist()
        {

            int nonExistentBookId = 123;
            Book updatedBook = new Book { Id = nonExistentBookId };


            var updateResult = _controller.UpdateBook(nonExistentBookId, updatedBook);


            Assert.IsType<NotFoundResult>(updateResult);
        }

        [Fact]
        public void DeleteBook_ReturnsNotFoundIfBookDoesntExist()
        {

            int nonExistentBookId = 456;


            var deleteResult = _controller.DeleteBook(nonExistentBookId);


            Assert.IsType<NotFoundResult>(deleteResult);
        }
    }
}
