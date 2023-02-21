using BooksLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksLibrary.AplicationDBContext
{
   public class BookLibraryDbContext : DbContext
   {
      public BookLibraryDbContext(DbContextOptions options) : base(options)
      {

      }

     
      public DbSet<Book> books { get; set; }
      public DbSet<Author> authors { get; set; }
   }
}
