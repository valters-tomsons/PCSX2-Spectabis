using System;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using TheGamesDBAPI;

namespace PCSX2_Spectabis
{
    public partial class addGameForm : MaterialForm
    {

        public Delegate ControlCreator;

        public string ImgPath;

        public addGameForm()
        {
            InitializeComponent();
        }

        //Add Game Button
        private void addGameButton_Click(object sender, EventArgs e)
        {
            //Invokes addGame method in mainForm
            string isoPath = gamePath.Text;
            //string gameTitle = gameName.Text;
            //string ImgPath = ImagePath.Text;

            if(autoArt.Checked == true)
            {
                foreach (GameSearchResult game in GamesDB.GetGames(gameName.Text))
                {
                    Game newGame = GamesDB.GetGame(game.ID);
                    ImgPath = "http://thegamesdb.net/banners/" + newGame.Images.BoxartFront.Path;
                    break;
                }
            }
            else
            {
                ImgPath = gameName.Text;
            }

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

        private void gameName_Click(object sender, EventArgs e)
        {

        }

        private void customArt_CheckedChanged(object sender, EventArgs e)
        {
            if (autoArt.Checked == true)
            {
                artLabel.Text = "Game Name";
            }
            else
            {
                artLabel.Text = "Path to image";
            }
        }
    }
}
