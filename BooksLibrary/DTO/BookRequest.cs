namespace BooksLibrary.DTO
{
   public class BookRequest
   {
      public int AuthorId { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public string Photo { get; set; }
      public int Rate { get; set; }
      public DateTime Publication { get; set; }
      public bool Status { get; set; }
   }
}
