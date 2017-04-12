using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Reflection
{
    public class TypeFinder : ITypeFinder
    {
        public Type[] Find(Func<Type, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Type[] FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
