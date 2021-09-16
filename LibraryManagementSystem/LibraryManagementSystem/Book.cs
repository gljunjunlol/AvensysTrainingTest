using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Book
    {
        private int bookId;
        private string bookName;
        private string author;
        private int numberOfCopies;
        private string location;

        public int Bookid { get; set; }
        private string BookName { get; set; }
        private string Author { get; set; }
        private int NumberOfCopies { get; set; }
        private string Location { get; set; }

        //public int BookId
        //{ 
        //    get => bookId;
        //    set { bookId = value; }
        //}

        //public void enterBookDetails(int Id, string name, string author, int noOfCopies, string location)
        //{
        //    bookId = Id;
        //    bookName = name;
        //    this.author = author;
        //    numberOfCopies = noOfCopies;
        //    this.location = location;
        //}

        public void retriveBookDetails()
        {
            Console.WriteLine("BookId" + bookId);
            Console.WriteLine("BookName" + bookName);
            Console.WriteLine("Author" + author);
            Console.WriteLine("Number Of Copies" + numberOfCopies);
        }
        //public string retriveBookDetails()
        //{
        //    string res = bookId + "_" + bookName;
        //    return res;
        //    //Console.WriteLine("UserId" + bookId);
        //}

        //public int getBookId()
        //{
        //    return bookId;
        //}

        //public void setBookId(int id)
        //{
        //    bookId = id;
        //}
    }
}
