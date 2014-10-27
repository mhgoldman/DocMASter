using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace DocMASter
{
    public static class Util
    {
        #region Class constants
        /// <summary>
        /// registry key path in HKLM where app settings are stored
        /// </summary>
        private static readonly string APP_KEY_SUBPATH = "Software\\Total Machine Solutions\\DocMASter";
        #endregion

        /// <summary>
        /// Returns an instance of the app settings key
        /// </summary>
        public static RegistryKey AppKey
        {
            get
            {
                return Registry.LocalMachine.OpenSubKey(APP_KEY_SUBPATH, false);
            }
        }

        /// <summary>
        /// The (probably) UNC path where the library lives 
        /// </summary>
        private static string _docLibraryPath;
        public static string DocLibraryPath
        {
            get
            {
                if (_docLibraryPath == null)
                {
                    LoadPaths();
                }

                return _docLibraryPath;
            }
        }

        /// <summary>
        /// The (probably) UNC path where the dropbox lives
        /// </summary>
        private static string _docDropboxPath;
        public static string DocDropboxPath
        {
            get
            {
                if (_docDropboxPath == null)
                {
                    LoadPaths();
                }

                return _docDropboxPath;
            }
        }

        /// <summary>
        /// Load the library and dropbox paths from the registry
        /// </summary>
        private static void LoadPaths()
        {
            try
            {
                using (RegistryKey appKey = AppKey)
                {
                    _docLibraryPath = (string)appKey.GetValue("DocLibraryPath");
                    _docDropboxPath = (string)appKey.GetValue("DocDropboxPath");
                }
            }
            catch (Exception e)
            {
                InformException("loading library and dropbox paths", e);
            }
        }

        /// <summary>
        /// exception handler
        /// </summary>
        /// <param name="duringWhat">string representing what was happening when the exception happened</param>
        /// <param name="e">the exception object</param>
        public static void InformException(string duringWhat, Exception e)
        {
            System.Windows.Forms.MessageBox.Show("An error occurred while " + duringWhat + ": " + e.GetType().ToString() + ": " + e.Message + "\n\n" + e.StackTrace, "Error");
            Environment.Exit(1);
        }
    }      
}
