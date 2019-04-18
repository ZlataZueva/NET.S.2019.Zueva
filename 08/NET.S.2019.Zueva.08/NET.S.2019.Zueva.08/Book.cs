// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_08
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Book : IEquatable<Book>, IComparable, IComparable<Book>, IFormattable
    {
        private string isbn;
        private string author;
        private string title;
        private string publishingHouse;
        private int publishingYear;
        private int pages;
        private double price;

        private static readonly string DefaultFormatString = "ISBN XXX-X-XXXX-XXXX-X, Author, Title, Publisher, YYYY, p.";

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class with specified characteristics.
        /// </summary>
        /// <param name="isbn">International Standard Book Number</param>
        /// <param name="author">Fullname of the book's author.</param>
        /// <param name="title">Title of the book.</param>
        /// <param name="publisher">The name of the a company that published the book.</param>
        /// <param name="year">The year of the book publishing.</param>
        /// <param name="pages">The number of pages in the book.</param>
        /// <param name="price">The price of the book in USD.</param>
        public Book(string isbn, string author, string title, string publisher, int year, int pages, double price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Title = title;
            this.PublishingHouse = publisher;
            this.PublishingYear = year;
            this.Pages = pages;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets international Standard Book Number - numeric commercial book 13-digit identifier.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the length of the value is less than 13.</exception>
        public string ISBN
        {
            get => this.isbn;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (value.Length >= 13)
                {
                    this.isbn = value;
                }
                else
                {
                    throw new ArgumentException("ISBN code must be 13-digit.");
                }
            }
        }

        /// <summary>
        /// Gets or sets fullname of the book's author.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value contains any characters except letters, space, hyphen and single quote.</exception>
        public string Author
        {
            get => this.author;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (value.All(c => char.IsLetter(c) || c.Equals(' ') || c.Equals('-') || c.Equals('\'')))
                {
                    this.author = value;
                }
                else
                {
                    throw new ArgumentException("Author name must contain letters, ' ' and '-' only.");
                }
            }
        }

        /// <summary>
        /// Gets or sets title of the book.
        /// </summary>
        public string Title
        {
            get => this.title;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.title = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the a company that published the book.
        /// </summary>
        public string PublishingHouse { get => this.publishingHouse; set => this.publishingHouse = value; }

        /// <summary>
        /// Gets or sets the year of the book publishing.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value is less than zero or bigger than current year.</exception>
        public int PublishingYear
        {
            get => this.publishingYear;
            set
            {
                if (value > 0 && value < DateTime.Now.Year)
                {
                    this.publishingYear = value;
                }
                else
                {
                    throw new ArgumentException("Publishing year can't be less then zero or later then current year.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the number of pages in the book.
        /// </summary>
        /// <exception cref="ArgumentException">Throwm if the value is less than or equals zero.</exception>
        public int Pages
        {
            get => this.pages;
            set
            {
                if (value > 0)
                {
                    this.pages = value;
                }
                else
                {
                    throw new ArgumentException("Number of pages can't be less than zero.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the price of the book in USD.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value is less than zero.</exception>
        public double Price
        {
            get => this.price;
            set
            {
                if (value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentException("Book can't cost less than zero.");
                }
            }
        }

        /// <summary>
        /// Present the book as a string.
        /// </summary>
        /// <returns>
        /// String with book's characteristic.
        /// </returns>
        public override string ToString()
        {
            return "ISBN:" + this.ISBN + " Author:" + this.Author + " Title:" + this.Title + " Publisher:" + this.PublishingHouse + " Year:" + this.PublishingYear.ToString() + " Number of pages:" + this.Pages.ToString() + " Price:" + Math.Round(this.Price, 2).ToString();
        }

        /// <summary>
        /// Check input object and current book for equality.
        /// </summary>
        /// <param name="obj">
        /// Object for checking.
        /// </param>
        /// <returns>
        /// True if they are equal. False if they are not.
        /// </returns>
        public override bool Equals(object obj)
        {
            var book = obj as Book;
            if (book == null)
            {
                return false;
            }

            if (this.ISBN == book.ISBN && this.Author == book.Author && this.Title == book.Title
                   && this.PublishingHouse == book.PublishingHouse && this.PublishingYear == book.PublishingYear && this.Pages == book.Pages)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Find hash by all fields except price.
        /// </summary>
        /// <returns>Books hash code.</returns>
        public override int GetHashCode()
        {
            var hashCode = -127691308;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.isbn);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.author);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.title);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.publishingHouse);
            hashCode = (hashCode * -1521134295) + this.publishingYear.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.pages.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Check input book and current book for equality.
        /// </summary>
        /// <param name="book">
        /// Book for checking.
        /// </param>
        /// <returns>
        /// True if they are equal. False if they are not.
        /// </returns>
        public bool Equals(Book book)
        {
            if (book == null)
            {
                return false;
            }

            if (ReferenceEquals(this, book))
            {
                return true;
            }

            if (this.ISBN == book.ISBN && this.Author == book.Author && this.Title == book.Title
                   && this.PublishingHouse == book.PublishingHouse && this.PublishingYear == book.PublishingYear && this.Pages == book.Pages)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(object obj)
        {
            var book = obj as Book;
            return this.CompareTo(book);
        }

        /// <summary>
        /// Compares books by author and title alphabetically.
        /// </summary>
        /// <param name="book">Book to cpmpare with current.</param>
        /// <returns>1 when current book is after the book, -1 when it is before and 0 when books are equal.</returns>
        public int CompareTo(Book book)
        {
            if (book == null)
            {
                return 1;
            }

            int result = string.Compare(this.Author, book.Author, true);
            if (result == 0)
            {
                result = string.Compare(this.Title, book.Title);
                return result;
            }
            else
            {
                return result;
            }
        }

        public string ToString (string format)
        {
            return this.ToString(format, null);
        }

        public string ToString (IFormatProvider formatProvider)
        {
            return this.ToString(null, formatProvider);
        }

        /// <summary>
        /// Represents the book in specified format.
        /// </summary>
        /// <param name="format">Format string of representation.</param>
        /// <param name="formatProvider">Defines the symbols used in converting book to its string representation.</param>
        /// <returns>String representation of the book.</returns>
        /// <exception cref="FormatException">Thrown when format string is not supported.</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = DefaultFormatString;
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            StringBuilder stringBuilder = new StringBuilder();
            if (format.Contains("ISBN"))
            {
                for (int i = 0; i < 13; i++)
                {
                    if (format.Contains("X"))
                    {
                        int firstIndex = format.IndexOf('X');
                        format.Remove(firstIndex, 1);
                        format.Insert(firstIndex, this.ISBN[i].ToString(formatProvider));
                    }
                    else
                    {
                        throw new FormatException(string.Format("Format string {0} is not supported", format));
                    }
                }
            }

            stringBuilder.Append(format);
            stringBuilder.Replace("Author", this.Author.ToString(formatProvider));
            stringBuilder.Replace("Title", this.Title.ToString(formatProvider));
            stringBuilder.Replace("Publisher", this.PublishingHouse.ToString(formatProvider));
            stringBuilder.Replace("YYYY", this.PublishingYear.ToString(formatProvider));
            stringBuilder.Replace("p.", "p. " + this.Pages.ToString(formatProvider));
            stringBuilder.Replace("P", this.Price.ToString(formatProvider));
            return stringBuilder.ToString();
        }
    }
}
