using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Book.Model;
using Project_Book.Service;

namespace Project_Book.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _mybookService = new BookService();

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Book> GetAll()
        {
            return _mybookService.RetriveAll();
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _mybookService.Retrive(id);
        }

        [HttpPut]

        public void Update([FromBody] Book book)
        {
            _mybookService.Update(book);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _mybookService.Delete(id);
        }
        [HttpPost]
        public Book Post([FromBody] Book book) 
        {
            return _mybookService.Create(book);
        }

    }
}
