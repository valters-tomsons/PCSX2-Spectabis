using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCSX2_Spectabis
{
    public partial class gameSettings : MaterialForm
    {

        public string currentGame = Properties.Settings.Default.lastGameEdit;
        OpenFileDialog browseImg = new OpenFileDialog();

        //Form Reference
        public Form RefToForm2 { get; set; }

        public gameSettings()
        {
            InitializeComponent();

            boxArt.SizeMode = PictureBoxSizeMode.StretchImage;

            Text = "Editing - " + currentGame;
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\art.jpg"))
            {
                boxArt.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\art.jpg";
            }

            string cfgDir = AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame;

            var gameIni = new IniFile(cfgDir + @"\spectabis.ini");
            var _nogui = gameIni.Read("nogui", "Spectabis");
            var _fullscreen = gameIni.Read("fullscreen", "Spectabis");
            var _fullboot = gameIni.Read("fullboot", "Spectabis");
            var _nohacks = gameIni.Read("nohacks", "Spectabis");

            if (_nogui == "1")
            {
                nogui.Checked = true;
            }

            if (_fullscreen == "1")
            {
                fullscreen.Checked = true;
            }

            if (_fullboot == "1")
            {
                fullboot.Checked = true;
            }
            if (_nohacks == "1")
            {
                nohacks.Checked = true;
            }
        }

        //On form closing
        protected override void OnClosing(CancelEventArgs e)
        {

            var gameIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\spectabis.ini");

            if (nogui.Checked == true)
            {
                gameIni.Write("nogui", "1", "Spectabis");
            }
            else
            {
                gameIni.Write("nogui", "0", "Spectabis");
            }

            if (fullscreen.Checked == true)
            {
                gameIni.Write("fullscreen", "1", "Spectabis");
            }
            else
            {
                gameIni.Write("fullscreen", "0", "Spectabis");
            }

            if(fullboot.Checked == true)
            {
                gameIni.Write("fullboot", "1", "Spectabis");
            }
            else
            {
                gameIni.Write("fullboot", "0", "Spectabis");
            }

            if(nohacks.Checked == true)
            {
                gameIni.Write("nohacks", "1", "Spectabis");
            }
            else
            {
                gameIni.Write("nohacks", "0", "Spectabis");
            }
            
            

            //Show mainForm
            this.RefToForm2.Show();
        }

        private void chgimg_Click(object sender, EventArgs e)
        {
            browseImg.Filter = "JPEG image (.jpg)|*.jpg|PNG image (.png)|*.png";

            if (browseImg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\art.jpg"))
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\art.jpg");
                }

                boxArt.ImageLocation = browseImg.FileName;

                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.DownloadFile(browseImg.FileName, AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\art.jpg");
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

        }

        //Calls the LilyPad.dll file in pcsx2/plugins
        //It has no inputs, but writes/reads the ini files where .exe is located at folder /inis/
        [DllImport(@"D:\PCSX2\plugins\LilyPad.dll")]
        static public extern IntPtr PADconfigure();

        private void controller_btn_Click(object sender, EventArgs e)
        {
            //Copy the existing .ini file for editing if it exists
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\LilyPad.ini"))
            {
                //Creates inis folder and copies it from game profile folder
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"inis");
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\LilyPad.ini", AppDomain.CurrentDomain.BaseDirectory + @"inis\LilyPad.ini", true);
            }

            //Calls the DLL function
            IntPtr pClassName = PADconfigure();

            //Copies the modified file into the game profile & deletes the created folder
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"inis\LilyPad.ini", AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\LilyPad.ini", true);
            Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + @"inis", true);
        }

    }
}
