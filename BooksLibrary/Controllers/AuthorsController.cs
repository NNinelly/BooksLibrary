using BooksLibrary.DTO;
using BooksLibrary.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthorsController : ControllerBase
   {
      private readonly IAuthors _Iauthors;

      public AuthorsController(IAuthors authors)
      {
         _Iauthors = authors;
      }

      [Route("[action]")]
      [HttpPost]
      public async Task<IActionResult> CreateAuthor(AuthorRequest request)
      {
         var result = await _Iauthors.CreateAuthor(request);
         return Ok(result);
      }

      [Route("[action]")]
      [HttpGet]
      public async Task<IActionResult> GetAuthors()
      {
         var result = await _Iauthors.GetAuthors();
         return Ok(result);
      }

      [Route("[action]")]
      [HttpGet]
      public async Task<IActionResult> GetById(int id)
      {
         var result = await _Iauthors.GetById(id);
         return Ok(result);
      }

      [Route("[action]")]
      [HttpGet]
      public async Task<IActionResult> GetAuthorWithName(string firstName)
      {
         var result = await _Iauthors.GetAuthorWithName(firstName);
         return Ok(result);
      }

      [Route("[action]")]
      [HttpPut]
      public async Task<IActionResult> UpdateAuthor(UpdateAuthorRequest request)
      {
         var res = await _Iauthors.UpdateAuthor(request);
         return Ok(res);
      }

   }
}
