using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._08
{
    /// <summary>
    /// Interface for searching the book by criterion.
    /// </summary>
    public interface IFindBookBy
    {
        Book FindBookByTag(List<Book> books);
    }
}
