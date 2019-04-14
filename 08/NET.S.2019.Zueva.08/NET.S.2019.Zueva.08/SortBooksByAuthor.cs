// <copyright file="SortBooksByAuthor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class SortBooksByAuthor : ISortBooksBy
    {
        /// <summary>
        /// Sort books by author in alphabet order.
        /// </summary>
        /// <param name="books">Books list to sort.</param>
        /// <returns>Sorted books sequence.</returns>
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
