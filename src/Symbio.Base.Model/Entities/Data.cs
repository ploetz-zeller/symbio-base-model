﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Symbio.Base.Model.Entities
{
    /// <summary>
    /// Data (Basic XML serialization root) class
    /// </summary>
    [Serializable]
    [XmlRoot("Data")]
    public class Data
    {
        #region Fields

        private List<Entity> _entities = new List<Entity>();
        private List<Relation> _relations = new List<Relation>();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        [XmlArray("Entities")]
        [XmlArrayItem("Entity")]
        public List<Entity> Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }

        /// <summary>
        /// Gets or sets the relations.
        /// </summary>
        /// <value>
        /// The relations.
        /// </value>
        [XmlArray("Relations")]
        [XmlArrayItem("Relation")]
        public List<Relation> Relations
        {
            get { return _relations; }
            set { _relations = value; }
        }

        #endregion Properties

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Deserializes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns></returns>
        public static Data Deserialize(Stream stream)
        {
            if (stream == null)
                return null;

            var xs = new XmlSerializer(typeof(Data));
            var xr = new StreamReader(stream, Encoding.UTF8);
            return (Data)xs.Deserialize(xr);
        }

        #endregion Public Static Methods

        #region Public Methods

        /// <summary>
        /// Serializes the specified stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void Serialize(Stream stream)
        {
            if (stream == null)
                return;

            var xs = new XmlSerializer(typeof(Data));
            var xw = new StreamWriter(stream, Encoding.UTF8);
            xs.Serialize(xw, this);
            stream.Flush();
        }

        #endregion Public Methods

        #endregion Methods
    }
}