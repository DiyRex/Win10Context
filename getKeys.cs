using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win10Context
{
    internal class getKeys
    {
        public static bool GetKeys()
        {
            string registryPath = @"SOFTWARE\Classes\CLSID";
            bool key_found = false;
            try
            {
                using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(registryPath))
                {
                    if (key != null)
                    {
                        string[] subKeyNames = key.GetSubKeyNames();

                        foreach (string subKeyName in subKeyNames)
                        {
                            if(subKeyName == "{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}") 
                            { 
                                key_found = true; 
                            }
                        }
                    }
                    else
                    {
                        //
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
            return key_found;
        }
    }
}
