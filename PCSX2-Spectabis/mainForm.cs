using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Net;
using System.Drawing;

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

            //Initilization
            isoPanel.AutoScroll = true;
            UpdateUiEvent += new UpdateUiDelegate(addIso);

            if (Properties.Settings.Default.IsGameMode == false)
            { configMode.Checked = true; }
            else
            { gameMode.Checked = true; }

            //Integrity Checks
            if (emuDir == "null")
            {
                FirstTimeSetup();
            } 
            else
            {
                //Searches game folders in resources directory
                string[] gamesDir = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\");
                foreach (string dir in gamesDir)
                {

                    string _title = dir;
                    string _name = dir.Remove(0, dir.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1);

                    if (File.Exists(_title + @"\art.jpg"))
                    {
                        var gameIni = new IniFile(_title + @"\spectabis.ini");
                        var _isoDir = gameIni.Read("isoDirectory", "Spectabis");

                        PictureBox gameBox = new PictureBox();

                        gameBox.Height = 200;
                        gameBox.Width = 150;
                        gameBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        gameBox.ImageLocation = _title + @"\art.jpg";
                        isoPanel.Controls.Add(gameBox);
                        gameBox.MouseDown += gameBox_Click;
                        gameBox.Tag = _isoDir;
                        gameBox.Name = _name;
                    }

                }

            }
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
        private void FirstTimeSetup()
        {
            Color bgCol = ColorTranslator.FromHtml("#0277BD");

            //Welcome Screen Background
            PictureBox welcomeBg = new PictureBox();
            welcomeBg.Visible = true;
            //welcomeBg.BackColor = bgCol;
            welcomeBg.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"\resources\welcomescreen\bg1.png";
            welcomeBg.Height = this.ClientSize.Height;
            welcomeBg.Width = this.ClientSize.Width;
            Controls.Add(welcomeBg);
            welcomeBg.BringToFront();

            //Welcome Screen selectdir button
            MaterialFlatButton welcomedirbtn = new MaterialFlatButton();
            welcomedirbtn.Visible = true;
            welcomedirbtn.Height = 50;
            welcomedirbtn.Width = 140;
            welcomedirbtn.Anchor = AnchorStyles.None;
            welcomedirbtn.Text = "Browse";
            Controls.Add(welcomedirbtn);
            welcomedirbtn.BringToFront();
            welcomedirbtn.MouseDown += welcomedirbtn_click;

            //MessageBox.Show("PCSX2 directory not set, please navigate me to it.", "Warning");
            //SelectDir();
        }

        private void welcomedirbtn_click (object sender, EventArgs e)
        {
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


            //If boxart exists in folder, then set it in isoPanel
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title + @"\art.jpg"))
            {
                gameBox.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title + @"\art.jpg";
            }
            else
            {
                gameBox.ImageLocation = _img;
            }

            gameBox.Name = _title;

            //Add gamebox and controls
            isoPanel.Controls.Add(gameBox);
            gameBox.MouseDown += gameBox_Click;
            gameBox.Tag = _isoDir;

            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title);

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(_img, AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title + @"\art.jpg");
                }
                catch
                {
                    throw;
                }
            }

            var gameIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title + @"\spectabis.ini");
            gameIni.Write("isoDirectory", _isoDir, "Spectabis");
            gameIni.Write("nogui", "0", "Spectabis");
            gameIni.Write("fullscreen", "0", "Spectabis");
            gameIni.Write("fullboot", "0", "Spectabis");

            //MessageBox.Show("Please, configure the game");
            //string cfgDir = AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title;
            //Process.Start(emuDir + @"\pcsx2.exe", "--cfgpath \"" + cfgDir + "\"");
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

                        var gameIni = new IniFile(cfgDir + @"\spectabis.ini");
                        var _nogui = gameIni.Read("nogui", "Spectabis");
                        var _fullscreen = gameIni.Read("fullscreen", "Spectabis");
                        var _fullboot = gameIni.Read("fullboot", "Spectabis");

                        string _launchargs = "";

                        if (_nogui == "1")
                        {
                            _launchargs = "--nogui";
                        }

                        if (_fullscreen == "1")
                        {
                            _launchargs = _launchargs + "--fullscreen";
                        }

                        if (_fullboot == "1")
                        {
                            _launchargs = _launchargs + "--fullboot";
                        }


                        Process.Start(emuDir + @"\pcsx2.exe", "" + _launchargs + "\"" + isoDir + "\" --cfgpath \"" + cfgDir + "\"");
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
            Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + lastGame.Name, true);
            isoPanel.Controls.Remove(lastGame);
            lastGame = null;
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.lastGameEdit = lastGame.Name;
            Properties.Settings.Default.Save();

            //Opens game settings form
            gameSettings gameSettings = new gameSettings();
            gameSettings.RefToForm2 = this;

            //Hides this form
            this.Visible = false;

            //Shows game settings form
            gameSettings.Show();

        }
    }
}
