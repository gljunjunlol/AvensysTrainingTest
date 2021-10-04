using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_5
{
    class MyList<T>
    {
        public List<T> mylist { get; private set; }

        public MyList()
        {
            mylist = new List<T>();
        }

        public void Add(T input)
        {
            mylist.Add(input);
        }

        public void Remove(T remover)
        {
            mylist.Remove(remover);
        }

        public void RemoveAll(T removeAll)
        {
            mylist.Clear();
        }

        public void RemoveAt(T i)
        {

        }
        public int IndexOf1 (T item, int index)
        {

            return mylist.IndexOf(item);
        }


        public T this[int index]
        {

            get
            {
                try
                {
                    return mylist[index];
                    // return value

                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("out of range");
                    throw ex;

                }
                
            }
            set
            {
                try
                {
                    mylist[index] = value;
                    // return value

                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("out of range");
                    throw ex;

                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("out of range");


                }

            }

            
            
        }
    }
}
