using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace sensibo.sensibo
{
    
    class restclient
    {
        const string hosturl = "home.sensibo.com";
        const string basePath = "/api/v2";
        const string schemes = "https";
        const string consumer = "application/json";
        const string producer = "application/json";
        const string apikey = ""; //Enter you apikey here if you want to hard code it
        
        public pods getpods()
        {
           
            var request = (HttpWebRequest)WebRequest.Create(schemes + "://" + hosturl +  basePath + "/users/me/pods?apiKey=" + apikey );
            request.Method = "GET"; //Set the request type to GET
            request.ContentType = consumer;
  
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                //Convert the json respons to pods object
                pods podlist = Newtonsoft.Json.JsonConvert.DeserializeObject<pods>(responseValue);

                return podlist;
            }
        }
     
    }
}
