using System.Xml.Serialization;

namespace Symbio.Base.Model.Entities
{
    /// <summary>
    /// A relation between 2 entities.
    /// </summary>
    public class Relation
    {
        #region Properties

        /// <summary>
        /// Gets or sets the source key.
        /// </summary>
        /// <value>
        /// The source key.
        /// </value>
        [XmlAttribute]
        public string SourceKey { get; set; }

        /// <summary>
        /// Gets or sets the source origin attribute.
        /// </summary>
        /// <value>
        /// The source origin attribute.
        /// </value>
        [XmlAttribute]
        public string SourceOriginAttribute { get; set; }

        /// <summary>
        /// Gets or sets the source origin key.
        /// </summary>
        /// <value>
        /// The source origin key.
        /// </value>
        [XmlAttribute]
        public string SourceOriginKey { get; set; }

        /// <summary>
        /// Gets or sets the target key.
        /// </summary>
        /// <value>
        /// The target key.
        /// </value>
        [XmlAttribute]
        public string TargetKey { get; set; }

        /// <summary>
        /// Gets or sets the target origin attribute.
        /// </summary>
        /// <value>
        /// The target origin attribute.
        /// </value>
        [XmlAttribute]
        public string TargetOriginAttribute { get; set; }

        /// <summary>
        /// Gets or sets the target origin key.
        /// </summary>
        /// <value>
        /// The target origin key.
        /// </value>
        [XmlAttribute]
        public string TargetOriginKey { get; set; }

        #endregion Properties
    }
}