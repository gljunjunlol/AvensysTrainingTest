using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThread
{
    class Book
    {
        public int bookID { get; set; }
        public string bookTitle { get; set; }

        public Book(int bookID, string bookTitle)
        {
            this.bookID = bookID;
            this.bookTitle = bookTitle;
        }

    }
}
