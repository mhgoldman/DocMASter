using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace DocMASter
{
    public class DMObjectType
    {
        #region Class properties
        /// <summary>
        /// The name of the ObjectType (e.g. APInvoice)
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The types of docs that can be associated to objects this ObjectType (e.g. VendorBill)
        /// </summary>
        public string[] AvailableDocTypes { get; private set; }

        /// <summary>
        /// An English hint as to how to format the IDs for objects of this type
        /// TODO: Not Yet Used!
        /// </summary>
        // public string IDFormatHint { get; private set; }

        /// <summary>
        /// A regex that IDs must match for objects of this type
        /// TODO: Not Yet Used!
        /// </summary>
        // public string IDFormatRegex { get; private set; }

        /// <summary>
        /// The root of where docs are stored for objects of this type
        /// </summary>
        public string DocsPathRoot
        {
            get
            {
                return Path.Combine(Util.DocLibraryPath, Name);
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Private constructor for ObjectType
        /// </summary>
        /// <param name="name">name of ObjectType to create (must be defined in registry)</param>
        private DMObjectType(string name)
        {
            Name = name;
            try
            {
                using (RegistryKey objectTypeRK = Util.AppKey.OpenSubKey(Path.Combine("ObjectTypes", Name)))
                {
                    AvailableDocTypes = (string[])objectTypeRK.GetValue("DocTypes");
                    // IDFormatHint = (string)objectTypeRK.GetValue("IDFormatHint");
                    // IDFormatRegex = (string)objectTypeRK.GetValue("IDFormatRegex");
                }
            }
            catch (Exception e)
            {
                Util.InformException("while getting info for ObjectType " + name, e);
            }
        }

        /// <summary>
        /// Creates an ObjectType by calling the private constructor (it reads better)
        /// </summary>
        /// <param name="name">name of ObjectType to create (must be defined in registry)</param>
        /// <returns>an ObjectType object</returns>
        public static DMObjectType Get(string name)
        {
            return new DMObjectType(name);
        }
        #endregion
    }
}
