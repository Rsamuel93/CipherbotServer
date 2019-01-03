using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppServer
{
    public class GlobalVars

    {
        public static string strfilename;
        public static string strNewPath;
        public static string virtualDirectory = @"C:\Automation\CipherbotApp\AppServer\AppServer\Upload\";
        public static string basePath = @"C:\Automation\CipherbotApp\AppServer\AppServer\Uploads\";
        public static string pattern = @"(?<=^|_)(\""""(?:[^\""""]|\""""\"""")*\""""|[^,]*)_(?<=^|_)(\""""(?:[^\""""]|\""""\"""")*\""""|[^,]*)_(?<=^|_)(\""""(?:[^\""""]|\""""\"""")*\""""|[^,]*)_(?<=^|_)(\""""(?:[^\""""]|\""""\"""")*\""""|[^,]*)_(?<=^|_)(\""""(?:[^\""""]|\""""\"""")*\""""|[^,]*)_(?<=^|_)(\""""(?:[^\""""]|\""""\"""")*\""""|[^,]*)";
        public static string connection = "Data Source=cipherbot.cdnuhaolqolh.us-west-2.rds.amazonaws.com;Initial Catalog=CIpherbot_Application;Integrated Security=False;User ID=SA;Password=Dangod123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
    }
}