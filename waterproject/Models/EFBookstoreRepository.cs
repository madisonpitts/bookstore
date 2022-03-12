using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookstore.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookstoreRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
