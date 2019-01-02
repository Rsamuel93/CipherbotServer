using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AppServer.Controllers
{
    public class UploadsController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]

        // [AllowAnonymous]

        [Route("api/files/Upload")]
        [HttpPost]
        public async Task<string> Post()
        {

            try
            {
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                        GlobalVars.strfilename = fileName.ToString();
                    
                      
                         var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName );
                         postedFile.SaveAs(filePath);

                        TriggerProcs.CreateDirectory(fileName);
                        TriggerProcs.Insert_Upload();
                        TriggerProcs.MoveFile();
                        //fdgdfg
                        return "/Uploads/" + fileName;
                       
                    }
                }
            }
            catch (Exception exception)
            {
                
                return exception.Message;
               
            }

            return "no files";
        }
    }
}