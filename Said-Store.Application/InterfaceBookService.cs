using Said_Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Said_Store.Application
{
    internal interface InterfaceBookService
    {
            Task<IEnumerable<Book>> GetAllBooksAsync();
            Task<Book?> GetBookByIdAsync(int id);
            Task<Book> AddBookAsync(Book book);
            Task<Book?> UpdateBookAsync(int id, Book book);
            Task<bool> DeleteBookAsync(int id);
        }
    }

