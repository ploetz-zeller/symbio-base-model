using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace Symbio.Base.Model.Web.Mvc
{
    public class FromHeaderBinding : HttpParameterBinding
    {
        #region Constructors

        public FromHeaderBinding(HttpParameterDescriptor parameter, string headerName)
            : base(parameter)
        {
            if (string.IsNullOrEmpty(headerName))
                throw new ArgumentNullException("headerName");

            _headerName = headerName;
        }

        #endregion Constructors

        #region Fields

        private readonly string _headerName;

        #endregion Fields

        #region Methods

        #region Public Methods

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.Request.Headers.TryGetValues(_headerName, out IEnumerable<string> values))
                actionContext.ActionArguments[Descriptor.ParameterName] = values.FirstOrDefault();

            var taskSource = new TaskCompletionSource<object>();
            taskSource.SetResult(null);
            return taskSource.Task;
        }

        #endregion Public Methods

        #endregion Methods
    }
}