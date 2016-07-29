using System;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;
using PCSX2_Spectabis.Properties;

namespace PCSX2_Spectabis
{
    public partial class MainWindow : MaterialForm
    {

        private static string emuDir;

        //Delegate setup for addGameForm
        public delegate void UpdateUiDelegate(string _img, string _isoDir);
        public event UpdateUiDelegate UpdateUiEvent;


        public MainWindow()
        {
            InitializeComponent();

            //Initialize The Colorscheme
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            //Loads saved settings
            emuDir = Properties.Settings.Default.EmuDir;

            //Integrity Checks
            if (emuDir == "null") { FirstTimeSetup(); } //First Time Setup

            //Initilization
            isoPanel.AutoScroll = true;
            UpdateUiEvent += new UpdateUiDelegate(addIso);

        }

        //Save Settings function
        private static void saveSettings()
        {
            Properties.Settings.Default.EmuDir = emuDir;
            Properties.Settings.Default.Save();
        }

        //Opens directory selection dialog
        public static void SelectDir()
        {
        SelectDir:
            //Opens Folder Browser Dialog
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Navigate to where PCSX2.exe is located." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    emuDir = fbd.SelectedPath;
                    if (File.Exists(emuDir + "/pcsx2.exe"))
                    {
                        Properties.Settings.Default.EmuDir = emuDir;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("Not a valid emulator directory");
                        goto SelectDir; //retries FolderBrowserDialog
                    }
                }
            }
        }

        //Main Timer
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            emuDir = Properties.Settings.Default.EmuDir;
            saveSettings();
        }

        //First Time Setup, should be called only once
        private static void FirstTimeSetup()
        {
            MessageBox.Show("PCSX2 directory not set, please navigate me to it.", "Warning");
            SelectDir();
        }


        //Settings (gears) button
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            //Opens settings form
            settingsForm obj2 = new settingsForm();
            obj2.RefToForm1 = this;

            //Hides this form
            this.Visible = false;

            //Shows settings form
            obj2.Show();
        }

        //Add Game Button
        private void addGameButton_Click(object sender, EventArgs e)
        {
            addGameForm addgame = new addGameForm();
            addgame.ControlCreator = UpdateUiEvent;
            addgame.Show();
        }

        //Add Iso function
        public void addIso(string _img, string _isoDir)
        {
            PictureBox gameBox = new PictureBox();
            gameBox.ImageLocation = _img;
            gameBox.Height = 200;
            gameBox.Width = 150;
            gameBox.SizeMode = PictureBoxSizeMode.StretchImage;
            string selfPath = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            isoPanel.Controls.Add(gameBox);
            gameBox.MouseDown += gameBox_Click;
            gameBox.Tag = _isoDir;
        }

        //Clicking on game
        private void gameBox_Click(object sender, MouseEventArgs e)
        {
            //Check, if click was left mouse
            if (e.Button == MouseButtons.Left)
            {
                PictureBox clickedPictureBox = (PictureBox)sender;

                //Checks, if game file still exists
                if(File.Exists((string)clickedPictureBox.Tag))
                {
                    //Starts the game, if exists
                    string isoDir = (string)clickedPictureBox.Tag;
                    //MessageBox.Show(emuDir + @"\pcsx2.exe """ + isoDir + @""" ");
                    //Process.Start(emuDir + @"\pcsx2.exe """ + isoDir + @""" ");
                    Process.Start(@"D:/PCSX2/pcsx2.exe ""D:/PCSX2/iso/godhand.iso"" ");
                }
                else
                {
                    MessageBox.Show("Huh, the game doesn't exist", ":(");
                }
            }
        }

    }
}
