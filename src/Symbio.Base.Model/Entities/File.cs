using System;
using System.Xml.Serialization;

namespace Symbio.Base.Model.Entities
{
    /// <summary>
    /// File information for the serialization.
    /// </summary>
    public class File
    {
        #region Properties

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [XmlIgnore]
        public byte[] Data { get; set; }

        /// <summary>
        /// Gets or sets the data as a base64-string.
        /// </summary>
        /// <value>
        /// The data string.
        /// </value>
        [XmlAttribute("Data")]
        public string DataString
        {
            get { return Convert.ToBase64String(Data ?? new byte[0]); }
            set { Data = Convert.FromBase64String(value ?? string.Empty); }
        }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        [XmlAttribute]
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the MIMEtype.
        /// </summary>
        /// <value>
        /// The MIMEtype.
        /// </value>
        [XmlAttribute]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlAttribute]
        public string Name { get; set; }

        #endregion Properties
    }
}