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




        /// <summary>
        /// Initiate the connection to the sensibo web API
        /// </summary>
        void initiateconnection(string apikey)
        {
            try
            {
                // Check we have all the nessesary parameters to initiate the connection.
                if (apikey.Equals("")) {
                    throw new ArgumentNullException("apikey", "please initate with an apikey");
                }

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
    }

}
