using System;

using GalaSoft.MvvmLight;
using MyCouch;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Windows.Storage;

namespace CryptoFolio.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        public LoginViewModel()
        {

        }

        /// <summary>
        /// A Task which attempts to login a user on the cloud DB.
        /// Opens a connection to the CouchDB instance and prepares a login object.
        /// This object is passed via a POST request to the CouchDB client which returns a result.
        /// Based on this result we will either store the valid settings and return true
        /// Or return false
        /// The last task is then closing the DB connection. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns>Boolean</returns>
        public async Task<Boolean> loginUser(String username, String pass)
        {
            string _id = "org.couchdb.user:";

            try
            {
                // connect to _session endpoint
                using (var client = new MyCouchClient("http://admincouch:supersecret123@couchaccountservice.westeurope.cloudapp.azure.com:5984", "_session"))
                {
                    //create a new json object we can post to couch endpoint
                    var json = new JObject();
                    //attached the credentials
                    json.Add("name", username);
                    json.Add("password", pass);



                    // send post to CouchDB to create user and use result to decide how to proceed
                    var result = await client.Documents.PostAsync(json.ToString());

                    
                    System.Diagnostics.Debug.WriteLine(json);

                    //Debug the result
                    //TODO: remove in prod
                    System.Diagnostics.Debug.WriteLine("Results: " + result.IsSuccess);
                    System.Diagnostics.Debug.WriteLine("Error: " + result.Error);
                    System.Diagnostics.Debug.WriteLine("Reason: " + result.Reason);


                    // if successful
                    if (result.IsSuccess)
                    {
                        //If we make it here, we have successfully registered the user.Now we will save these details to localStorage
                        var localSettings = ApplicationData.Current.LocalSettings;

                        localSettings.Values["CurrentUsername"] = username;
                        localSettings.Values["CurrentUserpassword"] = pass;
                        //return value to the view
                        return true;
                    }
                    else
                    {
                        //return value to the view 
                        return false;
                    } // if

                } // using
            }
            //Reaching here indicates some code exception was raised or other non predicted outcome. Log it.
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            } // try

        }
    }
}
