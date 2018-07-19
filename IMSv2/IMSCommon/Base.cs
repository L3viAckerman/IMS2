using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.IMSCommon
{
    public abstract class Base
    {
        public Base() { }
        public Base(object obj)
        {
            Common<object>.Copy(obj, this);
        }
        public abstract bool Equals(Base other);
    }
}
