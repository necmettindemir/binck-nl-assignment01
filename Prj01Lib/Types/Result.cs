using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prj01Lib.Types
{
    public class Result
    {
        public int ResultCode { set; get; }
        public string ResultMessage { set; get; }
        public Object Obj { set; get; }

        public Result()
        {
            ResultCode = -1;
            ResultMessage = "";
            Obj = null;
        }

        
    }
}
