using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PCSX2_Spectabis
{
    public partial class MainWindow : MaterialForm
    {

        private static string emuDir;

        //Delegate setup for addGameForm
        public delegate void UpdateUiDelegate(string _img, string _isoDir, string _title);
        public event UpdateUiDelegate UpdateUiEvent;
        public PictureBox lastGame;


        public MainWindow()
        {
            InitializeComponent();

            //Initialize The Colorscheme
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            //Loads colorscheme
            if (Properties.Settings.Default.nightMode == true)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }

            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            //Loads saved settings
            emuDir = Properties.Settings.Default.EmuDir;

            //Integrity Checks
            if (emuDir == "null") { FirstTimeSetup(); } //First Time Setup

            //Initilization
            isoPanel.AutoScroll = true;
            UpdateUiEvent += new UpdateUiDelegate(addIso);

            if (Properties.Settings.Default.IsGameMode == false)
            { configMode.Checked = true; }
            else
            { gameMode.Checked = true; }

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
            //Saves game emulation settings
            if(gameMode.Checked == true)
            {
                Properties.Settings.Default.IsGameMode = true;
            }
            else
            {
                Properties.Settings.Default.IsGameMode = false;
            }

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
            //Creates a delegate addGameForm
            addGameForm addgame = new addGameForm();
            addgame.ControlCreator = UpdateUiEvent;
            addgame.Show();
            
        }

        //Add Iso function
        public void addIso(string _img, string _isoDir, string _title)
        {
            //Item properties
            PictureBox gameBox = new PictureBox();

            gameBox.Height = 200;
            gameBox.Width = 150;
            gameBox.SizeMode = PictureBoxSizeMode.StretchImage;

            //Path to iso from mainForm
            string selfPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

            gameBox.ImageLocation = _img;
            gameBox.Name = _title;
            //gameBox.ErrorImage = _img;

            //Add gamebox and controls
            isoPanel.Controls.Add(gameBox);
            gameBox.MouseDown += gameBox_Click;
            gameBox.Tag = _isoDir;

            MessageBox.Show("Please, configure the game");
            string cfgDir = AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title;
            Process.Start(emuDir + @"\pcsx2.exe", "--cfgpath \"" + cfgDir + "\"");
        }

        //Clicking on game
        private void gameBox_Click(object sender, MouseEventArgs e)
        {

            PictureBox clickedPictureBox = (PictureBox)sender;

            //Saves last picturebox to a variable
            lastGame = (PictureBox)sender;

            //Check, if click was left mouse
            if (e.Button == MouseButtons.Left)
            {
                //Checks, if game file still exists
                if(File.Exists((string)clickedPictureBox.Tag))
                {
                    //Starts the game, if exists
                    string isoDir = (string)clickedPictureBox.Tag;
                    if (gameMode.Checked == true)
                    {
                        string cfgDir = AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + clickedPictureBox.Name;
                        Process.Start(emuDir + @"\pcsx2.exe", "--fullscreen --nogui \"" + isoDir + "\" --cfgpath \"" + cfgDir + "\"");
                        return;
                    }
                    else
                    {
                        string cfgDir = AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + clickedPictureBox.Name;
                        Process.Start(emuDir + @"\pcsx2.exe", "--cfgpath \"" + cfgDir + "\"");
                    }
                }
                else
                {
                    MessageBox.Show("Huh, the game doesn't exist", ":(");
                }
            }

            //Check, if click was right mouse
            if (e.Button == MouseButtons.Right)
            {
                //Displays context menu
                contextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Deletes last picturebox in isoPanel
            isoPanel.Controls.Remove(lastGame);
            lastGame = null;
        }
    }
}
