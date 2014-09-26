using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

namespace My_Retrieval_Page
{
    public partial class imgDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string imgName = (string)Session["ShowImg"];

            if (imgName!=null)
            {
                this.ImgDis.ImageUrl = imgName;


                int idx = imgName.IndexOf(".");
                string imgExif = imgName.Substring(0, idx);

                imgExif += ".exif";
                string Exif_Path=Server.MapPath("~/");

                imgExif = Exif_Path + imgExif;

                if (File.Exists(imgExif))
                {
                    string[] lines = File.ReadAllLines(imgExif);

                    string infor_Dis = "";

                    foreach (string part_Infor in lines)
                    {
                        infor_Dis += part_Infor;
                        infor_Dis += "\n";
                    }

                    this.ImageInfor.Text = infor_Dis;
                }
            }
        }
    }
}