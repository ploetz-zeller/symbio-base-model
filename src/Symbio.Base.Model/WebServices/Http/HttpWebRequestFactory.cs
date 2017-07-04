using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Symbio.Base.Model.WebServices.Contracts;

using net = System.Net;

namespace Symbio.Base.Model.WebServices.Http
{
    public class HttpWebRequestFactory : IWebRequestFactory
    {
        #region Nested Types

        private class HttpWebRequest : IWebRequest
        {
            #region Constructors

            public HttpWebRequest(IWebRequestFactory factory, net.HttpWebRequest webRequest)
            {
                _factory = factory;
                _webRequest = webRequest;
            }

            #endregion Constructors

            #region Fields

            private readonly IWebRequestFactory _factory;
            private readonly net.HttpWebRequest _webRequest;

            private bool disposedValue = false; // To detect redundant calls

            #endregion Fields

            #region Properties

            public X509CertificateCollection ClientCertificates
            {
                get { return _webRequest.ClientCertificates; }
                set { _webRequest.ClientCertificates = value; }
            }

            public long ContentLength
            {
                get { return _webRequest.ContentLength; }
                set { _webRequest.ContentLength = value; }
            }

            public string ContentType
            {
                get { return _webRequest.ContentType; }
                set { _webRequest.ContentType = value; }
            }

            public net.ICredentials Credentials
            {
                get { return _webRequest.Credentials; }
                set { _webRequest.Credentials = value; }
            }

            public net.WebHeaderCollection Headers => _webRequest.Headers;

            public string Host
            {
                get { return _webRequest.Host; }
                set { _webRequest.Host = value; }
            }

            public bool IsCertificateValidationDisabled
            {
                get { return _webRequest.ServerCertificateValidationCallback != null; }
                set { _webRequest.ServerCertificateValidationCallback = value ? (s, cert, chain, errors) => true : default(net.Security.RemoteCertificateValidationCallback); }
            }

            public bool KeepAlive
            {
                get { return _webRequest.KeepAlive; }
                set { _webRequest.KeepAlive = value; }
            }

            public int MaximumResponseHeadersLength
            {
                get { return _webRequest.MaximumResponseHeadersLength; }
                set { _webRequest.MaximumResponseHeadersLength = value; }
            }

            public string MediaType
            {
                get { return _webRequest.MediaType; }
                set { _webRequest.MediaType = value; }
            }

            public string Method
            {
                get { return _webRequest.Method; }
                set { _webRequest.Method = value; }
            }

            public Uri RequestUri => _webRequest.RequestUri;

            public int Timeout
            {
                get { return _webRequest.Timeout; }
                set { _webRequest.Timeout = value; }
            }

            public string TransferEncoding
            {
                get { return _webRequest.TransferEncoding; }
                set { _webRequest.TransferEncoding = value; }
            }

            public bool UseDefaultCredentials
            {
                get { return _webRequest.UseDefaultCredentials; }
                set { _webRequest.UseDefaultCredentials = value; }
            }

            #endregion Properties

            #region Methods

            #region Public Methods

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~HttpWebRequest() {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }
            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                // TODO: uncomment the following line if the finalizer is overridden above.
                // GC.SuppressFinalize(this);
            }

            public Stream GetRequestStream() => _webRequest.GetRequestStream();

            public HttpWebResponse GetResponse() => new HttpWebResponse(_factory, this, (net.HttpWebResponse)_webRequest.GetResponse());

            IWebResponse IWebRequest.GetResponse()
            {
                return GetResponse();
            }

            #endregion Public Methods

            #region Protected Methods

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {

                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            #endregion Protected Methods

            #endregion Methods
        }

        private class HttpWebResponse : IWebResponse
        {
            #region Constructors

            public HttpWebResponse(IWebRequestFactory factory, HttpWebRequest httpWebRequest, net.HttpWebResponse webResponse)
            {
                _factory = factory;
                _httpWebRequest = httpWebRequest;
                _httpWebResponse = webResponse;
            }

            #endregion Constructors

            #region Fields

            private readonly IWebRequestFactory _factory;
            private readonly HttpWebRequest _httpWebRequest;
            private readonly net.HttpWebResponse _httpWebResponse;

            private bool disposedValue = false; // To detect redundant calls

            #endregion Fields

            #region Properties

            public string ContentEncoding => _httpWebResponse.ContentEncoding;

            public long ContentLength => _httpWebResponse.ContentLength;

            public string ContentType => _httpWebResponse.ContentType;

            public net.WebHeaderCollection Headers => _httpWebResponse.Headers;

            public string Method => _httpWebResponse.Method;

            public net.HttpStatusCode StatusCode => _httpWebResponse.StatusCode;

            #endregion Properties

            #region Methods

            #region Public Methods

            public void Close() => _httpWebResponse.Close();

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~HttpWebResponse() {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }
            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                // TODO: uncomment the following line if the finalizer is overridden above.
                // GC.SuppressFinalize(this);
            }

            public string GetResponseHeader(string headerName) => _httpWebResponse.GetResponseHeader(headerName);

            public Stream GetResponseStream() => _httpWebResponse.GetResponseStream();

            #endregion Public Methods

            #region Protected Methods

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        _httpWebResponse.Dispose();
                        _httpWebRequest.Dispose();
                    }

                    disposedValue = true;
                }
            }

            #endregion Protected Methods

            #endregion Methods
        }

        #endregion Nested Types

        #region Methods

        #region Public Methods

        public IWebRequest Create(string url) => new HttpWebRequest(this, (net.HttpWebRequest)net.HttpWebRequest.Create(url));

        #endregion Public Methods

        #endregion Methods
    }
}