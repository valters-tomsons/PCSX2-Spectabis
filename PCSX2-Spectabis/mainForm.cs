using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Net;
using System.Drawing;
using System.Collections.Generic;

namespace PCSX2_Spectabis
{
    public partial class MainWindow : MaterialForm
    {

        private static string emuDir;
        private static string addgamesDir;
        public static List<string> gamelist = new List<string>();
        

        //Delegate setup for addGameForm
        public delegate void UpdateUiDelegate(string _img, string _isoDir, string _title);
        public event UpdateUiDelegate UpdateUiEvent;

        public PictureBox lastGame;

        //First Time Setup
        public PictureBox welcomeBg = new PictureBox();
        public MaterialFlatButton welcomedirbtn = new MaterialFlatButton();




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
            addgamesDir = Properties.Settings.Default.gamesDir;

            //Initilization
            isoPanel.AutoScroll = true;
            UpdateUiEvent += new UpdateUiDelegate(addIso);

            //Integrity Checks
            if (emuDir == "null")
            {
                FirstTimeSetup(true);
            } 
            else
            {
                //Searches game folders in resources directory
                string[] gamesDir = Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\");
                foreach (string dir in gamesDir)
                {
                    //Removes symbols from game title
                    string _title = dir;
                    string _name = dir.Remove(0, dir.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1);
                    _name = _name.Trim(new Char[] { ' ', '*', '.', '\\', '/' });
                    //_name = _name.Remove(0, dir.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1);

                    if (File.Exists(_title + @"\art.jpg"))
                    {
                        var gameIni = new IniFile(_title + @"\spectabis.ini");
                        var _isoDir = gameIni.Read("isoDirectory", "Spectabis");

                        if(File.Exists(_isoDir))
                        {
                            gamelist.Add(_isoDir);

                            PictureBox gameBox = new PictureBox();

                            gameBox.Height = 200;
                            gameBox.Width = 150;
                            gameBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            gameBox.ImageLocation = _title + @"\art.jpg";
                            isoPanel.Controls.Add(gameBox);
                            gameBox.MouseDown += gameBox_Click;
                            gameBox.Tag = _isoDir;
                            gameBox.Name = _name;
                            Debug.WriteLine(_name + " has been added");
                        }  
                    }

                }

            }

            //Empty list cannot be foreached
            gamelist.Add("null");

            //Every startup look for new .iso files
            if(addgamesDir != "null")
            {
                scanDir();
            }

        }

