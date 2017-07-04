using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbio.Base.Model.WebServices.Contracts
{
    public interface IWebRequestFactory
    {
        IWebRequest Create(string url);
    }
}
