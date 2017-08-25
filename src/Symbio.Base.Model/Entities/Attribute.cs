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
        /// If the LCID is 0 on import, the default culture will be assumed on culture dependent attributes, the invariant culture on culture independent attributes.
        /// </summary>
        /// <value>
        /// The lcid.
        /// </value>
        [XmlAttribute]
        public int Culture { get; set; }

        /// <summary>
        /// Gets or sets the type of the data. (Fullname of .NET Type)
        /// If the DataType is not available on import the correct data type will be calculated for the specified attribute.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        [XmlAttribute]
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the attribute type.
        /// </summary>
        /// <example>AT_NAME</example>
        /// <example>AT_DESC</example>
        /// <value>
        /// The type.
        /// </value>
        [XmlAttribute]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value, serialized as string.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [XmlAttribute]
        public string Value { get; set; }

        #endregion Properties
    }
}