using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppServer.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
           

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
           // SqlConnection conn = new SqlConnection()
           // SqlCommand command = new SqlCommand("Select * from dbo.User where username = @username and password = @password");
           // command.Parameters.AddWithValue("@username")
           // command.ExecuteNonQuery();
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
