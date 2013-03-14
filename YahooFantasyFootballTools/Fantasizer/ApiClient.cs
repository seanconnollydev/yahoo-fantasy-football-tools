using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Fantasizer
{
    internal class ApiClient
    {
        private readonly OAuthClient _oAuthClient;

        public ApiClient (OAuthClient oAuthClient)
        {
            _oAuthClient = oAuthClient;
        }

        public XDocument ExecuteRequest(string requestUri)
        {
            var request = _oAuthClient.PrepareAuthorizedRequest(requestUri);

            XDocument xmlDoc;
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    xmlDoc = XDocument.Load(responseStream);
                }
            }

            return xmlDoc;
        }
    }
}
