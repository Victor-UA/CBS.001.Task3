using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class MyCollection : IEnumerable<Citizen>
    {        
        private CitizenCollection _pensioners;
        private CitizenCollection _citizens;

        public MyCollection()
        {
            Clear();
        }

        public int Count
        {
            get
            {
                return _pensioners.Count + _citizens.Count;
            }
        }

        public bool IsReadOnly => false;

        public void Add(Citizen person)
        {
            if (!IsReadOnly)
            {
                if (person.GetType() == typeof(Pensioner))
                {
                    _pensioners.Add(person);
                }
                else
                {
                    _citizens.Add(person);
                }
            }
        }

        public void Clear()
        {
            _pensioners = new CitizenCollection();
            _citizens = new CitizenCollection();
        }

        public int GetIndexOf(Citizen person)
        {
            if (person.GetType() == typeof(Pensioner))
            {
                return _pensioners.GetIndexOf(person);
            }
            else
            {
                int index = _citizens.GetIndexOf(person);
                return (index < 0 ? index : _pensioners.Count + index);
            }
        }

        public Tuple<bool, int> Contains(Citizen person)
        {
            if (person.GetType() == typeof(Pensioner))
            {
                return new Tuple<bool, int>(true, _pensioners.GetIndexOf(person));
            }
            else
            {
                int index = _citizens.GetIndexOf(person);
                return new Tuple<bool, int>(index >= 0, (index < 0 ? index : _pensioners.Count + index));
            }            
        }

        public void CopyTo(Citizen[] array, int arrayIndex)
        {
            if (arrayIndex > Count)
            {
                throw new IndexOutOfRangeException($"Index needs to be in range [0, {Count - 1}]");
            }

            if (arrayIndex < _pensioners.Count)
            {
                int i = arrayIndex;
                for (i = arrayIndex; i < _pensioners.Count; i++)
                {
                    array[i - arrayIndex] = _pensioners[i];
                }
                for (; i < _citizens.Count; i++)
                {
                    array[i - arrayIndex] = _citizens[i];
                }
            }
            else
            {
                for (int i = arrayIndex; i < _citizens.Count; i++)
                {
                    array[i - arrayIndex] = _citizens[i];
                }
            }
            
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in _pensioners)
            {
                yield return item;
            }
            foreach (var item in _citizens)
            {
                yield return item;
            }
        }

        public bool Remove()
        {
            if (_pensioners.Count > 0)
            {
                return _pensioners.Remove();
            }
            else
            {
                return _citizens.Remove();
            }
        }

        public bool Remove(Citizen item)
        {
            return _pensioners.Remove(item) || _citizens.Remove(item);
        }

        IEnumerator<Citizen> IEnumerable<Citizen>.GetEnumerator()
        {
            return (IEnumerator<Citizen>)GetEnumerator();
        }

        public override string ToString()
        {
            string result = "";
            int i = 0;
            for (i = 0; i < _pensioners.Count; i++)
            {
                var passport = _pensioners[i].Passport;
                result += $"Position: {i}; Passport serie: {passport.Series}, number: {passport.Number}\n";
            }
            for (; i < Count; i++)
            {
                var passport = _citizens[i - _pensioners.Count].Passport;
                result += $"Position: {i}; Passport serie: {passport.Series}, number: {passport.Number}\n";
            }
            return result;
        }
    }
}
