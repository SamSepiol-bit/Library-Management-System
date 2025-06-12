using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryApp
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
    }
}