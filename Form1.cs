using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;

namespace OMR_scanner
{
    public partial class Form1 : Form
    {
        public double ratio = 0;
        public   double finalpoint;
        public int[] ans2 = new int[400];
        public int[] omr_answer = new int[400];
        public int[] ans = new int[400];
        public int num = 40;
        public int num3 = 1;
        public int b = 0;
        public int p = 0;
        public Point startpos1 = new Point(1323, 483);
        public Point Startpos2 = new Point(1663, 483);
        public int plusvalX = 40, plusvalY = 75;
        public string filetmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowFileOpenDialog();
        }


        /// <summary>
        /// 그림파일오픈창을 로드후 해당 파일의 FullPath를 가져온다.
        /// </summary>
        /// <returns>파일의 FullPath 파일이 없거나 선택을 안할경우 ""를 리턴</returns>
        public string ShowFileOpenDialog()
        {
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "OMR 스캔된 파일 가져오기...(read OMR here)";
            ofd.Filter = "그림 파일 (*.jpg, *.gif, *.bmp) | *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                //File명과 확장자를 가지고 온다.
                string fileName = ofd.SafeFileName;
                //File경로와 File명을 모두 가지고 온다.
                string fileFullName = ofd.FileName;
                //File경로만 가지고 온다.
                mPictureBox.Image = Image.FromFile(fileFullName);
                string filePath = fileFullName.Replace(fileName, "");
                timer3.Enabled = false;
               
                y = 488;
                a = 0;
                num3 = 0;
                n1 = 0;
                b = 0;
                ans2 = new int[400];
                answerbox.Text = "";
                timer1.Enabled = true;
              
                return fileFullName;
            }
            //취소버튼 클릭시 또는 ESC키로 파일창을 종료 했을경우
            else if (dr == DialogResult.Cancel)
            {
                return "";
            }

