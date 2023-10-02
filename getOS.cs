using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Management;

namespace Win10Context
{
    internal class getOS
    {
        public static string os_name = GetWindowsEdition();

        public static string GetWindowsEdition()
        {
            string edition = "Unknown";

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject obj in collection)
                {
                    string productType = obj["ProductType"].ToString();
                    string caption = obj["Caption"].ToString();

                    if (caption.Contains("Windows 11") && productType == "1")
                    {
                        edition = "Windows 11 Pro";
                    }
                    else if (caption.Contains("Windows 10") && productType == "1")
                    {
                        edition = "Windows 10 Pro or earlier";
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex != null)
                {
                   edition = "failed";
                }
            }

            return edition;
        }

    }
}

