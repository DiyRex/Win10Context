using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Context
{
    internal class deleteKey
    {
        public static bool deleteRegKey()
        {
            string registryPath = @"SOFTWARE\Classes\CLSID";
            string subKeyName = "{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}";

            try
            {
                using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(registryPath, true))
                {
                    if (key != null)
                    {
                        key.DeleteSubKeyTree(subKeyName);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
            }
            return true;
        }
    }
}
