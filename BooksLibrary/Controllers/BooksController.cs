using BooksLibrary.DTO;
using BooksLibrary.IService;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class BooksController : ControllerBase
   {
      //private readonly LibraryDBContext _context;
      private readonly IBookLibrary _book;

      public BooksController(IBookLibrary book)
      {
         _book = book;
      }


      [Route("[action]")]
      [HttpPost]
      public async Task<IActionResult> CreateBook(BookRequest request)
      {
         var result = await _book.CreateBook(request);
         return Ok(result);
      }

      [Route("[action]")]
      [HttpGet]
      public async Task<IActionResult> GetBooks()
      {
         var res = await _book.Getbooks();
         return Ok(res);
      }

      [Route("[action]")]
      [HttpGet]
      public async Task<IActionResult> GetBookWithId(int id)
      {
         var res = await _book.GetbookWithId(id);
         return Ok(res);
      }

      [Route("[action]")]
      [HttpGet]
      public async Task<IActionResult> GetBookWithTitle(string title)
      {
         var res = await _book.GetbookWithTitle(title);
         return Ok(res);
      }

      [Route("[action]")]
      [HttpPut]
      public async Task<IActionResult> UpdateBook(UpdateBookRequest request)
      {
         var res = await _book.UpdateBook(request);
         return Ok(res);
      }

   }

}
