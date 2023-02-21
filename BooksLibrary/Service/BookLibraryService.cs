using BooksLibrary.AplicationDBContext;
using BooksLibrary.DTO;
using BooksLibrary.IService;
using BooksLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Service
{

   public class BookLibraryService : IBookLibrary
   {
      private readonly BookLibraryDbContext _context;
      public BookLibraryService(BookLibraryDbContext context)
      {
         _context = context;
      }


      public async Task<bool> CreateBook(BookRequest request)
      {
         try
         {
            Book book = new Book
            {
               AuthorId = request.AuthorId,
               Description = request.Description,
               Photo = request.Photo,
               Publication = request.Publication,
               Rate = request.Rate,
               status = request.Status,
               Title = request.Title

            };

            await _context.books.AddAsync(book);
            _context.SaveChanges();
            return true;
         }
         catch (Exception)
         {

            return false;
         }

      }

      public async Task<List<BookResponse>> Getbooks()
      {
         var res = await _context.books.Select(i => new BookResponse
         {
            Id = i.Id,
            AuthorId = i.AuthorId,
            Title = i.Title,
            Description = i.Description,
            Photo = i.Photo,
            Rate = i.Rate,
            Publication = i.Publication,
            status = i.status
         }).ToListAsync();

         return res;
      }
      public async Task<BookResponse> GetbookWithId(int id)
      {

         var book = await _context.books.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

         var BookResponse = new BookResponse
         {
            Id = book.Id,
            Title = book.Title,
            AuthorId = book.AuthorId,
            Description = book.Description,
            Photo = book.Photo,
            Publication = book.Publication,
            Rate = book.Rate,
            status = book.status
         };
         return BookResponse;
      }

      public async Task<BookResponse> GetbookWithTitle(string title)
      {

         var book = await _context.books.Where(x => x.Title.Equals(title)).FirstOrDefaultAsync();

         var BookResponse = new BookResponse
         {
            Id = book.Id,
            Title = book.Title,
            AuthorId = book.AuthorId,
            Description = book.Description,
            Photo = book.Photo,
            Publication = book.Publication,
            Rate = book.Rate,
            status = book.status
         };
         return BookResponse;
      }

      public async Task<bool> UpdateBook(UpdateBookRequest request)
      {
         try
         {
            var book =await  _context.books.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            book.status = request.Status;
            book.Photo = request.Photo;
            book.AuthorId = request.AuthorId;
            book.Title = request.Title;
            book.Rate = request.Rate;
            book.Description = request.Description;
            book.Id = request.Id;
            book.Publication = request.Publication;

            _context.books.Update(book);
            await _context.SaveChangesAsync();
            return true;
         }
         catch (Exception)
         {
            return false;
         }
      }
   }
}



