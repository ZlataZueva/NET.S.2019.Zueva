using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._08
{
    class FindBookByISBN : IFindBookBy
    {
        private string _isbn;

        /// <summary>
        /// Searches book in the list by the ISBN.
        /// </summary>
        /// <param name="books">List of books to find the book in.</param>
        /// <returns>Found book with the title.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list of books is null.</exception>
        public Book FindBookByTag(List<Book> books)
        {
            if (books != null)
            {
                foreach (Book bookInList in books)
                {
                    if (bookInList.ISBN == _isbn)
                    {
                        return bookInList;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return null;
        }
    }
}
