using Prj01Lib.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Prj01Lib.Library
{
    public class Library
    {
        /// <summary>
        /// if resultCode in result  is positive it means everything is ok, if negative it means at least something is wrong
        /// </summary>
        /// <param name="FolderPath">Assuming all legacy files are in this Folder</param>
        /// <returns></returns>
        public Result GetListofFileWithPostCode(string FolderPath)
        {

            Result result = new Result();
            List<FileWithPostCode> filesWithPostCode= new List<FileWithPostCode>();

            try
            {

                #region search-all-files

                DirectoryInfo d = new DirectoryInfo(FolderPath);    //Assuming all legacy files are in this Folder
                FileInfo[] files = d.GetFiles("*.txt");             //Assumign all legacy files are Text files
                
                foreach (FileInfo fileinfo in files)
                {                    

                    string[] lines = File.ReadAllLines(fileinfo.FullName);

                    for (int i = 0; i < lines.Length; i++)
                    {
                                                
                        string[] items = lines[i].Split('\t');

                        for (int j = 0; j < items.Length; j++)
                        {

                            if (Regex.IsMatch(items[j], "^[0-9]{5}$") == true) //^[0-9]{5}$ : to search for matching of 5 digit item
                            {
                                Result resultOfAdding = Add2List(lines[i], i+1, fileinfo, filesWithPostCode); //i : 0-based, send it adding 1 for real line number
                                //resultOfAdding can be evaluated..

                                break;//this line includes postcode.. no need to continue searching
                            }

                        }//enf of for j
                           
                    }//enf od for i 

                }//end of for fileinfo


                #endregion search-all-files
                
                result.Obj = filesWithPostCode;
                result.ResultCode = 1;
                result.ResultMessage = "OK";

            }
            catch (Exception ex)
            {
                result = new Result { ResultCode = -1100, ResultMessage = "opps!" + ex.Message };                
            }
            

            return result;
        }


        public Result Add2List(string lineTxt, int lineNum, FileInfo file, List<FileWithPostCode> filesWithPostCode)
        {

            Result result = new Result();

            try
            {
                 bool fileFoundinList = false;

                FileWithPostCode fpc = new  FileWithPostCode();

                //------ search file that it is in list or not ---

                for (int i = 0; i < filesWithPostCode.Count ; i++)
                {

                    if (filesWithPostCode[i].FilePath == file.FullName)
                    {
                        fpc = filesWithPostCode[i];
                        fileFoundinList = true;
                        break;
                    }

                }//end of for

                //------ /search file that it is in list or not ---

                fpc.FileName = file.Name;
                fpc.FilePath = file.FullName;
                fpc.AddToLineList(new Line { LineTxt = lineTxt, LineNum = lineNum });

                if (fileFoundinList == false)
                    filesWithPostCode.Add(fpc);

                result = new Result { ResultCode = 1, ResultMessage = "OK" };

            }
            catch (Exception ex)
            {
                result = new Result { ResultCode = -100, ResultMessage = "opps! " + ex.Message };
            }


            return result;

        }

    }
}
