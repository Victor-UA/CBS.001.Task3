using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class MyCollection : ICollection
    {
        private int DEFAULT_CITIZENS_QUANTITY = 10;

        private Citizen[] _citizens;

        public MyCollection()
        {
            _citizens = new Citizen[DEFAULT_CITIZENS_QUANTITY];
            Count = 0;
        }

        public int Count { get; private set; }

        public object SyncRoot => false;

        public bool IsSynchronized => false;

        public void CopyTo(Array array, int index)
        {
            for (int i = index; i < Count; i++)
            {
                _citizens.CopyTo(array, index);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return _citizens.GetEnumerator();
        }
    }
}
