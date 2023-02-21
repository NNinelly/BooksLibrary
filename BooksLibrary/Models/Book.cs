using System.ComponentModel.DataAnnotations;

namespace BooksLibrary.Models
{
   public class Book
   {
      [Key]
      public int Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public string Photo { get; set; }
      public int Rate { get; set; }
      public DateTime Publication { get; set; }
      public bool status { get; set; }
      public virtual Author Authors { get; set; }
      public int AuthorId { get; set; }
   }
}
