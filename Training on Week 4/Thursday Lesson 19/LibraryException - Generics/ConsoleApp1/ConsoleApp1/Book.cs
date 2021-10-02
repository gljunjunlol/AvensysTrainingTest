using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ILoanBook
    {
        void IssueBook();
    }
    public class Book<T>
    {
        private T genericVariable;
        
        public T value
        {
            get
            {
                return this.genericVariable;
            }
            set
            {
                this.genericVariable = value;
            }
        }

    }
}
