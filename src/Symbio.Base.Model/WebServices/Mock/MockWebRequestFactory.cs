using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Symbio.Base.Model.WebServices.Contracts;

namespace Symbio.Base.Model.WebServices.Mock
{
    public class MockWebRequestFactory : IWebRequestFactory
    {
        #region Nested Types

        public class MockWebRequest : IWebRequest
        {
            #region Constructors

            public MockWebRequest(MockWebRequestFactory factory, string url, Stream requestStream, MockWebResponse mockWebResponse)
            {
                _factory = factory;
                _url = url;
                _requestStream = requestStream;
                _mockWebResponse = mockWebResponse;
            }

            #endregion Constructors

            #region Fields

            private readonly MockWebRequestFactory _factory;
            private readonly WebHeaderCollection _headers = new WebHeaderCollection();
            private readonly MockWebResponse _mockWebResponse;
            private readonly Stream _requestStream;
            private readonly string _url;

            private bool disposedValue = false; // To detect redundant calls

            #endregion Fields

            #region Properties

            public X509CertificateCollection ClientCertificates { get; set; }

            public long ContentLength { get; set; }

            public string ContentType { get; set; }

            public ICredentials Credentials { get; set; }

            public WebHeaderCollection Headers => _headers;

            public string Host { get; set; }

            public bool IsCertificateValidationDisabled { get; set; }

            public bool KeepAlive { get; set; }

            public int MaximumResponseHeadersLength { get; set; }

            public string MediaType { get; set; }

            public string Method { get; set; }

            public Uri RequestUri => new Uri(_url);

            public int Timeout { get; set; }

            public string TransferEncoding { get; set; }

            public bool UseDefaultCredentials { get; set; }

            #endregion Properties

            #region Methods

            #region Public Methods

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~MockWebRequest() {
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

            public Stream GetRequestStream() => _requestStream;

            public MockWebResponse GetResponse() => _mockWebResponse;

            IWebResponse IWebRequest.GetResponse() => GetResponse();

            #endregion Public Methods

            #region Protected Methods

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects).
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            #endregion Protected Methods

            #endregion Methods
        }

        public class MockWebResponse : IWebResponse
        {
            #region Constructors

            public MockWebResponse(MockWebRequestFactory factory, Stream responseStream)
            {
                _factory = factory;
                _responseStream = responseStream;
            }

            #endregion Constructors

            #region Fields

            private readonly MockWebRequestFactory _factory;
            private readonly WebHeaderCollection _headers = new WebHeaderCollection();
            private readonly Stream _responseStream;

            private bool disposedValue = false; // To detect redundant calls

            #endregion Fields

            #region Properties

            public string ContentEncoding { get; set; }

            public long ContentLength => _responseStream.Length;

            public string ContentType { get; set; }

            public WebHeaderCollection Headers => _headers;

            public string Method { get; set; }

            public HttpStatusCode StatusCode { get; set; }

            #endregion Properties

            #region Methods

            #region Public Methods

            public void Close()
            {
                //do nothing
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~MockWebResponse() {
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

            public string GetResponseHeader(string headerName) => Headers[headerName];

            public Stream GetResponseStream() => _responseStream;

            #endregion Public Methods

            #region Protected Methods

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects).
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    disposedValue = true;
                }
            }

            #endregion Protected Methods

            #endregion Methods
        }

        #endregion Nested Types

        #region Fields

        private IDictionary<string, MockWebRequest> _mockups = new Dictionary<string, MockWebRequest>();

        #endregion Fields

        #region Methods

        #region Public Methods

        public void AddMockup(string url, Stream requestStream, Stream responseStream)
        {
            var response = new MockWebResponse(this, responseStream);
            response.StatusCode = HttpStatusCode.OK;
            var request = new MockWebRequest(this, url, requestStream, response);
            _mockups.Add(url, request);
        }

        public void AddMockup(string url, Encoding encoding, string requestString, string responseString)
        {
            var response = new MockWebResponse(this, new MemoryStream(encoding.GetBytes(responseString)));
            response.StatusCode = HttpStatusCode.OK;
            var request = new MockWebRequest(this, url, new MemoryStream(encoding.GetBytes(requestString)), response);
            _mockups.Add(url, request);
        }

        public void AddMockup(string url, byte[] requestData, byte[] responseData)
        {
            var response = new MockWebResponse(this, new MemoryStream(responseData));
            response.StatusCode = HttpStatusCode.OK;
            var request = new MockWebRequest(this, url, new MemoryStream(requestData), response);
            _mockups.Add(url, request);
        }

        public IWebRequest Create(string url)
        {
            if (!_mockups.ContainsKey(url))
                throw new ArgumentException($"Mockup for url {url} was not missing.");

            return _mockups[url];
        }

        #endregion Public Methods

        #endregion Methods
    }
}