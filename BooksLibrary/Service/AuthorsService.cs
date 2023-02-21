using BooksLibrary.AplicationDBContext;
using BooksLibrary.DTO;
using BooksLibrary.IServices;
using BooksLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.Service
{
   public class AuthorsService : IAuthors
   {
      private readonly BookLibraryDbContext _context;
      public AuthorsService(BookLibraryDbContext context)
      {
         _context = context;
      }

      public async Task<bool> CreateAuthor(AuthorRequest request)
      {
         try
         {
            Author auth = new Author()
            {
               FirstName = request.FirstName,
               LastName = request.LastName,
               BirthDate = request.BirthDate
            };

            await  _context.authors.AddAsync(auth);
             _context.SaveChanges();
            return true;
         }
         catch (Exception)
         {
            return false;
         }

      }

      public async Task<List<AuthorResponse>> GetAuthors()
      {
         var auth = await _context.authors.Select(a => new AuthorResponse
         {
            BirthDate = a.BirthDate,
            FirstName = a.FirstName,
            Id = a.Id,
            LastName = a.LastName
         }).ToListAsync();
         return auth;
      }

      public async Task<AuthorResponse> GetAuthorWithName(string firstName)
      {
         var auth = await _context.authors.Where(x => x.FirstName.Equals(firstName)).FirstOrDefaultAsync();

         var AuthorResponse = new AuthorResponse
         {
            Id = auth.Id,
            BirthDate = auth.BirthDate,
            FirstName = auth.FirstName,
            LastName = auth.LastName
         };

         return AuthorResponse;
      }

      public async Task<AuthorResponse> GetById(int id)
      {
         var auth = await _context.authors.Where(x => x.Id == id).FirstOrDefaultAsync();

         var AuthorResponse = new AuthorResponse
         {
            Id = auth.Id,
            BirthDate = auth.BirthDate,
            FirstName = auth.FirstName,
            LastName = auth.LastName
         };

         return AuthorResponse;
      }

      public async Task<bool> UpdateAuthor(UpdateAuthorRequest request)
      {
         try
         {
            var author = await _context.authors.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            author.Id = request.Id;
            author.BirthDate = request.BirthDate;
            author.FirstName = request.FirstName;
            author.LastName = request.LastName;

            _context.authors.Update(author);
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
