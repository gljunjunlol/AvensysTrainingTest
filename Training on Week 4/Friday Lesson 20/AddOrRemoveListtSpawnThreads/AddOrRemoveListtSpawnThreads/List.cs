using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AddOrRemoveListtSpawnThreads
{
    class List1<T>
    {

        public List<T> list3 { get; private set; }

        public List1()
        {
            list3 = new List<T>();
        }

        public void Add(T add)
        {
            new Thread(() => { list3.Add(add); }).Start();
        }

        public void Remove(T remove)
        {
            new Thread(() =>{ list3.Remove(remove);}).Start();
        }
    }
}
