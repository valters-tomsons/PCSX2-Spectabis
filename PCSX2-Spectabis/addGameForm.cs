using System;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace PCSX2_Spectabis
{
    public partial class addGameForm : MaterialForm
    {

        public Delegate ControlCreator;

        public addGameForm()
        {
            InitializeComponent();
        }

        //Add Game Button
        private void addGameButton_Click(object sender, EventArgs e)
        {
            //Invokes addGame method in mainForm
            string ImgPath = ImagePath.Text;
            string isoPath = gamePath.Text;
            ControlCreator.DynamicInvoke(ImgPath, isoPath);
            this.Close();
        }

        //Creates file dialog instance
        OpenFileDialog browseIso = new OpenFileDialog();

        //Browse ISO Button
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {

            //File Filter
            browseIso.Filter = "ISO image (.iso)|*.iso|Media Descriptor File (.mdf)|*.mdf|Image File (.img)|*.img";

            if (browseIso.ShowDialog() == DialogResult.OK)
            {
                //Sets path into textbox
                gamePath.Text = browseIso.FileName;
            }
        }
    }
}
