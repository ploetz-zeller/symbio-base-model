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
        /// If this property is set to a value, Symbio use this attribute on import to get an existing source entity by comparing the attribute value with the content of the <see cref="SourceOriginKey"/> property.
        /// </summary>
        /// <value>
        /// The source origin attribute.
        /// </value>
        [XmlAttribute]
        public string SourceOriginAttribute { get; set; }

        /// <summary>
        /// Gets or sets the source origin key.
        /// If the <see cref="SourceOriginAttribute"/> property is null, Symbio use this property value to get an existing source entity by comparing the origin key of the entity with this value.
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
        /// If this property is set to a value, Symbio use this attribute on import to get an existing target entity by comparing the attribute value with the content of the <see cref="TargetOriginKey"/> property.
        /// </summary>
        /// <value>
        /// The target origin attribute.
        /// </value>
        [XmlAttribute]
        public string TargetOriginAttribute { get; set; }

        /// <summary>
        /// Gets or sets the target origin key.
        /// If the <see cref="TargetOriginAttribute"/> property is null, Symbio use this property value to get an existing target entity by comparing the origin key of the entity with this value.
        /// </summary>
        /// <value>
        /// The target origin key.
        /// </value>
        [XmlAttribute]
        public string TargetOriginKey { get; set; }

        #endregion Properties
    }
}