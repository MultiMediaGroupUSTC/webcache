using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace My_Retrieval_Page
{
    public partial class mainpage : System.Web.UI.Page
    {
        static int imgNumber;
        static float[,] DCNN_Features;
        static string[] img_Paths;

        static bool Data_Load=false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false && Data_Load==false)
            {
                Data_Load = true;

                string userfilepath = Server.MapPath((string)Session["userpath"]);
                string abs_path = userfilepath + "\\AVA_DCNN_DataBase.txt";


              //  int imgNumber = 0;

                imgNumber = 0;

                FileStream m_FileStream = new FileStream(abs_path, FileMode.Open, FileAccess.Read);
                BinaryReader m_BR = new BinaryReader(m_FileStream);

                imgNumber = m_BR.ReadInt32();
                int DCNN_Dims = 4096;
              //  float[,] DCNN_Features=new float[imgNumber,DCNN_Dims];

                DCNN_Features = new float[imgNumber, DCNN_Dims];


                for (int i = 0; i < imgNumber; i++)
                {
                    for (int j = 0; j < DCNN_Dims; j++)
                    {
                        DCNN_Features[i, j] = m_BR.ReadSingle();
                    }
                }

//                string[] img_Paths = new string[imgNumber];

                img_Paths = new string[imgNumber];


                for (int i = 0; i < imgNumber; i++)
                {
                    //char[] Te_Img=new char[260];

                    //Te_Img=m_BR.ReadChars(260);

                    //img_Paths[i]=new string(Te_Img);

                    byte[] Te_Img = new byte[260];
                    Te_Img = m_BR.ReadBytes(260);

                    img_Paths[i] = System.Text.Encoding.Default.GetString(Te_Img);

                    int idx = img_Paths[i].IndexOf(".");
                    img_Paths[i] = img_Paths[i].Substring(0, idx + 4);

                }


            }

            Session["Img_Num"] = imgNumber;
            Session["Img_Paths"] = img_Paths;

            //if (Page.IsPostBack == false) // 若页面是第一次生成,则...
            //{
            //    if (Session["userpath"] == null)
            //    {
            //        Response.Redirect("mainpage.aspx");
            //    }
            //} // 以上填入数据载入部分的代码;

            //  string userfilepath = Server.MapPath((string)Session["userpath"]);
            //  //        this.imgPanel.Controls.Clear();  // 
            // // List<string> imgPathList = new List<string>();
            //  string abs_path = userfilepath + "\\AVA_DCNN_DataBase.txt";


            //  int imgNumber=0;
            //  FileStream m_FileStream=new FileStream(abs_path,FileMode.Open,FileAccess.Read);
            //  BinaryReader m_BR=new BinaryReader(m_FileStream);

            //  imgNumber=m_BR.ReadInt32();
            //  int DCNN_Dims=4096;
            ////  float[,] DCNN_Features=new float[imgNumber,DCNN_Dims];

            //  DCNN_Features = new float[imgNumber, DCNN_Dims];


            //  for (int i=0; i<imgNumber ;i++ )
            //  {
            //      for (int j = 0;j<DCNN_Dims ;j++ )
            //      {
            //          DCNN_Features[i,j]=m_BR.ReadSingle();
            //      }
            //  }

            //  string[] img_Paths=new string[imgNumber];
            //  for (int i=0; i<imgNumber;i++ )
            //  {
            //      //char[] Te_Img=new char[260];

            //      //Te_Img=m_BR.ReadChars(260);

            //      //img_Paths[i]=new string(Te_Img);

            //      byte[] Te_Img=new byte[260];
            //      Te_Img = m_BR.ReadBytes(260);

            //      img_Paths[i]=System.Text.Encoding.Default.GetString(Te_Img);

            //      int idx = img_Paths[i].IndexOf(".");
            //      img_Paths[i] = img_Paths[i].Substring(0, idx + 4);

            //  }

            //////////////////////////////////////////////////////



            List<int> img_Similarity = (List<int>)Session["img_Similarity"];
            if (img_Similarity == null)
            {
                img_Similarity = new List<int>();
                for (int i = 0; i < imgNumber; i++)
                {
                    img_Similarity.Add(i);
                }
                Session["img_Similarity"] = img_Similarity;
            }

//            string MT_Aesth = (string)Session["Aesth_Quality"];
            this.AesthQuality.Text = (string)Session["Aesth_Quality"];

            string Ass_Img=(string)Session["AssessImage"];
            if (Ass_Img==null)
            {
                this.Image1.ImageUrl="~/images/1.jpg";
            }
            else
            {
                this.Image1.ImageUrl = (string)Session["AssessImage"]; 
            }

            int page_num = 0;
            if (Page.IsPostBack == false)//the first time to load the current form.
            {
                try
                {
                    page_num = int.Parse(Request.QueryString["page_num"]);
                }
                catch (Exception)
                {
                    page_num = 0;
                }
                Session["curPageNum"] = page_num;
                this.GoToPage.Text = page_num.ToString();
            }
            else
            {
                page_num = (int)Session["curPageNum"];
            }
            //show image
            int pageNumPerPage = 30;
            int startPos = page_num * pageNumPerPage;
            int endPos = startPos + pageNumPerPage;
            //            int numpages = imgPathList.Count / pageNumPerPage;
            int numpages = imgNumber / pageNumPerPage;

            Session["num_pages"] = numpages;
            //     if (startPos >= imgPathList.Count)
            if (startPos >= imgNumber)
            {
                //this.SaveResult();
                int page_index = (int)Session["num_pages"];
                Session["curPageNum"] = page_index;
                Response.Redirect("Read Me.aspx");
            }
            if (startPos < 0)
            {
                Response.Redirect("Default.aspx");
                page_num = 0;
                Session["curPageNum"] = 0;
            }
            //            endPos = endPos <= imgPathList.Count ? endPos : imgPathList.Count;
            endPos = endPos <= imgNumber ? endPos : imgNumber;

            for (int imgPos = startPos; imgPos < endPos; imgPos++)
            {
                //string imgpath = path;
                //                this.LoadImages(imgPathList[img_Similarity[imgPos]]);
                this.LoadImages(img_Paths[img_Similarity[imgPos]]);
            }
        }



        protected void LoadImages(string imgpath)
        {
            imgItem item = (imgItem)LoadControl("~/imgItem.ascx");
            item.SetImgUrl(imgpath);
            this.imgPanel.Controls.Add(item);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            int page_num = (int)Session["curPageNum"];
            Response.Redirect(string.Format("mainpage.aspx?page_num={0}", ++page_num));
        }
        protected void btnForward_Click(object sender, EventArgs e)
        {
            int page_num = (int)Session["curPageNum"];
            Response.Redirect(string.Format("mainpage.aspx?page_num={0}", --page_num));

        }
        protected void btn_GoClick(object sender, EventArgs e)
        {
            int page_num = Convert.ToInt16(this.GoToPage.Text);
            int num_pages = (int)Session["num_pages"];
            page_num = page_num < num_pages ? page_num : num_pages;
            Session["curPageNum"] = page_num;
            // int page_num = (int)Session["curPageNum"];
            Response.Redirect(string.Format("mainpage.aspx?page_num={0}", page_num));
        }

        protected void FileUpload_Button_Click(object sender, EventArgs e)
        {
            string uploadName = InputFile.Value;//获取待上传图片的完整路径，包括文件名
            //string uploadName = InputFile.PostedFile.FileName;
            string pictureName = "";//上传后的图片名，以当前时间为文件名，确保文件名没有重复
            if (InputFile.Value != "")
            {
                int idx = uploadName.LastIndexOf(".");
                string suffix = uploadName.Substring(idx);//获得上传的图片的后缀名
                pictureName = DateTime.Now.Ticks.ToString() + suffix;
                //pictureName+=suffix;
            }
            try
            {
                if (uploadName != "")
                {
                    string path = Server.MapPath("~/images/");
                    InputFile.PostedFile.SaveAs(path + pictureName);

                    string Abs_Path = path + pictureName;

                    //                 Session["AssessImage"]=path+pictureName;
                    Session["AssessImage"] = "images/" + pictureName;
                    //                    Random M_Rand=new Random();

                    //                    this.Image1.Controls.Clear();

                    //   this.Image1.ImageUrl = (string)Session["AssessImage"];

                    this.Image1.ImageUrl = "images/" + pictureName;


                    //   this.Image1.ImageUrl = (string)Session["AssessImage"];

                    //                    this.Image1.Controls.Add(Image1);
                }
            }                
            catch (Exception ex)
            {
                Response.Write(ex);
            }


            Session["Aesth_Quality"] = "";
            this.AesthQuality.Text = "";
        }

        protected void Assess_Click(object sender, EventArgs e)
        {
            string Img_Path = (string)Session["AssessImage"];
            List<int> Img_Sim = (List<int>)Session["img_Similarity"];

            Shuffle_List(Img_Sim);

            if (Img_Sim[0] % 2 == 0)
            {
                //    this.AesthQuality.Text = "beautiful";
                Session["Aesth_Quality"] = "Beautiful";
            }
            else
            {
                //   this.AesthQuality.Text = "ugly";
                Session["Aesth_Qualtiy"] = "Ugly";
            }

            string MT_Aesth = (string)Session["Aesth_Quality"];

            Session["img_Similarity"] = Img_Sim;
            Session["curPageNum"] = 0;


            Response.Redirect(string.Format("mainpage.aspx?page_num={0}", 0));
        }

        protected void Retrieval_Click(object sender, EventArgs e)
        {
            string Img_Path = (string)Session["AssessImage"];
            List<int> Img_Sim = (List<int>)Session["img_Similarity"];

            Shuffle_List(Img_Sim);

            Session["img_Similarity"] = Img_Sim;
            Session["curPageNum"] = 0;

//            Session["Aesth_Qualtiy"];
            Session["Aesth_Quality"] = "";

        //    string test_str = (string)Session["Aesth_Quality"];

            string MT_Aesth = (string)Session["Aesth_Quality"];

//            this.AesthQuality.Text = "";

            Response.Redirect(string.Format("mainpage.aspx?page_num={0}", 0));

        }

        protected void Shuffle_List(List<int> list)
        {
            int N = list.Count;
            Random M_Ran = new Random();

            for (int i = 0; i < 10000; i++)
            {
                int Loc_1 = M_Ran.Next(0, 19307);
                int Loc_2 = M_Ran.Next(0, 19307);

                int M_Swap = list[Loc_1];
                list[Loc_1] = list[Loc_2];
                list[Loc_2] = M_Swap;
            }

      //      int TTT=list.Count;

        }

    }
}