using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.Models
{
    public class PagedList<T>
    {
        public List<T> Content { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}