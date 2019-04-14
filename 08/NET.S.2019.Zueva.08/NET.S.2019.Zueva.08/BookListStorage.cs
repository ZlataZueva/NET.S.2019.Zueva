// <copyright file="BookListStorage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_08
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class BookListStorage
    {
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListStorage"/> class with specified path.
        /// </summary>
        /// <param name="path">The path to store books list.</param>
        public BookListStorage(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Gets or sets the path to store the books list.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown of the string is empty.</exception>
        public string Path
        {
            get => this.path;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException();
                }

                this.path = value;
            }
        }

        /// <summary>
        /// Read data about a list of books stored in file.
        /// </summary>
        /// <returns>
        /// List of books.
        /// </returns>
        public List<Book> GetBooksList()
        {
            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(this.Path, FileMode.OpenOrCreate)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    var isbn = reader.ReadString();
                    var author = reader.ReadString();
                    var title = reader.ReadString();
                    var publisher = reader.ReadString();
                    var year = reader.ReadInt32();
                    var numOfPages = reader.ReadInt32();
                    var price = reader.ReadDouble();
                    Book book = new Book(isbn, author, title, publisher, year, numOfPages, price);
                    books.Add(book);
                }
            }

            return books;
        }

        /// <summary>
        /// Save list of books in binary file.
        /// </summary>
        /// <param name="books">The list of books to be saved.</param>
        public void SaveBooksList(List<Book> books)
        {
            if (new FileInfo(this.Path).Length != 0)
            {
                File.WriteAllText(this.Path, string.Empty);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(this.Path, FileMode.OpenOrCreate)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.ISBN);
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.PublishingHouse);
                    writer.Write(book.PublishingYear);
                    writer.Write(book.Pages);
                    writer.Write(book.Price);
                }
            }
        }
    }
}
