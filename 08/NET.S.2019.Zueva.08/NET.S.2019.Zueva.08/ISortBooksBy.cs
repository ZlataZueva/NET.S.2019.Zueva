using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Zueva._08
{
    /// <summary>
    /// Interface for sorting books by criterion.
    /// </summary>
    public interface ISortBooksBy
    {
        IEnumerable<Book> SortBooksByTag(List<Book> books);
    }
}
