using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class User
    {
        private int userID;
        private string userName;
        private List<Book> borrowedbooks;
        private float finePaid;

        public List<Book> BorrowedBooks
        {
            get
            {
                return borrowedbooks;
            }
            set
            {
                borrowedbooks.AddRange(value);                 // use add range
            }
        }


        public User(int Id, string name)
        {
            userID = Id;
            userName = name;
            finePaid = 0;
            borrowedbooks = new List<Book>();
        }
    }
    }

