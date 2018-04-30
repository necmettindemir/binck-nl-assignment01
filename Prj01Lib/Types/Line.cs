using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prj01Lib.Types
{
    public class Line
    {
        string _lineTxt;
        int _lineNum;


        public string LineTxt
        {
            get { return _lineTxt; }
            set { _lineTxt = value; }
        }


        public int LineNum
        {
            get { return _lineNum; }
            set { _lineNum = value; }
        }


    }
}
