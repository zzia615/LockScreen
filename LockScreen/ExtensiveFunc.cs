using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LockScreen
{
    public static class ExtensiveFunc
    {
        public static string AsString(this object obj)
        {
            if (obj == null)
            {
                return "";
            }

            return obj.ToString();
        }
    }
}
