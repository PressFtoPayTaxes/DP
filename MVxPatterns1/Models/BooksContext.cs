using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MVxPatterns1.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext() : base(@"Data Source=(LocalDb)\MSSQLLocalDb;AttachDbFilename='Bookstore.mdf';Integrated Security=True")
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
