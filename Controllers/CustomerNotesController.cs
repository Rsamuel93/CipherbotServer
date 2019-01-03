using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AppServer.Controllers
{
    public class CustomerNotesController : ApiController
    {
        [Route("api/files/CustomerNotes")]
        [HttpPost]
        public async Task<string> Post(string CustomerNotes, string strguid ,string strfilename , string millisecond )
        {

            try
            {
               
                string strnotesfilename = strguid + "_" + strfilename + "_" + millisecond ;
                var txtFile = Path.Combine(GlobalVars.basePath , strnotesfilename, "Notes.txt");
                if (!File.Exists(txtFile))
                {
                    FileStream fs = File.Create(txtFile);
                 
                    
                    try
                    {
                       
                        File.WriteAllText(txtFile, CustomerNotes);
                    }
                    finally
                    {
                        fs.Dispose();
                    }


                }
                else if (File.Exists(txtFile))
                {
                    File.AppendAllLines(txtFile, new[] {CustomerNotes });
                    
                }
            }
            catch (Exception exception)
            {

                return exception.Message;

            }

            return "Notes Already Exist";
        }
    }
}