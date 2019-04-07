using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._08
{
    class FindBookByTitle : IFindBookBy
    {
        private string _title;

        /// <summary>
        /// Creates FindBookByTitle instance for finding books with specified title.
        /// </summary>
        /// <param name="title">The title of the book to be found.</param>
        public FindBookByTitle(string title)
        {
            _title = title;
        }

        /// <summary>
        /// Searches book in the list by the title.
        /// </summary>
        /// <param name="books"> List of books to find the book in.</param>
        /// <returns>Found book with the title.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list of books is null.</exception>
        public Book FindBookByTag(List<Book> books)
        {
            if(books != null)
            {
                foreach (Book book in books)
                {
                    if (book.Title == _title)
                    {
                        return book;
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
