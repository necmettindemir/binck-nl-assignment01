using Prj01Lib.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prj01Lib.Types
{
    public class FileWithPostCode
    {

        string _fileName;
        string _filePath;
        List<Line> LineList;

        public FileWithPostCode()
        {
            LineList = new List<Line>();
        }

        public Result AddToLineList(Line item)
        {
            Result result = new Result();
            try
            {
                LineList.Add(item);

                result = new Result { ResultCode = 1, ResultMessage = "OK" };
                
            }
            catch (Exception ex)
            {
                result = new Result { ResultCode = -10, ResultMessage = "opps - "  + ex.Message };
            }

            return result;
        }

        public List<Line> GetLineList()
        {
            return LineList;
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

    }
}
