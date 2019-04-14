// <copyright file="BookListService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class BookListService
    {
        private List<Book> listOfBooks = new List<Book>();
        private BookListStorage bookStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class with specified storage.
        /// </summary>
        /// <param name="storage">Storage for the books list.</param>
        /// <exception cref="ArgumentNullException">Thrown if the storage is null.</exception>
        public BookListService(BookListStorage storage)
        {
            if (ReferenceEquals(storage, null))
            {
                throw new ArgumentNullException();
            }

            this.bookStorage = storage;
            this.ListOfBooks = this.bookStorage.GetBooksList();
        }

        /// <summary>
        /// Gets books list.
        /// </summary>
        public List<Book> ListOfBooks
        {
            get => this.listOfBooks;
            private set => this.listOfBooks = value;
        }

        /// <summary>
        /// Add book to the list if it doesn't contain this book.
        /// </summary>
        /// <param name="book">The book to add.</param>
        /// <exception cref="ArgumentException">Thrown if the book is in the list already.</exception>
        public void AddBook(Book book)
        {
            if (!this.IsExist(book))
            {
                this.ListOfBooks.Add(book);
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Remove book from list if it includes this book.
        /// </summary>
        /// <param name="book">The book to be removed.</param>
        /// <exception cref="ArgumentException">Thrown if the book is not in the list.</exception>
        public void RemoveBook(Book book)
        {
            if (this.IsExist(book))
            {
                this.ListOfBooks.Remove(book);
            }

            throw new ArgumentException();
        }

        /// <summary>
        /// Finds book by criterial using interface variable.
        /// </summary>
        /// <param name="criterion"> Interface variable that implements the search method.</param>
        /// <returns> Found book.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the criterion is null.</exception>
        public Book FindBookByTag(IFindBookBy criterion)
        {
            if (criterion == null)
            {
                throw new ArgumentNullException();
            }

            return criterion.FindBookByTag(this.ListOfBooks);
        }

        /// <summary>
        /// Sort list of books by criterion.
        /// </summary>
        /// <param name="criterion">Interface variable that implements the sorting method.</param>
        /// <exception cref="ArgumentNullException">Thrown if the criterion is null.</exception>
        public void SortBooksByTag(ISortBooksBy criterion)
        {
            if (criterion != null)
            {
                this.ListOfBooks = criterion.SortBooksByTag(this.ListOfBooks).ToList();
            }

            throw new ArgumentNullException();
        }

        /// <summary>
        /// Saves list of books to the book storage.
        /// </summary>
        public void SaveToStorage()
        {
            this.bookStorage.SaveBooksList(this.ListOfBooks);
        }

        /// <summary>
        /// Checks whether the book is in the list or not.
        /// </summary>
        /// <param name="book">The book to check.</param>
        /// <returns>True, if the book is in the list. False, if it is not.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the book is null.</exception>
        private bool IsExist(Book book)
        {
            if (book != null)
            {
                foreach (Book bookInList in this.ListOfBooks)
                {
                    if (book.Equals(bookInList))
                    {
                        return true;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException();
            }

            return false;
        }
    }
}
