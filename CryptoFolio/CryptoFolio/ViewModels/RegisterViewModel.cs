using System;

using GalaSoft.MvvmLight;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json.Linq;
using Windows.Storage;
using MyCouch;

namespace CryptoFolio.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel()
        {
        }
        //A utility function used to convert a hexadecimal encoded string into a normal string
        private string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }
        //A utility function used to convert a string into a hex encoded string
        private string StringToHex(string stringToConvert)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char t in stringToConvert)
            {
                //Note: X for upper, x for lower case letters
                sb.Append(Convert.ToInt32(t).ToString("x"));
            }
            return sb.ToString();
        }
        
        /// <summary>
        /// A Task which attempts to create a user on the cloud DB.
        /// Opens a connection to the CouchDB instance and prepares a register object.
        /// This object is passed via a POST request to the CouchDB client which returns a result.
        /// Based on this result we will either store the valid settings and return true
        /// Or return false
        /// The last task is then closing the DB connection. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns>Boolean</returns>
        public async Task<Boolean> createUser(String username, String pass)
        {
            

        }
    }
}
