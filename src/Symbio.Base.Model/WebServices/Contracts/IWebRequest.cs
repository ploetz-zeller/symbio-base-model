using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using net = System.Net;

namespace Symbio.Base.Model.WebServices.Contracts
{
    public interface IWebRequest: IDisposable
    {
        /// <summary>
        /// Get or set the Host header value to use in an HTTP request independent from the request URI.
        /// </summary>
        /// <value>
        /// The Host header value in the HTTP request.
        /// </value>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets the time-out value in milliseconds for the System.Net.HttpWebRequest.GetResponse
        /// and System.Net.HttpWebRequest.GetRequestStream methods.
        /// </summary>
        /// <value>
        /// The number of milliseconds to wait before the request times out. The default
        /// value is 100,000 milliseconds (100 seconds).
        /// </value>
        int Timeout { get; set; }

        /// <summary>
        /// Gets or sets the Content-length HTTP header.
        /// </summary>
        /// <value>
        /// The number of bytes of data to send to the Internet resource. The default is
        /// -1, which indicates the property has not been set and that there is no request
        /// data to send.
        /// </value>
        long ContentLength { get; set; }

        /// <summary>
        /// Gets the original Uniform Resource Identifier (URI) of the request.
        /// </summary>
        /// <value>
        /// A System.Uri that contains the URI of the Internet resource passed to the System.Net.WebRequest.Create(System.String) method.
        /// </value>
        Uri RequestUri { get; }

        /// <summary>
        /// Gets or sets the method for the request.
        /// </summary>
        /// <value>
        /// The request method to use to contact the Internet resource. The default value is GET.
        /// </value>
        string Method { get; set; }

        /// <summary>
        /// Gets or sets a System.Boolean value that controls whether default credentials are sent with requests.
        /// </summary>
        /// <value>
        /// true if the default credentials are used; otherwise false. The default value is false.
        /// </value>
        bool UseDefaultCredentials { get; set; }

        /// <summary>
        /// Specifies a collection of the name/value pairs that make up the HTTP headers.
        /// </summary>
        /// <value>
        /// A System.Net.WebHeaderCollection that contains the name/value pairs that make up the headers for the HTTP request.
        /// </value>
        WebHeaderCollection Headers { get; }

        /// <summary>
        /// Gets or sets the value of the Content-type HTTP header.
        /// </summary>
        /// <value>
        /// The value of the Content-type HTTP header. The default value is null.
        /// </value>
        string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the media type of the request.
        /// </summary>
        /// <value>
        /// The media type of the request. The default value is null.
        /// </value>
        string MediaType { get; set; }

        /// <summary>
        /// The value of the Transfer-encoding HTTP header. The default value is null.
        /// </summary>
        /// <value>
        /// The transfer encoding.
        /// </value>
        string TransferEncoding { get; set; }
        
        /// <summary>
        /// Gets or sets authentication information for the request.
        /// </summary>
        /// <value>
        /// An System.Net.ICredentials that contains the authentication credentials associated with the request. The default is null.
        /// </value>
        ICredentials Credentials { get; set; }
        
        /// <summary>
        /// Gets or sets the collection of security certificates that are associated with this request.
        /// </summary>
        /// <value>
        /// The System.Security.Cryptography.X509Certificates.X509CertificateCollection that contains the security certificates associated with this request.
        /// </value>
        X509CertificateCollection ClientCertificates { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is certificate validation disabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is certificate validation disabled; otherwise, <c>false</c>.
        /// </value>
        bool IsCertificateValidationDisabled { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether to make a persistent connection to the Internet resource.
        /// </summary>
        /// <value>
        /// true if the request to the Internet resource should contain a Connection HTTP header with the value Keep-alive; otherwise, false. The default is true.
        /// </value>
        bool KeepAlive { get; set; }
        
        /// <summary>
        /// Gets or sets the maximum allowed length of the response headers.
        /// </summary>
        /// <value>
        /// The length, in kilobytes (1024 bytes), of the response headers.
        /// </value>
        int MaximumResponseHeadersLength { get; set; }

        /// <summary>
        /// Gets a System.IO.Stream object to use to write request data.
        /// </summary>
        /// <returns>A System.IO.Stream to use to write request data.</returns>
        Stream GetRequestStream();

        /// <summary>
        /// Returns a response from an Internet resource.
        /// </summary>
        /// <returns>A System.Net.WebResponse that contains the response from the Internet resource.</returns>
        IWebResponse GetResponse();
    }
}
