using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace AppServer.Controllers
{
    public class LoginController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]

        // [AllowAnonymous]

        [Route("api/files/login")]
        [HttpPost]
        public async Task<string> Post(string username, string password)
        {

            try

            {


                SqlConnection conn = new SqlConnection("Data Source=cipherbot.cdnuhaolqolh.us-west-2.rds.amazonaws.com;Initial Catalog=CIpherbot_Application;Integrated Security=False;User ID=SA;Password=Dangod123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; ");
                string procedure = "LoginProcedure";

                using (conn)
                {
                    string test = ";;;";
                    SqlCommand command = new SqlCommand(procedure, conn);
                    command.CommandType = CommandType.StoredProcedure;
                     command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
    
                    command.Parameters.Add("@ExpiryDate", SqlDbType.NVarChar,30).Direction = ParameterDirection.Output;
                    conn.Open();
                    command.ExecuteNonQuery();
                    string ExpiryDate = (string)command.Parameters["@expirydate"].Value;
                    conn.Close();
                  

                    return ExpiryDate;
                }
            
              
               
            }
            catch (Exception exception)
            {
                return "ERROR";
            }
           
           
        }
    }
}