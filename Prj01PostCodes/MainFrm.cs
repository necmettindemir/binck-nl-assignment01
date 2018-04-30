using Prj01Lib.Library;
using Prj01Lib.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prj01PostCodes
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {

            FBD.SelectedPath = Environment.CurrentDirectory;


            if (FBD.ShowDialog() == DialogResult.OK)
                TBFolderPath.Text = FBD.SelectedPath;


        }

        private void btnFindLines_regEx_Click(object sender, EventArgs e)
        {
            TBLinesWithPostCode.Text = "";

            Library lib = new Library();

            Result result = lib.GetListofFileWithPostCode(TBFolderPath.Text);


            if (result.ResultCode > 0)
            {
                List<FileWithPostCode> filesWithPostCode = (List<FileWithPostCode>)result.Obj;

                TBLinesWithPostCode.Text += "-------------------" + Environment.NewLine;

                for (int i = 0; i < filesWithPostCode.Count; i++)
                {
                    List<Line> LineList = filesWithPostCode[i].GetLineList();
                    
                    TBLinesWithPostCode.Text += Environment.NewLine + "File Name : " + filesWithPostCode[i].FileName + Environment.NewLine  + Environment.NewLine;
                    

                    for (int j = 0; j < LineList.Count; j++)                   
                    {                        
                        TBLinesWithPostCode.Text += "Line Text : " + LineList[j].LineTxt + Environment.NewLine;
                        TBLinesWithPostCode.Text += "Line Num  : " + LineList[j].LineNum + Environment.NewLine + Environment.NewLine;                            
                    }

                    TBLinesWithPostCode.Text += "-------------------" + Environment.NewLine;

                }//end of for
            
            }

        }


        private void btnFindLines_Traditional_Click(object sender, EventArgs e)
        {

        }
    }
}
