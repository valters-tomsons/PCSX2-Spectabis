using System;
using System.ComponentModel;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;

namespace PCSX2_Spectabis
{
    public partial class settingsForm : MaterialForm
    {

        //Form Reference
        public Form RefToForm1 { get; set; }

        public string emuDir = Properties.Settings.Default.EmuDir;

        public settingsForm()
        {
            InitializeComponent();
            emuDir = Properties.Settings.Default.EmuDir;

            if(Properties.Settings.Default.nightMode == true)
            {
                materialCheckBox1.Checked = true;
            }

        }

        //On form closing
        protected override void OnClosing(CancelEventArgs e)
        {
            //Saves Settings
            Properties.Settings.Default.EmuDir = emuDir;
            Properties.Settings.Default.Save();

            //Show mainForm
            this.RefToForm1.Show();
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            emulatordir.Text = emuDir;
        }

        //Change Directory Button
        private void dirButton_Click(object sender, EventArgs e)
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
                        emulatordir.Text = Properties.Settings.Default.EmuDir;
                    }
                    else
                    {
                        MessageBox.Show("Not a valid emulator directory");
                        goto SelectDir; //retries FolderBrowserDialog
                    }
                }
            }
        }

        //Night Mode Checkbox
        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(materialCheckBox1.Checked == true)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                Properties.Settings.Default.nightMode = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                Properties.Settings.Default.nightMode = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}
