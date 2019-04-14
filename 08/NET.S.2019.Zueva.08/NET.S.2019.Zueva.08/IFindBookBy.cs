// <copyright file="IFindBookBy.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET.S_2019.Zueva_08
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for searching the book by criterion.
    /// </summary>
    public interface IFindBookBy
    {
        Book FindBookByTag(List<Book> books);
    }
}
