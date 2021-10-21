using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Testing_Raxer_Chroma_SDK
{ 
    public class RESTClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public string postJSON { get; set; }

        public RESTClient(string endPoint, httpVerb httpMethod, string postJSON = "")
        {
            this.endPoint = endPoint;
            this.httpMethod = httpMethod;
            this.postJSON = postJSON;
        }

        public string makeRequest()
        {
            var strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            switch (httpMethod)
            {
                case httpVerb.POST:
                case httpVerb.PUT:
                case httpVerb.DELETE:
                    request.ContentType = "application/json";
                    using (StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream()))
                    {
                        swJSONPayload.Write(postJSON);

                        swJSONPayload.Close();
                    }
                    break;
            }

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }
    }
}
