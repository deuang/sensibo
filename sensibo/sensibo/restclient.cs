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
        const string producer = "application/json; charset=utf-8";
        string apikey = ""; //Enter you apikey here if you want to hard code it
        public restclient(string apiKey)
        {
            apikey = apiKey;
        }
        public pods getpods()
        {

            var request = (HttpWebRequest)WebRequest.Create(schemes + "://" + hosturl + basePath + "/users/me/pods?fields=id,room&apiKey=" + apikey);
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
        public acstatus getpodstatus(string id)
        {

            var request = (HttpWebRequest)WebRequest.Create(schemes + "://" + hosturl + basePath + "/pods/"+ id  + "/acStates?fields=status,acState&limit=1&apiKey=" + apikey);
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

                //Convert the json respons to acstatus object
                acstatus acStatus = Newtonsoft.Json.JsonConvert.DeserializeObject<acstatus>(responseValue);

                return acStatus;
            }

        }
        public measurements getpodmeasurments(string id)
        {

            var request = (HttpWebRequest)WebRequest.Create(schemes + "://" + hosturl + basePath + "/pods/" + id + "/measurements?apiKey=" + apikey);
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

                //Convert the json respons to acstatus object
                measurements mstatus = Newtonsoft.Json.JsonConvert.DeserializeObject<measurements>(responseValue);

                return mstatus;
            }

        }
        public setResult postpodstatus(string id, SetAcState targetstate)
        {

            JsonAcState Jstate = new JsonAcState();
            Jstate.acState = targetstate;

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(Jstate);
           
            var request = (HttpWebRequest)WebRequest.Create(schemes + "://" + hosturl + basePath + "/pods/" + id + "/acStates?apiKey=" + apikey);
            request.Method = "POST"; //Set the request type to GET
            request.ContentType = producer;
            

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
           
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

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

                //Convert the json respons to acstatus object
                setResult mstatus = Newtonsoft.Json.JsonConvert.DeserializeObject<setResult>(responseValue);
                return mstatus;
            }

        }

    }
}