        //scan directory for new isos function
        private static void scanDir()
        {
            foreach (string iso in Directory.GetFiles(addgamesDir + @"\"))
            {
                string _isoname = iso.Replace(addgamesDir + @"\", String.Empty);
                foreach (string existingiso in gamelist)
                {
                    if(iso != existingiso)
                    {
                        Debug.WriteLine( _isoname + " is not in game list");
                        if(_isoname.Contains(".iso"))
                        {
                            MessageBox.Show("Do you want to add " + _isoname + " ?");
                        }
                    }
                }                   
            }
        }


        //Save Settings function
        private static void saveSettings()
        {
            Properties.Settings.Default.EmuDir = emuDir;
            Properties.Settings.Default.gamesDir = addgamesDir;
            Properties.Settings.Default.Save();
        }


        //Opens emulator directory selection dialog
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
                else
                {
                    Application.Exit();
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
        public void FirstTimeSetup(bool _show)
        {

            if (_show == true)
            {
                //Color bgCol = ColorTranslator.FromHtml("#0277BD");
                //welcomeBg.BackColor = bgCol;

                //Welcome Screen Background
                welcomeBg.Visible = true;
                welcomeBg.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"\resources\welcomescreen\bg1.png";
                welcomeBg.Height = this.ClientSize.Height;
                welcomeBg.Width = this.ClientSize.Width;
                Controls.Add(welcomeBg);
                welcomeBg.BringToFront();

                //Welcome Screen selectdir button
                welcomedirbtn.Visible = true;
                welcomedirbtn.Height = 50;
                welcomedirbtn.Width = 140;
                welcomedirbtn.Anchor = AnchorStyles.None;
                welcomedirbtn.Text = "Browse";
                Controls.Add(welcomedirbtn);
                welcomedirbtn.BringToFront();
                welcomedirbtn.MouseDown += welcomedirbtn_click;

                //Centers the button
                welcomedirbtn.Location = new Point((this.ClientSize.Width / 2) - (welcomedirbtn.Width / 2), (this.ClientSize.Height / 2) + (welcomedirbtn.Height / 2));
            }
            else
            {
                welcomeBg.Visible = false;
                welcomedirbtn.Visible = false;
            }
        }


        private void welcomedirbtn_click (object sender, EventArgs e)
        {
            SelectDir();
            FirstTimeSetup(false);
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

            _title = _title.Replace(@"/", string.Empty);
            _title = _title.Replace(@"\", string.Empty);
            _title = _title.Replace(@":", string.Empty);

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
            
            //string _name = dir.Trim(new Char[] { ' ', '*', '.', '\\', '/' });

            //Add gamebox and controls
            isoPanel.Controls.Add(gameBox);
            gameBox.MouseDown += gameBox_Click;
            gameBox.Tag = _isoDir;


            Debug.WriteLine("creating a folder at - " + AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title);

            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title);

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFile(_img, AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + _title + @"\art.jpg");
                }
                catch
                {
                    //throw;
                    MessageBox.Show("Image not available, none set.");
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
            Debug.WriteLine(clickedPictureBox.Name + " - clicked");

            //Saves last picturebox to a variable
            lastGame = (PictureBox)sender;

            //Refresh the image
            clickedPictureBox.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"resources\configs\" + clickedPictureBox.Name + @"\art.jpg";

            //Check, if click was left mouse
            if (e.Button == MouseButtons.Left)
            {
                //Checks, if game file still exists
                if(File.Exists((string)clickedPictureBox.Tag))
                {
                    //Starts the game, if exists
                    string isoDir = (string)clickedPictureBox.Tag;
                    string cfgDir = AppDomain.CurrentDomain.BaseDirectory + @"resources\configs\" + clickedPictureBox.Name;

                    var gameIni = new IniFile(cfgDir + @"\spectabis.ini");
                    var _nogui = gameIni.Read("nogui", "Spectabis");
                    var _fullscreen = gameIni.Read("fullscreen", "Spectabis");
                    var _fullboot = gameIni.Read("fullboot", "Spectabis");

                    string _launchargs = "";

                    if (_nogui == "1")
                     {
                        _launchargs = "--nogui ";
                     }

                    if (_fullscreen == "1")
                     {
                        _launchargs = _launchargs + "--fullscreen ";
                     }

                    if (_fullboot == "1")
                     {
                        _launchargs = _launchargs + "--fullboot ";
                     }

                    Debug.WriteLine(clickedPictureBox.Name + " launched with commandlines:  " + _launchargs);
                    Debug.WriteLine(emuDir + @"\pcsx2.exe", "" + _launchargs + "\"" + isoDir + "\" --cfgpath \"" + cfgDir + "\"");

                    Process.Start(emuDir + @"\pcsx2.exe", "" + _launchargs + "\"" + isoDir + "\" --cfgpath \"" + cfgDir + "\"");
                    return;
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


        private void emulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cfgDir = AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + lastGame.Name;
            Process.Start(emuDir + @"\pcsx2.exe", "--cfgpath \"" + cfgDir + "\"");
        }


        private void AddDirectoryButton_Click(object sender, EventArgs e)
        {
            if(addgamesDir != "null")
            {
                MessageBox.Show("Proceeding will overwrite your current active game directory.");
            }

            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select where your game files are located." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    addgamesDir = fbd.SelectedPath;
                    scanDir();
                }
            }
        }


    }
}
