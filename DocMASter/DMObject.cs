using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocMASter
{
    public class DMObject
    {
        #region Class properties
        /// <summary>
        /// The type of MAS object represented by the DMObject (e.g. SalesOrder)
        /// </summary>
        public DMObjectType ObjectType { get; private set; }

        /// <summary>
        /// The ID of the MAS object represented by the DMObject (e.g. SalesOrder #123456)
        /// </summary>
        public string ObjectId { get; private set; }
        
        /// <summary>
        /// The folder path where docs associated with this DMObject are to be stored.
        /// </summary>
        private string _docsPath;
        public string DocsPath 
        {
            get 
            {
                if (_docsPath == null) 
                { 
                    _docsPath = Path.Combine(ObjectType.DocsPathRoot, ObjectId); 
                    if (!Directory.Exists(_docsPath) )
                    {
                        Directory.CreateDirectory(_docsPath);
                    }
                }

                return _docsPath;
            }
        }

        /// <summary>
        /// The types of docs that can be associated with this Object Type as defined in app.config
        /// </summary>
        private string[] _availableFileTypes;
        public string[] AvailableFileTypes
        {
            get
            {
                if (_availableFileTypes == null)
                {
                    _availableFileTypes = ObjectType.AvailableDocTypes;
                }

                return _availableFileTypes;
            }
        }

        /// <summary>
        /// The list of docs that are currently associated with this Object. This is not cached since it will likely change over the course of execution 
        /// </summary>
        public List<DMDoc> DocList
        {
            get
            {
                DirectoryInfo di = new DirectoryInfo(DocsPath);
                List<DMDoc> list = new List<DMDoc>(di.EnumerateFiles().Select(d => new DMDoc(d.FullName)).ToArray());
                return list;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for DocMASter Object (DMObject)
        /// </summary>
        /// <param name="objectType">The type of MAS object represented by the DMObject</param>
        /// <param name="objectId">The ID of the MAS object represented by the DMObject</param>
        public DMObject(string objectType, string objectId)
        {
            ObjectType = DMObjectType.Get(objectType);
            ObjectId = objectId;
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Associates a doc with the DMObject by renaming and copying or moving it to the correct location.
        /// The destination file name will be "(doc type) (n).(ext)", where:
        /// (doc type) = the type of doc selected by the user
        /// (n) = a number indicating that this is the nth doc of this type for this object (omitted for the first such doc)
        /// (ext) = the original file extension
        /// </summary>
        /// <param name="dmDoc">The doc to be associated</param>
        /// <param name="fileType">The doc type (i.e. what the file will be renamed to)</param>
        /// <param name="removeOriginal">Whether to copy (false) or move (true) the doc from its original location</param>
        public void AssociateDoc(DMDoc dmDoc, string fileType, bool removeOriginal)
        {
            string destFilePath = Path.Combine(DocsPath, NextAvailableFilenameBase(fileType) + dmDoc.Extension);

            if (removeOriginal)
            {
                dmDoc.MoveTo(destFilePath);
            }
            else
            {
                dmDoc.CopyTo(destFilePath);
            }
        }

        /// <summary>
        /// Determines the next available filename base for the given file type within this Object.
        /// The filename base will be "(doc type) (n)", where:
        /// (doc type) = the type of doc selected by the user
        /// (n) = a number indicating that this is the nth doc of this type for this object (omitted for the first such doc)
        /// </summary>
        /// <param name="fileType">The type of file for which the next available filename base will be found</param>
        /// <returns>The next available filename base</returns>
        public string NextAvailableFilenameBase(string fileType)
        {
            int i = 0;
            string filenameBase = string.Empty;
            do
            {
                i++;
                filenameBase = fileType + (i > 1 ? (" " + i) : "");
            } while (Directory.GetFiles(DocsPath, filenameBase + ".*", System.IO.SearchOption.TopDirectoryOnly).Length > 0);

            return filenameBase;
        }
        #endregion
    }
}
