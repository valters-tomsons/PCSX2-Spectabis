namespace PCSX2_Spectabis
{
    partial class addGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addGameForm));
            this.addGameButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.gameName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.gamePath = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ImagePath = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // addGameButton
            // 
            this.addGameButton.AutoSize = true;
            this.addGameButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addGameButton.Depth = 0;
            this.addGameButton.Location = new System.Drawing.Point(306, 236);
            this.addGameButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addGameButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addGameButton.Name = "addGameButton";
            this.addGameButton.Primary = false;
            this.addGameButton.Size = new System.Drawing.Size(81, 36);
            this.addGameButton.TabIndex = 1;
            this.addGameButton.Text = "Add Game";
            this.addGameButton.UseVisualStyleBackColor = true;
            this.addGameButton.Click += new System.EventHandler(this.addGameButton_Click);
            // 
            // gameName
            // 
            this.gameName.Depth = 0;
            this.gameName.Hint = "";
            this.gameName.Location = new System.Drawing.Point(11, 100);
            this.gameName.MouseState = MaterialSkin.MouseState.HOVER;
            this.gameName.Name = "gameName";
            this.gameName.PasswordChar = '\0';
            this.gameName.SelectedText = "";
            this.gameName.SelectionLength = 0;
            this.gameName.SelectionStart = 0;
            this.gameName.Size = new System.Drawing.Size(376, 23);
            this.gameName.TabIndex = 2;
            this.gameName.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 79);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(92, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Game Name";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 141);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(123, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Path to game file";
            // 
            // gamePath
            // 
            this.gamePath.Depth = 0;
            this.gamePath.Hint = "";
            this.gamePath.Location = new System.Drawing.Point(16, 166);
            this.gamePath.MouseState = MaterialSkin.MouseState.HOVER;
            this.gamePath.Name = "gamePath";
            this.gamePath.PasswordChar = '\0';
            this.gamePath.SelectedText = "";
            this.gamePath.SelectionLength = 0;
            this.gamePath.SelectionStart = 0;
            this.gamePath.Size = new System.Drawing.Size(273, 23);
            this.gamePath.TabIndex = 5;
            this.gamePath.UseSystemPasswordChar = false;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(300, 166);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(87, 23);
            this.materialRaisedButton1.TabIndex = 6;
            this.materialRaisedButton1.Text = "Browse";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // ImagePath
            // 
            this.ImagePath.Depth = 0;
            this.ImagePath.Hint = "";
            this.ImagePath.Location = new System.Drawing.Point(11, 236);
            this.ImagePath.MouseState = MaterialSkin.MouseState.HOVER;
            this.ImagePath.Name = "ImagePath";
            this.ImagePath.PasswordChar = '\0';
            this.ImagePath.SelectedText = "";
            this.ImagePath.SelectionLength = 0;
            this.ImagePath.SelectionStart = 0;
            this.ImagePath.Size = new System.Drawing.Size(257, 23);
            this.ImagePath.TabIndex = 7;
            this.ImagePath.UseSystemPasswordChar = false;
            // 
            // addGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 287);
            this.Controls.Add(this.ImagePath);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.gamePath);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.gameName);
            this.Controls.Add(this.addGameButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton addGameButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField gameName;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField gamePath;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialSingleLineTextField ImagePath;
    }
}