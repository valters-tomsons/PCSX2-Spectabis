namespace PCSX2_Spectabis
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.isoPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SettingsButton = new System.Windows.Forms.PictureBox();
            this.addGameButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.gameMode = new MaterialSkin.Controls.MaterialRadioButton();
            this.configMode = new MaterialSkin.Controls.MaterialRadioButton();
            this.contextMenu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // isoPanel
            // 
            this.isoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.isoPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.isoPanel.Location = new System.Drawing.Point(12, 114);
            this.isoPanel.Name = "isoPanel";
            this.isoPanel.Size = new System.Drawing.Size(952, 501);
            this.isoPanel.TabIndex = 0;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.BackColor = System.Drawing.Color.Transparent;
            this.SettingsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SettingsButton.BackgroundImage")));
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SettingsButton.Location = new System.Drawing.Point(939, 32);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(25, 25);
            this.SettingsButton.TabIndex = 1;
            this.SettingsButton.TabStop = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // addGameButton
            // 
            this.addGameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addGameButton.Depth = 0;
            this.addGameButton.Location = new System.Drawing.Point(836, 65);
            this.addGameButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addGameButton.Name = "addGameButton";
            this.addGameButton.Primary = true;
            this.addGameButton.Size = new System.Drawing.Size(140, 43);
            this.addGameButton.TabIndex = 2;
            this.addGameButton.Text = "Add Game";
            this.addGameButton.UseVisualStyleBackColor = true;
            this.addGameButton.Click += new System.EventHandler(this.addGameButton_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // gameMode
            // 
            this.gameMode.AutoSize = true;
            this.gameMode.Depth = 0;
            this.gameMode.Font = new System.Drawing.Font("Roboto", 10F);
            this.gameMode.Location = new System.Drawing.Point(12, 71);
            this.gameMode.Margin = new System.Windows.Forms.Padding(0);
            this.gameMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.gameMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.gameMode.Name = "gameMode";
            this.gameMode.Ripple = true;
            this.gameMode.Size = new System.Drawing.Size(103, 30);
            this.gameMode.TabIndex = 3;
            this.gameMode.Text = "Game Mode";
            this.gameMode.UseVisualStyleBackColor = true;
            // 
            // configMode
            // 
            this.configMode.AutoSize = true;
            this.configMode.Depth = 0;
            this.configMode.Font = new System.Drawing.Font("Roboto", 10F);
            this.configMode.Location = new System.Drawing.Point(156, 71);
            this.configMode.Margin = new System.Windows.Forms.Padding(0);
            this.configMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.configMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.configMode.Name = "configMode";
            this.configMode.Ripple = true;
            this.configMode.Size = new System.Drawing.Size(151, 30);
            this.configMode.TabIndex = 4;
            this.configMode.Text = "Configuration Mode";
            this.configMode.UseVisualStyleBackColor = true;
            // 
            // contextMenu
            // 
            this.contextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.contextMenu.Depth = 0;
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.contextMenu.Name = "materialContextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(128, 48);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.configureToolStripMenuItem.Text = "Configure";
            this.configureToolStripMenuItem.Click += new System.EventHandler(this.configureToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 627);
            this.Controls.Add(this.configMode);
            this.Controls.Add(this.gameMode);
            this.Controls.Add(this.addGameButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.isoPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spectabis";
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox SettingsButton;
        private MaterialSkin.Controls.MaterialRaisedButton addGameButton;
        private System.Windows.Forms.Timer mainTimer;
        public System.Windows.Forms.FlowLayoutPanel isoPanel;
        private MaterialSkin.Controls.MaterialRadioButton gameMode;
        private MaterialSkin.Controls.MaterialRadioButton configMode;
        private MaterialSkin.Controls.MaterialContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
    }
}

