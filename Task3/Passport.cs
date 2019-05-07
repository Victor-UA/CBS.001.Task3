using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Passport: IEquatable<Passport>
    {
        public string Series { get; private set; }
        public int Number { get; private set; }
        


        public Passport(string series, int number)
        {
            Series = series;
            Number = number;
        }


        public bool Equals(Passport other)
        {
            return (
                other != null && 
                Series == other.Series && 
                Number == other.Number);
        }

        public override string ToString()
        {
            return $"Series: {Series}, Number: {Number}";
        }
    }
}
