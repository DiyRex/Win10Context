using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Context
{
    internal class createKeys
    {
        public static bool addMainKey()
        {
            bool is_created = false;
            string registryPath = @"SOFTWARE\Classes\CLSID";
            string newKeyName = "{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}";

            try
            {
                using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(registryPath, true))
                {
                    if (key != null)
                    {
                        // Check if the new key already exists
                        if (key.OpenSubKey(newKeyName) == null)
                        {
                            // Create the new subkey
                            RegistryKey newSubKey = key.CreateSubKey(newKeyName);
                            is_created =  true;

                            // Close the new subkey when you're done with it
                            newSubKey.Close();
                        }
                        else
                        {
                            is_created = false;
                        }
                    }
                    else
                    {
                        is_created = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
            return is_created;
        }

        public static bool addSecondKey()
        {
            bool is_created = false;
            string registryPath = @"SOFTWARE\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}";
            string newKeyName = "InprocServer32";

            try
            {
                using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(registryPath, true))
                {
                    if (key != null)
                    {
                        // Check if the new key already exists
                        if (key.OpenSubKey(newKeyName) == null)
                        {
                            // Create the new subkey
                            RegistryKey newSubKey = key.CreateSubKey(newKeyName);
                            is_created = true;

                            // Close the new subkey when you're done with it
                            newSubKey.Close();
                        }
                        else
                        {
                            is_created = false;
                        }
                    }
                    else
                    {
                        is_created = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
            return is_created;
        }

        public static bool addDefaultValue()
        {
            string registryPath = @"SOFTWARE\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32";

            try
            {
                using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(registryPath, true))
                {
                    if (key != null)
                    {
                        // Set the default value of the subkey to an empty string
                        key.SetValue("", ""); // Set both name and value data to empty strings

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
                return false;
            }
        }
    }
}
