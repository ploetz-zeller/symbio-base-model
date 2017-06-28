using System.Xml.Serialization;

namespace Symbio.Base.Model.Entities
{
    /// <summary>
    /// Attribute for the serialization.
    /// </summary>
    public class Attribute
    {
        #region Properties

        /// <summary>
        /// Gets or sets the lcid.
        /// </summary>
        /// <value>
        /// The lcid.
        /// </value>
        [XmlAttribute]
        public int Culture { get; set; }

        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        [XmlAttribute]
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [XmlAttribute]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [XmlAttribute]
        public string Value { get; set; }

        #endregion Properties
    }
}