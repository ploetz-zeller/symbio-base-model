using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net = System.Net;

namespace Symbio.Base.Model.WebServices.Contracts
{
    public interface IWebResponse : IDisposable
    {
        /// <summary>
        /// Gets the status of the response.
        /// </summary>
        /// <value>
        /// One of the System.Net.HttpStatusCode values.
        /// </value>
        net.HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the content type of the response.
        /// </summary>
        /// <value>
        /// A string that contains the content type of the response.
        /// </value>
        string ContentType { get; }

        /// <summary>
        /// Gets the method that is used to encode the body of the response.
        /// </summary>
        /// <value>
        /// A string that describes the method that is used to encode the body of the response.
        /// </value>
        string ContentEncoding { get; }

        /// <summary>
        /// Gets the method that is used to return the response.
        /// </summary>
        /// <value>
        /// A string that contains the HTTP method that is used to return the response.
        /// </value>
        string Method { get; }

        /// <summary>
        /// Gets the headers that are associated with this response from the server.
        /// </summary>
        /// <value>
        /// A System.Net.WebHeaderCollection that contains the header information returned with the response.
        /// </value>
        net.WebHeaderCollection Headers { get; }

        /// <summary>
        /// Gets the length of the content returned by the request.
        /// </summary>
        /// <value>
        /// The number of bytes returned by the request. Content length does not include header information.
        /// </value>
        long ContentLength { get; }

        /// <summary>
        /// Closes the response stream.
        /// </summary>
        void Close();

        /// <summary>
        /// Gets the contents of a header that was returned with the response.
        /// </summary>
        /// <param name="headerName">The header value to return.</param>
        /// <returns>The contents of the specified header.</returns>
        string GetResponseHeader(string headerName);

        /// <summary>
        /// Gets the stream that is used to read the body of the response from the server.
        /// </summary>
        /// <returns>A System.IO.Stream containing the body of the response.</returns>
        Stream GetResponseStream();

    }
}
