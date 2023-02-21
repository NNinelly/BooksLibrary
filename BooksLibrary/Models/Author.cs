using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksLibrary.Models
{
   public class Author
   {
      [Key]
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime BirthDate { get; set; }
      public  List<Book> Books { get; set; }
   }
}
