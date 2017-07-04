using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Shouldly;

using Symbio.Base.Model.WebServices;
using Symbio.Base.Model.WebServices.Mock;

namespace Symbio.Base.Model.Tests
{
    public class MockWebRequestFactory_Tests
    {
        #region Methods

        #region Public Methods

        [Test(Author = "thomas.hauser@p-und-z.de")]
        public void Mockup_WebRequest_With_Response()
        {
            //arrange
            var request = WebRequestFactory.Current.Create("http://helloworld.com/sayhello");

            //act
            var resp = request.GetResponse();

            var data = new byte[resp.ContentLength];
            using (var respStream = resp.GetResponseStream())
                respStream.Read(data, 0, data.Length);

            var text = Encoding.UTF8.GetString(data);

            //assert
            text.ShouldBe("world");
        }

        [SetUp]
        public void Setup()
        {
            MockWebRequestFactory factory = new MockWebRequestFactory();
            factory.AddMockup("http://helloworld.com/sayhello", Encoding.UTF8, "hello", "world");
            WebRequestFactory.Current = factory;
        }

        #endregion Public Methods

        #endregion Methods
    }
}