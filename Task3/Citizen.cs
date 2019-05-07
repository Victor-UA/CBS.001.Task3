using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public abstract class Citizen: IEquatable<Citizen>
    {
        protected Citizen(Passport passport)
        {
            Passport = passport;
        }

        public Passport Passport { get; private set; }

        public virtual bool Equals(Citizen other)
        {
            return Passport.Equals(other.Passport);
        }
    }
}
