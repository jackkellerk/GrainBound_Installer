using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainBound_Installer
{
    public class GBRegistry
    {
        public const string GRAINBOUND_SUBKEY = "GrainBound";
        public const string GRAINBOUND_INSTALL_KEY = "InstallInfo";
        public const string GRAINBOUND_VERSION_KEY = "Version";

        private static Microsoft.Win32.RegistryKey regKey;
        public static void createRegistryKey(string key, string value)
        {
            regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(GRAINBOUND_SUBKEY);
            regKey.SetValue(key, value);
            regKey.Close();
        }
        public static string checkRegistryKey(string key)
        {
            try
            {
                regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(GRAINBOUND_SUBKEY);
                string val = (string)regKey.GetValue(key);
                regKey.Close();
                return val;
            }
            catch { return null; }
        }
        public static void removeRegistryKey()
        {
            Microsoft.Win32.Registry.CurrentUser.DeleteSubKey(GRAINBOUND_SUBKEY);
            regKey.Close();
        }
    }
}
