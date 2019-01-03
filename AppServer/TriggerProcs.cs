using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AppServer
{

    public class TriggerProcs
    {

        public static string strFilename;
        public static string strSenderName;
        public static string strRecipientEmail;
        public static string strpagenumber;
        public static string strmilisecond;
        public static string strGuid;
        public static string strNewDirectory;
        public static void Insert_Upload()
        {

            try
            {
                

                SqlConnection conn = new SqlConnection(GlobalVars.connection);
                string procedure = "InsertUpload";

                using (conn)
                {

                    SqlCommand command = new SqlCommand(procedure, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Filename", strFilename + strmilisecond);
                    command.Parameters.AddWithValue("@SenderName", strSenderName);
                    command.Parameters.AddWithValue("@RecipientEmail", strRecipientEmail);
                    command.Parameters.AddWithValue("@companyguid", strGuid);
                    command.Parameters.AddWithValue("@PageNumber", strpagenumber);
                    conn.Open();
                    command.ExecuteNonQuery();

                    conn.Close();



                }
            }
            catch (Exception e)
            {

            }
        }
        public static void CreateDirectory(string strUploadDetails)
        {
            try
            {
                RegexOptions options = RegexOptions.Multiline;

                foreach (Match m in Regex.Matches(strUploadDetails, GlobalVars.pattern, options))
                {
                    strSenderName = m.Groups[1].Value;
                    strRecipientEmail = m.Groups[2].Value;
                    strFilename = m.Groups[3].Value;
                    strGuid = m.Groups[4].Value;
                    strmilisecond = m.Groups[5].Value;
                    strpagenumber = m.Groups[6].Value.Substring(0, m.Groups[6].Value.LastIndexOf('.'));

                }
               
                var newdirectory = GlobalVars.basePath + strGuid + "_" + strFilename + "_" + strmilisecond;
                if (Directory.Exists(newdirectory))
                {
                    return;
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(newdirectory);
                  

                }
                strNewDirectory = newdirectory;




            }
            catch (Exception e)
            {

            }
           
        }
        public static void MoveFile()
        {
            string fileToMove = GlobalVars.virtualDirectory + strSenderName + "_" + strRecipientEmail + "_" + strFilename + "_" + strGuid + "_" + strmilisecond + "_" + strpagenumber + ".jpg";


            string moveTo = Path.Combine(strNewDirectory, Path.GetFileName(fileToMove));
            File.Move(fileToMove, moveTo);
        }

    }
}