            return "";
        }
     
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void compareanswer()
        {
         
;
            string[] str2 = answer.Text.Split(new string[] { "," }, StringSplitOptions.None);
            string[] str3 = point_.Text.Split(new string[] { "," }, StringSplitOptions.None);
   
            if (checkBox1.Checked)
            {
                int right = 0;
      
                for (int i = 0; i < str2.Length; i++)
                {
                    double.TryParse(ans2[i].ToString(), out double aa);
                    double.TryParse(str2[i], out double k);
                    if (aa.Equals(k))
                    {
                        right++;
                    }
                }
                if (str2.Length.Equals(right))
                {
                    finalpoint = 100;
                }
                else
                {
                    finalpoint = (100 / str2.Length) *right;
                }
               
            }
            else
            {
                if (str2.Length.Equals(str3.Length))
                {
                    for (int i = 0; i < str2.Length; i++)
                    {
                        double.TryParse(ans2[i].ToString(), out double aa);
                        double.TryParse(str2[i], out double k);
                        double.TryParse(str3[i], out double l);
                        if (aa.Equals(k))
                        {
                            finalpoint += l;
                        }
                   

                    }
                }
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        int n1 = 0;
        public int read_(ref Color col,int x)
        {

            if (col.GetBrightness()<=0.3)
            {
                if (x >= 1300  && x <= 1330 )
                {
                    n1 = 1;
                }
                else if (x >= 1350  && x <= 1370 )
                {
                    n1 = 2;
                }
                else if (x >= 1400  && x <= 1420 )
                {
                    n1 = 3;
                }
                else if(x >= 1440  && x <= 1450 )
                {
                    n1 = 4;
                }
                else if(x >= 1470  && x <= 1510 )
                {
                    n1 = 5;

                }
                else if(x < 1300  || x > 1510 )
                {
                    n1 = 0;
                }
                else
                {
                    
                }
                
                return n1;

            }
            else
            {
                if (n1 > 0)
                {
                    return n1;
                }
                else
                {
                    return 0;
                }
                
            }

        }
        int y = 488;
        int a = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Bitmap tmp = PictureBoxReset();
                plusvalY = 75;
                int width = tmp.Width;

                int height = tmp.Height;
                int x = 1331;
                int n = 0;
                Color colorData = new Color();


                if (num3 <= 20)

                {

                    bool ischecked = false;
                    for (x = 1300; x <= 1510; x++)

                    {
                        colorData = tmp.GetPixel(x, y);
                        n = read_(ref colorData, x);
                        if (n > 0)
                        {
                            ischecked = true;
                        }

                    }
                    if (ischecked)
                    {

                        n1 = 0;
                        y += plusvalY;
                        num3++;
                        answerbox.Text += num3 + ":" + n + "\r\n";
                        ans2[a] = n;
                        a++;
                    }
                    if (num3.Equals(20))
                    {
                        y = 488;
                        x = 1600;
                        for (x = 1600; x <= 1860; x++)

                        {
                            colorData = tmp.GetPixel(x, y);
                            n = read__(ref colorData, x);
                            if (n > 0)
                            {
                                ischecked = true;
                            }

                        }
                        if (ischecked)
                        {

                            n1 = 0;
                            y += plusvalY;
                            num3++;
                            answerbox.Text += num3 + ":" + n + "\r\n";
                            ans2[a] = n;
                            a++;
                        }

                    }

                }
                else if (num3 > 40)
                {

                    timer1.Enabled = false;

                }
                else
                {
                    bool ischecked = false;
                    for (x = 1600; x <= 1860; x++)

                    {
                        colorData = tmp.GetPixel(x, y);
                        n = read__(ref colorData, x);
                        if (n > 0)
                        {
                            ischecked = true;
                        }

                    }
                    if (ischecked)
                    {

                        n1 = 0;
                        y += plusvalY;
                        num3++;
                        answerbox.Text += num3 + ":" + n + "\r\n";
                        ans2[a] = n;
                        a++;
                    }

                }
            }
            catch (Exception ee)
            {
                log_.Text = "예외가 발생하였습니다.(Exception occured.)\r\n" + ee.Message + "\r\n" + ee.StackTrace;
            }
        }

       

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            finalpoint = 0;
            compareanswer();
            result.Text =finalpoint.ToString();
        }

        private Bitmap PictureBoxReset()

        {







            Bitmap tmp = mPictureBox.Image as Bitmap;

            //픽셀정보를 알아오기 위하여 비트맵을 얻어온다.         

            return tmp;

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Bitmap tmp = PictureBoxReset();
            plusvalY = 70;
            int width = tmp.Width;

            int height = tmp.Height;
            int x = 1331;
            int n = 0;
            Color colorData = new Color();


            if (num3 <= 20)

            {

                bool ischecked = false;
                for (x = 1290; x <= 1510; x++)

                {
                    colorData = tmp.GetPixel(x, y);
                    n = read_(ref colorData, x);
                    if (n > 0)
                    {
                        ischecked = true;
                    }

                }
                if (ischecked)
                {

                    n1 = 0;
                    y+=plusvalY;
                    num3++;
                    answerbox.Text += num3 + ":" + n + "\r\n";
                    ans2[a] = n;
                    a++;
                }
                if (num3.Equals(20))
                {
                    y = 523;
                    x = 1600;
                    for (x = 1600; x <= 1860; x++)

                    {
                        colorData = tmp.GetPixel(x, y);
                        n = read__(ref colorData, x);
                        if (n > 0)
                        {
                            ischecked = true;
                        }

                    }
                    if (ischecked)
                    {

                        n1 = 0;
                        y+=plusvalY;
                        num3++;
                        answerbox.Text += num3 + ":" + n + "\r\n";
                        ans2[a] = n;
                        a++;
                    }

                }

            }
            else if (num3 > 40)
            {

                timer3.Enabled = false;
                

            }
            else
            {
                bool ischecked = false;
                for (x = 1600; x <= 1860; x++)

                {
                    colorData = tmp.GetPixel(x, y);
                    n = read__(ref colorData, x);
                    if (n > 0)
                    {
                        ischecked = true;
                    }

                }
                if (ischecked)
                {

                    n1 = 0;
                    y+=plusvalY;
                    num3++;
                    answerbox.Text += num3 + ":" + n + "\r\n";
                    ans2[a] = n;
                    a++;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                timer3.Enabled = false;
                plusvalY = 70;
                y = 523;
                a = 0;
                num3 = 0;
                n1 = 0;
                b = 0;
                ans2 = new int[400];
                answerbox.Text = "";
                log_.Text = "스캔 시작(Scanning started)";
                string sDirPath = Application.StartupPath + "\\images";
                FileInfo file = new FileInfo(sDirPath + "\\scanned.jpg");



                if (!file.Exists)
                {

                }
                else
                {
                    FileStream fs_ = file.OpenRead();
                    fs_.Dispose();
                    file.IsReadOnly = false;
                    file.Delete();
                 
                }
               
              
                FileInfo file_ = new FileInfo(sDirPath + "\\scanned_1.jpg");

                if (!file_.Exists)
                {

                }
                else
                {
                    FileStream fs__ = file_.OpenRead();
                    fs__.Dispose();
                    file_.IsReadOnly = false;
                    file_.Delete();

                }
                timer3.Enabled = false;
                mPictureBox.Image = null;
               
                WIA.CommonDialog dialog = new WIA.CommonDialog();
              Device scanner = dialog.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
                if (!scanner.DeviceID.Equals(null))
                {
                    Item scannnerItem = scanner.Items[1];
                    // TODO: Adjust scanner settings.

                    ImageFile scannedImage = (ImageFile)dialog.ShowTransfer(scannnerItem, WIA.FormatID.wiaFormatJPEG, false);
                   
                   
                    DirectoryInfo di = new DirectoryInfo(sDirPath);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }
                    scannedImage.SaveFile(sDirPath + "\\scanned.jpg");

                    using (Image image = Image.FromFile(sDirPath + "\\scanned.jpg"))
                    {
                        using (Image newImage = new Bitmap(image, 2475, 3505))
                        {
                            newImage.RotateFlip(RotateFlipType.Rotate90FlipNone);


                            newImage.Save(sDirPath + "\\scanned_1.jpg");
                          
                            mPictureBox.Image = new Bitmap(newImage);
                            newImage.Dispose();
                            image.Dispose();
                        }
                    }
   

                    timer3.Enabled = true;
                   
                }

            }catch(Exception ee)
            {
                log_.Text = "예외가 발생하였습니다.(Exception occured.)\r\n" + ee.Message +"\r\n"+ ee.StackTrace;
            }


        }

     
        public int read__(ref Color col, int x)
        {

            if (col.GetBrightness() <= 0.4)
            {
                if (x >= 1650  && x <= 1670 )
                {
                    n1 = 1;
                }
                else if (x >= 1690  && x <= 1710 )
                {
                    n1 = 2;
                }
                else if (x >= 1730  && x <= 1750 )
                {
                    n1 = 3;
                }
                else if (x >= 1770  && x <= 1790 )
                {
                    n1 = 4;
                }
                else if (x >= 1810  && x <= 1830 )
                {
                    n1 = 5;

                }
                else if (x < 1630  || x > 1870 )
                {
                    n1 = 0;
                }
                else
                {

                }

                return n1;

            }
            else
            {
                if (n1 > 0)
                {
                    return n1;
                }
                else
                {
                    return 0;
                }

            }

        }
        /* unused(사용되지 않는 구문)
        public int read0(ref Color col,int y)
        {
            if (col.GetBrightness() <= 0.2)
            {
            if(y>910 && y < 920)
                {
                    n1 = 0;
                }
            else if(y>950 && y < 960)
                {
                    n1 = 1;
                }
                else if (y > 1040 && y < 1050)
                {
                    n1 = 2;
                }
                else if (y > 1090 && y < 1100)
                {
                    n1 = 3;
                }
                else if (y > 1130 && y < 1140)
                {
                    n1 = 5;
                }
                else if (y > 1180 && y < 1190)
                {
                    n1 = 6;
                }
                else if (y > 1220 && y < 1230)
                {
                    n1 = 7;
                }
                else if (y > 1260 && y < 1270)
                {
                    n1 = 8;
                }
                else if (y > 1310 && y < 1320)
                {
                    n1 = 9;
                }
                return n1;

            }
            else
            {
                if (n1 > 0)
                {
                    return n1;
                }
                else
                {
                    return 0;
                }

            }
        }
        */

    }

}

