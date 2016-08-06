using System;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using TheGamesDBAPI;
using System.Net;

namespace PCSX2_Spectabis
{
    public partial class addGameForm : MaterialForm
    {

        public Delegate ControlCreator;

        public string ImgPath;
        public string realTitle;

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
                //Searches DB for inputed game name, only on playstation 2
                foreach (GameSearchResult game in GamesDB.GetGames(gameName.Text, "Sony Playstation 2"))
                {
                    //Gets game's database ID
                    Game newGame = GamesDB.GetGame(game.ID);
                    //Trim title
                    realTitle = game.Title.Replace(":", "");
                    //Sets image
                    ImgPath = "http://thegamesdb.net/banners/" + newGame.Images.BoxartFront.Path;
                    //Stops at the first game
                    break;
                }
            }
            else
            {
                //Sets image to set path
                ImgPath = gameName.Text;
                realTitle = titleName.Text;
            }

            //Adds game to mainform list
            ControlCreator.DynamicInvoke(ImgPath, isoPath, realTitle);

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

        private void customArt_CheckedChanged(object sender, EventArgs e)
        {
            if (autoArt.Checked == true)
            {
                artLabel.Text = "Game Name";
                titleLabel.Visible = false;
                titleName.Visible = false;
            }
            else
            {
                artLabel.Text = "Path to image";
                titleLabel.Visible = true;
                titleName.Visible = true;

            }
        }
    }
}
