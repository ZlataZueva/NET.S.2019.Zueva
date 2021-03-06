﻿// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        /// <summary>
        /// Test searching and sorting of books.
        /// </summary>
        /// <param name="args">Comand line arguments.</param>
        public static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Book b1 = new Book("ISBN978-5-98901-592-9", "Достоевский", "Преступление и наказание", "Солнышко", 1976, 300, 12);
            Book b2 = new Book("ISBN978-5-99025-792-4", "Достоевский", "Идиот", "Звезда", 1979, 500, 23);
            Console.WriteLine(b1.ToString());
            Console.WriteLine(b2.ToString());
            Console.WriteLine(b1.Equals(b2));
            Console.WriteLine(b1.CompareTo(b2));
            BookListStorage storage = new BookListStorage(@"C:\Users\ZlatKa\Documents\booklist.bin");
            BookListService service = new BookListService(storage);
            service.AddBook(b1);
            service.AddBook(b2);
            service.SortBooksByTag(new SortBooksByTitle());
            foreach (Book b in service.ListOfBooks)
            {
                Console.WriteLine(b.Title);
            }

            Console.WriteLine(service.FindBookByTag(new FindBookByTitle("Идиот")).ToString());
            service.SaveToStorage();
            Console.ReadLine();
        }
    }
}
