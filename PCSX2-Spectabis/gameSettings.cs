using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCSX2_Spectabis
{
    public partial class gameSettings : MaterialForm
    {

        //Form Reference
        public Form RefToForm2 { get; set; }

        public gameSettings()
        {
            string currentGame = Properties.Settings.Default.lastGameEdit;
            ActiveForm.Text = "Editing - " + currentGame;
            boxArt.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"\resources\configs\" + currentGame + @"\art.jpg";

            InitializeComponent();
        }

        //On form closing
        protected override void OnClosing(CancelEventArgs e)
        {
            //Show mainForm
            this.RefToForm2.Show();
        }






    }
}
