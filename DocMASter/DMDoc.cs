﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace DocMASter
{
    public class DMDoc
    {
        #region Properties
        /// <summary>
        /// The FileInfo object that represents the underlying file
        /// </summary>
        private FileInfo FileInfo
        {
            get;
            set;
        }

        /// <summary>
        /// The file type description as retrieved via the Windows API
        /// </summary>
        private string _fileTypeDescription;
        public string FileTypeDescription
        {
            get
            {
                if (_fileTypeDescription == null)
                {
                    _fileTypeDescription = GetFileTypeDescription();
                }
                return _fileTypeDescription;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for DocMASter Doc (DMDoc)
        /// </summary>
        /// <param name="filePath">Path of the file represented by the DMDoc</param>
        public DMDoc(string filePath)
        {
            FileInfo = new FileInfo(filePath);
        }
        #endregion

        #region FileInfo method/property wrappers
        /// <summary>
        /// Returns the time the file was created
        /// </summary>
        public string CreationTimeString
        {
            get
            {
                return FileInfo.CreationTime.ToString();
            }
        }

        /// <summary>
        /// Returns the name of the file (including extension, excluding full path)
        /// </summary>
        public string Name
        {
            get
            {
                return FileInfo.Name;
            }
        }

        /// <summary>
        /// Returns the full path of the file
        /// </summary>
        public string FullName
        {
            get
            {
                return FileInfo.FullName;
            }
        }

        /// <summary>
        /// The extension of the file
        /// </summary>
        public string Extension
        {
            get
            {
                return FileInfo.Extension;
            }
        }

        /// <summary>
        /// Copies the file to the given destination path
        /// </summary>
        /// <param name="destPath"></param>
        public void CopyTo(string destPath)
        {
            FileInfo.CopyTo(destPath);
        }

        /// <summary>
        /// Moves the file to the given destination path
        /// </summary>
        /// <param name="destPath"></param>
        public void MoveTo(string destPath)
        {
            FileInfo.MoveTo(destPath);
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Get the file type description for the file's extension.
        /// </summary>
        /// <returns>A string containing the file type description</returns>
        private string GetFileTypeDescription()
        {
            SHFILEINFO shfi;
            if (IntPtr.Zero != SHGetFileInfo(
                                FileInfo.Extension,
                                FILE_ATTRIBUTE_NORMAL,
                                out shfi,
                                (uint)Marshal.SizeOf(typeof(SHFILEINFO)),
                                SHGFI_USEFILEATTRIBUTES | SHGFI_TYPENAME))
            {
                return shfi.szTypeName;
            }
            return null;
        }

        [DllImport("shell32")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint flags);

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        private const uint FILE_ATTRIBUTE_READONLY = 0x00000001;
        private const uint FILE_ATTRIBUTE_HIDDEN = 0x00000002;
        private const uint FILE_ATTRIBUTE_SYSTEM = 0x00000004;
        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint FILE_ATTRIBUTE_ARCHIVE = 0x00000020;
        private const uint FILE_ATTRIBUTE_DEVICE = 0x00000040;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const uint FILE_ATTRIBUTE_TEMPORARY = 0x00000100;
        private const uint FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200;
        private const uint FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400;
        private const uint FILE_ATTRIBUTE_COMPRESSED = 0x00000800;
        private const uint FILE_ATTRIBUTE_OFFLINE = 0x00001000;
        private const uint FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000;
        private const uint FILE_ATTRIBUTE_ENCRYPTED = 0x00004000;
        private const uint FILE_ATTRIBUTE_VIRTUAL = 0x00010000;

        private const uint SHGFI_ICON = 0x000000100;     // get icon
        private const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
        private const uint SHGFI_TYPENAME = 0x000000400;     // get type name
        private const uint SHGFI_ATTRIBUTES = 0x000000800;     // get attributes
        private const uint SHGFI_ICONLOCATION = 0x000001000;     // get icon location
        private const uint SHGFI_EXETYPE = 0x000002000;     // return exe type
        private const uint SHGFI_SYSICONINDEX = 0x000004000;     // get system icon index
        private const uint SHGFI_LINKOVERLAY = 0x000008000;     // put a link overlay on icon
        private const uint SHGFI_SELECTED = 0x000010000;     // show icon in selected state
        private const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // get only specified attributes
        private const uint SHGFI_LARGEICON = 0x000000000;     // get large icon
        private const uint SHGFI_SMALLICON = 0x000000001;     // get small icon
        private const uint SHGFI_OPENICON = 0x000000002;     // get open icon
        private const uint SHGFI_SHELLICONSIZE = 0x000000004;     // get shell size icon
        private const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute
        #endregion
    }
}
