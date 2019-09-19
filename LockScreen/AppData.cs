using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LockScreen
{
    public class AppData
    {
        static string Registry_Path = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Jaylosy\\LockScreen";
        public static void SetRegistry(string key,object value)
        {
            Registry.SetValue(Registry_Path, key, value);
        }

        public static string GetRegistry(string key, object value)
        {
            return Registry.GetValue(Registry_Path, key, value).AsString();
        }
    }
}
