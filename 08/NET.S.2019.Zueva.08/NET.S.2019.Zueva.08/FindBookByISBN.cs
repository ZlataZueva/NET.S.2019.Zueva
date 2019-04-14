// <copyright file="FindBookByISBN.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class FindBookByISBN : IFindBookBy
    {
        private string isbn;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindBookByISBN"/> class for finding book with ISBN.
        /// </summary>
        /// <param name="isbn">ISBN of book to find.</param>
        public FindBookByISBN(string isbn)
        {
            this.isbn = isbn;
        }

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
                    if (bookInList.ISBN == this.isbn)
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
