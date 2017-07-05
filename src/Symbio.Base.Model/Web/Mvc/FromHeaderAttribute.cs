using System.Web.Http;
using System.Web.Http.Controllers;

namespace Symbio.Base.Model.Web.Mvc
{
    public class FromHeaderAttribute : ParameterBindingAttribute
    {
        #region Constructors

        public FromHeaderAttribute(string headerName)
        {
            _headerName = headerName;
        }

        #endregion Constructors

        #region Fields

        private readonly string _headerName;

        #endregion Fields

        #region Methods

        #region Public Methods

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new FromHeaderBinding(parameter, _headerName);
        }

        #endregion Public Methods

        #endregion Methods
    }
}