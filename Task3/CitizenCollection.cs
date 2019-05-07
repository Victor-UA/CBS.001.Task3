using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class CitizenCollection : ICollection<Citizen>
    {
        private int DEFAULT_CITIZENS_QUANTITY = 10;
        private Citizen[] _citizens;


        public CitizenCollection()
        {
            Clear();
        }


        public Citizen this[int index]
        {
            get
            {
                if (index < Count || index < 0)
                {
                    return _citizens[index];
                }
                else
                {
                    throw new IndexOutOfRangeException($"Index needs to be in range [0, {Count - 1}]");
                }
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(Citizen item)
        {
            if (!IsReadOnly && !Contains(item))
            {
                if (++Count > _citizens.Length)
                {
                    ArrayExpand(ref _citizens);
                }
                _citizens[Count - 1] = item;
            }
        }        

        public void Clear()
        {
            _citizens = new Citizen[DEFAULT_CITIZENS_QUANTITY];
            Count = 0;
        }

        public int GetIndexOf(Citizen person)
        {            
            for (int i = 0; i < Count; i++)
            {
                if (_citizens[i].Equals(person))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Contains(Citizen person)
        {
            return GetIndexOf(person) >= 0;            
        }

        public void CopyTo(Citizen[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < Count; i++)
            {
                array[i - arrayIndex] = _citizens[i];
            }
        }

        public IEnumerator<Citizen> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _citizens[i];
            }            
        }

        public bool Remove(Citizen item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_citizens[i].Equals(item))
                {
                    Count--;
                    for (int j = i; j < Count; j++)
                    {
                        _citizens[j] = _citizens[j + 1];
                    }
                    ArrayReduce(ref _citizens, Count);
                    return true;
                }
            }
            return false;
        }

        public bool Remove()
        {
            return (Count > 0) && Remove(this[0]);            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private void ArrayExpand(ref Citizen[] array)
        {
            int arrayNewLength = (int)(array.Length * 1.5) + 1;
            Citizen[] arrayNew = new Citizen[arrayNewLength];
            array.CopyTo(arrayNew, 0);
            array = arrayNew;
        }

        private void ArrayReduce(ref Citizen[] array, int count)
        {
            int arrayNewLength;
            int arrayNewLengthNext = array.Length;
            do
            {
                arrayNewLength = arrayNewLengthNext;
                arrayNewLengthNext = (int)(arrayNewLength / 1.5) - 1;
            } while (arrayNewLengthNext >= count);

            Citizen[] arrayNew = new Citizen[arrayNewLength];
            for (int i = 0; i < count; i++)
            {
                arrayNew[i] = array[i];
            }
            array = arrayNew;
        }
    }
}
