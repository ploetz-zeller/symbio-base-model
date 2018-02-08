using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Symbio.Base.Model.Entities
{
    /// <summary>
    /// An entity. May be everithing from item to file (<see cref="Entity.EntityType"/>).
    /// </summary>
    public class Entity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        public Entity()
        {
            OriginKeyComparer = StringComparison.Ordinal;
        }

        #endregion Constructors

        #region Fields

        private List<Attribute> _attributes = new List<Attribute>();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the attributes of the entity.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        [XmlArray("Attributes")]
        [XmlArrayItem("Attribute")]
        public List<Attribute> Attributes
        {
            get { return _attributes; }
        }

        /// <summary>
        /// Gets or sets the entity key.
        /// </summary>
        /// <value>
        /// The entity key.
        /// </value>
        [XmlAttribute]
        public string EntityKey { get; set; }

        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        [XmlAttribute]
        public string EntityType { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>
        /// The file.
        /// </value>
        [XmlElement("File")]
        public File File { get; set; }

        /// <summary>
        /// Gets or sets the import behavior.
        /// </summary>
        /// <value>
        /// The import behavior.
        /// </value>
        [XmlAttribute]
        public ImportBehavior ImportBehavior { get; set; }

        /// <summary>
        /// Gets or sets the origin attribute.
        /// If this property is set to a value, Symbio use this attribute on import to get an existing entity by comparing the attribute value with the content of the <see cref="OriginKey"/> property.
        /// </summary>
        /// <example>AT_ID</example>
        /// <value>
        /// The origin attribute.
        /// </value>
        [XmlAttribute]
        public string OriginAttribute { get; set; }

        /// <summary>
        /// Gets or sets the origin key.
        /// If the <see cref="OriginAttribute"/> property is null, Symbio use this property value to get an existing entity by comparing the origin key of the entity with this value.
        /// </summary>
        /// <value>
        /// The origin key.
        /// </value>
        [XmlAttribute]
        public string OriginKey { get; set; }

        /// <summary>
        /// Gets or sets the origin key comparer used on comparing entity to get the existing entity on import in Symbio.
        /// Default is StringComparison.Ordinal.
        /// </summary>
        /// <example>CurrentCulture</example>
        /// <example>CurrentCultureIgnoreCase</example>
        /// <example>InvariantCulture</example>
        /// <example>InvariantCultureIgnoreCase</example>
        /// <example>Ordinal</example>
        /// <example>OrdinalIgnoreCase</example>
        /// <value>
        /// The origin key comparer.
        /// </value>
        [XmlAttribute,
        DefaultValue(StringComparison.Ordinal)]
        public StringComparison OriginKeyComparer { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <example>OT_FUNC</example>
        /// <example>OTX_SUB_PROCESS</example>
        /// <value>
        /// The type.
        /// </value>
        [XmlAttribute]
        public string Type { get; set; }

        #endregion Properties
    }
}