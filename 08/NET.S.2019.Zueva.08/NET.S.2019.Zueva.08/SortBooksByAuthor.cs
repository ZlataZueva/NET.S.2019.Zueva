using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._08
{
    class SortBooksByAuthor:ISortBooksBy
    {
        /// <summary>
        /// Sort books by author in alphabet order.
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public IEnumerable<Book> SortBooksByTag(List<Book> books)
        {
            if (books == null)
            {
                return null;
            }
            var sortedBooks = from b in books
                              orderby b.Author
                              select b;
            return sortedBooks;
        }
    }
}
