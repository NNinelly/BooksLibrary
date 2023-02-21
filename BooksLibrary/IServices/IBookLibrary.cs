using BooksLibrary.DTO;
using BooksLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibrary.IService
{
   public interface IBookLibrary
   {
      
      public Task<bool> CreateBook(BookRequest request);
      public Task<List<BookResponse>> Getbooks();
      public Task<BookResponse> GetbookWithId(int id);
      public Task<BookResponse> GetbookWithTitle(string title);
      public Task<bool> UpdateBook(UpdateBookRequest request);
      
   }
}
