using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Symbio.Base.Model.WebServices.Contracts;

namespace Symbio.Base.Model.WebServices
{
    /// <summary>
    /// Manage the current web request factory
    /// </summary>
    public static class WebRequestFactory
    {
        #region Fields

        private static IWebRequestFactory _current;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the current web request factory.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static IWebRequestFactory Current
        {
            get { return _current; }
            set { _current = value; }
        }

        #endregion Properties
    }
}