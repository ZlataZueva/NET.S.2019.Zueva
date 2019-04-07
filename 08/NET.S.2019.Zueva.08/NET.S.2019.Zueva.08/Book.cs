using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._08
{
    public class Book: IEquatable<Book>, IComparable, IComparable<Book>
    {
        private string _isbn;
        private string _author;
        private string _title;
        private string _publishingHouse;
        private int _publishingYear;
        private int _pages;
        private double _price;

        /// <summary>
        /// Creates a Book instance with specified characteristics.
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
            ISBN = isbn;
            Author = author;
            Title = title;
            PublishingHouse = publisher;
            PublishingYear = year;
            Pages = pages;
            Price = price;
        }

        /// <summary>
        /// International Standard Book Number - numeric commercial book 13-digit identifier.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the length of the value is less than 13.</exception>
        public string ISBN
        {   get => _isbn;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (value.Length >= 13)
                {
                    _isbn = value;
                }
                else
                {
                    throw new ArgumentException("ISBN code must be 13-digit.");
                }
            }
        }

        /// <summary>
        /// Fullname of the book's author.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value contains any characters except letters, space, hyphen and single quote.</exception>
        public string Author
        {
            get => _author;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (value.All(c => char.IsLetter(c) || c.Equals(' ') || c.Equals('-') || c.Equals('\'')))
                {
                    _author = value;
                }
                else
                {
                    throw new ArgumentException("Author name must contain letters, ' ' and '-' only.");
                }
            }
        }

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                _title = value;
            }
        }

        /// <summary>
        /// The name of the a company that published the book.
        /// </summary>
        public string PublishingHouse { get => _publishingHouse; set => _publishingHouse = value; }

        /// <summary>
        /// The year of the book publishing.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value is less than zero or bigger than current year.</exception>
        public int PublishingYear
        {
            get => _publishingYear;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (value > 0 && value < DateTime.Now.Year)
                {
                    _publishingYear = value;
                }
                else
                {
                    throw new ArgumentException("Publishing year can't be less then zero or later then current year.");
                }
            }
        }

        /// <summary>
        /// The number of pages in the book.
        /// </summary>
        /// <exception cref="ArgumentException">Throwm if the value is less than or equals zero.</exception>
        public int Pages
        {
            get => _pages;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (value > 0)
                {
                    _pages = value;
                }
                else
                {
                    throw new ArgumentException("Number of pages can't be less than zero.");
                }
            }
        }

        /// <summary>
        /// The price of the book in USD.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the value is less than zero.</exception>
        public double Price
        {
            get => _price;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                if (value >= 0)
                {
                    _price = value;
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
            return "ISBN:" + ISBN + " Author:" + Author + " Title:" + Title + " Publisher:" + PublishingHouse + " Year:" + PublishingYear.ToString() + " Number of pages:" + Pages.ToString() + " Price:" + Math.Round(Price, 2).ToString();
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

            if (ISBN == book.ISBN && Author == book.Author && Title == book.Title
                   && PublishingHouse == book.PublishingHouse && PublishingYear == book.PublishingYear && Pages == book.Pages)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Find hash by ISBN
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
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

            if( ReferenceEquals(this, book))
            {
                return true;
            }

            if (ISBN == book.ISBN && Author == book.Author && Title == book.Title
                   && PublishingHouse == book.PublishingHouse && PublishingYear == book.PublishingYear && Pages == book.Pages)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(object obj)
        {
            var book = obj as Book;
            return CompareTo(book);
        }

        /// <summary>
        /// Compares books by author and title alphabetically.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int CompareTo(Book book)
        {
            if (book == null)
            {
                return 1;
            }

            int result = string.Compare(Author, book.Author, true);
            if (result == 0)
            {
                result = string.Compare(Title, book.Title);
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
