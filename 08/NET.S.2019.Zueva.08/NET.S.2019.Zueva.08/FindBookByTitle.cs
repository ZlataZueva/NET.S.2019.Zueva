// <copyright file="FindBookByTitle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class FindBookByTitle : IFindBookBy
    {
        private readonly string title;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindBookByTitle"/> class for finding books with specified title.
        /// </summary>
        /// <param name="title">The title of the book to be found.</param>
        public FindBookByTitle(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// Searches book in the list by the title.
        /// </summary>
        /// <param name="books"> List of books to find the book in.</param>
        /// <returns>Found book with the title.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list of books is null.</exception>
        public Book FindBookByTag(List<Book> books)
        {
            if (books != null)
            {
                foreach (Book book in books)
                {
                    if (book.Title == this.title)
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
