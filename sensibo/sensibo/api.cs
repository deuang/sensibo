using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensibo
{
       
    public class api
    {

        //==========================================================================================//
        //This API wrapper is provided to enable anyone to integrate the senibo API into their own
        //application.
        //
        // By Duncan E Grant
        //==========================================================================================//
        private string apiKey = "";


        /// <summary>
        /// Initiate the connection to the sensibo web API
        /// </summary>
        public api(string apikey)
        {
            try
            {
                // Check we have all the nessesary parameters to initiate the connection.
                if (apikey.Equals("")) {
                    throw new ArgumentNullException("apikey", "please initate with an apikey");
                }
                apiKey = apikey;

            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine("{0} parameter exception", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} general exception", e);
            }


        }

        public sensibo.pods getPods()
        {
            sensibo.restclient sclient = new sensibo.restclient(apiKey);
            return sclient.getpods();
        }

        public sensibo.acstatus getPodStatus(string id)
        {
            sensibo.restclient sclient = new sensibo.restclient(apiKey);
            return sclient.getpodstatus(id);
        }

        public sensibo.measurements getPodMeasurments(string id)
        {
            sensibo.restclient sclient = new sensibo.restclient(apiKey);
            return sclient.getpodmeasurments(id);
        }
        public sensibo.setResult SetStatus(string id,sensibo.SetAcState state)
        {
            sensibo.restclient sclient = new sensibo.restclient(apiKey);
            return sclient.postpodstatus(id,state);
        }


    }

}
