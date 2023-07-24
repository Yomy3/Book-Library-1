using Project_Book.Model;
using Microsoft.AspNetCore.Mvc;
using Project_Book.Service;
using Microsoft.Extensions.Logging;

namespace Project_Book_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService = new BookService();

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Book> GetAll()
        {
            return _bookService.RetriveAll();
        }





    }

}

