using Bookeventapplication.Controllers;
using Bookeventapplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JenkinsTesting
{
    public class UnitTest1
    {
        [Fact]
        public void GetAllBooks_ReturnsEmptyListIfNoBooksAdded()
        {
            // Arrange
            BookController controller = new BookController(); // Create a new instance of the controller
                                                              // No need to add any books, as we're testing the empty case

            // Act
            var result = controller.GetAllBooks();

            // Assert
            var books = Assert.IsType<List<Book>>(result.value); // Ensure the result is a list of books
            Assert.Empty(books); // Assert that the list is empty
        }
    }
   
}