﻿

----------------------------------------------

Assignment

1. We have some legacy data, which we would like to transform. 
   Legacy data is stored in flat files on a file-system. 
   Some of the files include post codes and we need to identify, where that data is and 
   pull out the lines, which include post codes. 
   
   Please provide code which will do the above.

----------------------------------------------

Assumptions


1) It is supposed that all legacy flat files are in the folder ExampleFiles. 
   However, there is nothing about the structure of flat files.
   I suppose that these files may be as below, in part Example Files.

   Folder of example files can be selected using application interface.
   ExampleFiles folder is in this solution.

   In this application interface is windows based.


2) It is supposed that there are tabs between columns. 
   However, the place of the postcodes may be different.


3) It is supposed that all postcodes are length of 5 and all chars in postcode are numeric.
   It is assumed that postcode of cities in Turkey are being searched.

   if this scenario is aimed to find postcodes of cities in different countries
   we would make list of all patterns about possible postcodes.


----------------------------------------------

Solutions

There are two ways to solve this problem

1) Of course, regular expression is the first choice for such a problem.

2) Traditional solution parsing each line of each files could be possible -- we are ignoring this


According to the assumptions above
the solution with regular expression looking better. 

So, the solution with regular expression is developed in Microsoft .NET 4.0 Win App.

----------------------------------------------

About this Solution

This soluiton consists of two projects
- GUI project that is win app  (Prj01PostCodes), SLN file is here.
- Library project that is class library project (Prj01Lib)

Library.cs is a library file of Prj01Lib ClassLibrary project .
It contains a method getting folderPath as input parameter and returning list of what is desired.
It can be used as managed dll in any other project for such an aim.



----------------------------------------------

Content of Files



Content of TextFile1 : includes post code in 3rd column

Lionel		Messi	01234	Adana
Christiano	Ronaldo			Mersin
Eden		Hazard	44544	Malatya




Content of TextFile2 : does not include post code

John	Steincbeck	Artvin
Ernest	Hemingway	Yozgat
Emile	Zola		Kutahya



Content of TextFile3 : includes post code in some columns

Louis	Pasteur		Nigde		51332
Thomas	Edison					Bursa
Albert	Einstein	Eskisehir	26833	


----------------------------------------------

Afer running project the result is shown as below.


-------------------

File Name : TextFile01.txt

Line Text : Lionel		Messi	01234	Adana
Line Num  : 1

Line Text : Eden		Hazard	44544	Malatya
Line Num  : 3

-------------------

File Name : TextFile03.txt

Line Text : Louis	Pasteur		Nigde		51332
Line Num  : 1

Line Text : Albert	Einstein	Eskisehir	26833
Line Num  : 3

-------------------


----------------------------------------------

Tehcnical Design for List

LookAtMe_Prj01_FindPostcodes.png


-----------------------------------------------

The Code of The Assignment is below.
The project can be run through Prj01_compressed.rar



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

