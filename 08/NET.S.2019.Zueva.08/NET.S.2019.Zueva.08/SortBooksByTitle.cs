using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._08
{
    class SortBooksByTitle:ISortBooksBy
    {
        /// <summary>
        /// Sort books by title in alphabet order.
        /// </summary>
        /// <param name="books">The list of books to be sorted.</param>
        /// <returns>Sorted list of books.</returns>
        public IEnumerable<Book> SortBooksByTag(List<Book> books)
        {
            if (books == null)
            {
                return null;
            }
            var sortedBooks = from b in books
                              orderby b.Title
                              select b;
            return sortedBooks;
        }
    }
}
