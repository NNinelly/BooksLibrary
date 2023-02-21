namespace BooksLibrary.DTO
{
   public class UpdateAuthorRequest
   {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime BirthDate { get; set; }
   }
}
