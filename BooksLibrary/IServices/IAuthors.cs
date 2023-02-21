using BooksLibrary.DTO;

namespace BooksLibrary.IServices
{
   public interface IAuthors
   {
      public Task<bool> CreateAuthor(AuthorRequest request);
      public Task<List<AuthorResponse>> GetAuthors();
      public Task<AuthorResponse> GetById(int id);
      public Task<AuthorResponse> GetAuthorWithName(string firstName);
      public Task<bool> UpdateAuthor(UpdateAuthorRequest request);
   }
}
