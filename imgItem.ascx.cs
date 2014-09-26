using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My_Retrieval_Page
{
    public partial class imgItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void SetImgUrl(string imgurl)
        {
  //          Response.Write(imgurl);
            this.imgCtrl.ImageUrl = imgurl;
           // this.SegmentLabel.Text = timeStamp;
        }
        public void SetClickStatus(bool is_clicked = false)
        {
            if (is_clicked == true)
            {
                imgCtrl.CssClass = "imgUpdateStyle";
            }
            else
            {
                imgCtrl.CssClass = "imgCtrlStyle";
            }
        }
        //public void SetCheckStatus(bool is_best = false)
        //{
        //    if (is_best == true)
        //    {
        //        this.markBest.Checked = true;
        //    }
        //    else
        //    {
        //        this.markBest.Checked = false;
        //    }
        //}

        protected void Click_image(object sender, EventArgs e)
        {
            //List<string> labelList = (List<string>)Session["labelList"];
            //if (labelList == null)
            //    labelList = new List<string>();
            //if (labelList.Contains(this.imgCtrl.ImageUrl))
            //{
            //    labelList.Remove(this.imgCtrl.ImageUrl);
            //    imgCtrl.CssClass = "imgCtrlStyle";
            //}
            //else
            //{
            //    labelList.Add(this.imgCtrl.ImageUrl);
            //    imgCtrl.CssClass = "imgUpdateStyle";
            //}
            //Session["labelList"] = labelList;

            int Img_Nums = 0;
            string[] img_Paths=null;
            if (Session["Img_Num"] != null && Session["Img_Paths"]!=null)
            {
                 Img_Nums = (int)Session["Img_Num"];
                 img_Paths = (string[])Session["Img_Paths"];
            }
            else
            {
                Img_Nums = 0;
     //           Response.Redirect(string.Format("mainpage.aspx?page_num={0}", 0));
            }
            //            string[] img_Paths=(string[])Session["Img_Paths"];

            string img_Name=this.imgCtrl.ImageUrl;

            int TTT=Img_Nums;

            for (int i = 0;i< Img_Nums;i++ )
            {
                if (img_Name==img_Paths[i])
                {
                    Session["ShowImg"]=img_Name;
 //                   Server.Transfer("imgDisplay.aspx");

                    Response.Redirect("imgDisplay.aspx");


                    break;
                }
            }

//            imgCtrl.CssClass = "imgCtrlStyle";

//            Server.Transfer("XXX.aspx")

//            imgCtrl.CssClass = "imgUpdateStyle";

            /*
            if (imgCtrl.CssClass == "imgCtrlStyle")
            {
                if (!labelList.Contains(this.imgCtrl.ImageUrl))
                {
                    labelList.Add(this.imgCtrl.ImageUrl);
                }
                Session["labelList"] = labelList;
                imgCtrl.CssClass = "imgUpdateStyle";
            }
            else
            {
                if (labelList.Contains(this.imgCtrl.ImageUrl))
                { 
                    labelList.Remove(this.imgCtrl.ImageUrl);
                }
                Session["labelList"] = labelList;
                imgCtrl.CssClass = "imgCtrlStyle";
            }
            */
        }

        //protected void Check(object sender, EventArgs e)
        //{
        //    List<string> bestList = (List<string>)Session["bestList"];
        //    if (bestList == null)
        //        bestList = new List<string>();
        //    if (markBest.Checked)
        //    {
        //        if (bestList.Contains(this.imgCtrl.ImageUrl))
        //            return;
        //        bestList.Add(this.imgCtrl.ImageUrl);
        //        Session["bestList"] = bestList;
        //    }
        //    else
        //    {
        //        if (bestList.Contains(this.imgCtrl.ImageUrl))
        //            bestList.Remove(this.imgCtrl.ImageUrl);
        //        Session["bestList"] = bestList;
        //    }
        //}
    }
}