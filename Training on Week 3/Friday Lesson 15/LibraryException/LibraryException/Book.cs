using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryException
{
    class Book
    {
        public int bookID { get; set; }
        public string bookName { get; set; }

        public Book(int bookid, string bookname)
        {
            bookID = bookid;
            bookName = bookname;
        }
    }
}
