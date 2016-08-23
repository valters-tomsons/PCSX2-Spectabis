namespace PCSX2_Spectabis
{
    partial class gameSettings
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
            this.boxArt = new System.Windows.Forms.PictureBox();
            this.fullscreen = new MaterialSkin.Controls.MaterialCheckBox();
            this.nogui = new MaterialSkin.Controls.MaterialCheckBox();
            this.fullboot = new MaterialSkin.Controls.MaterialCheckBox();
            this.chgimg = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.boxArt)).BeginInit();
            this.SuspendLayout();
            // 
            // boxArt
            // 
            this.boxArt.Location = new System.Drawing.Point(12, 78);
            this.boxArt.Name = "boxArt";
            this.boxArt.Size = new System.Drawing.Size(150, 200);
            this.boxArt.TabIndex = 0;
            this.boxArt.TabStop = false;
            // 
            // fullscreen
            // 
            this.fullscreen.AutoSize = true;
            this.fullscreen.Depth = 0;
            this.fullscreen.Font = new System.Drawing.Font("Roboto", 10F);
            this.fullscreen.Location = new System.Drawing.Point(175, 78);
            this.fullscreen.Margin = new System.Windows.Forms.Padding(0);
            this.fullscreen.MouseLocation = new System.Drawing.Point(-1, -1);
            this.fullscreen.MouseState = MaterialSkin.MouseState.HOVER;
            this.fullscreen.Name = "fullscreen";
            this.fullscreen.Ripple = true;
            this.fullscreen.Size = new System.Drawing.Size(94, 30);
            this.fullscreen.TabIndex = 1;
            this.fullscreen.Text = "Fullscreen";
            this.fullscreen.UseVisualStyleBackColor = true;
            // 
            // nogui
            // 
            this.nogui.AutoSize = true;
            this.nogui.Depth = 0;
            this.nogui.Font = new System.Drawing.Font("Roboto", 10F);
            this.nogui.Location = new System.Drawing.Point(175, 108);
            this.nogui.Margin = new System.Windows.Forms.Padding(0);
            this.nogui.MouseLocation = new System.Drawing.Point(-1, -1);
            this.nogui.MouseState = MaterialSkin.MouseState.HOVER;
            this.nogui.Name = "nogui";
            this.nogui.Ripple = true;
            this.nogui.Size = new System.Drawing.Size(168, 30);
            this.nogui.TabIndex = 2;
            this.nogui.Text = "No Graphical Interface";
            this.nogui.UseVisualStyleBackColor = true;
            // 
            // fullboot
            // 
            this.fullboot.AutoSize = true;
            this.fullboot.Depth = 0;
            this.fullboot.Font = new System.Drawing.Font("Roboto", 10F);
            this.fullboot.Location = new System.Drawing.Point(175, 138);
            this.fullboot.Margin = new System.Windows.Forms.Padding(0);
            this.fullboot.MouseLocation = new System.Drawing.Point(-1, -1);
            this.fullboot.MouseState = MaterialSkin.MouseState.HOVER;
            this.fullboot.Name = "fullboot";
            this.fullboot.Ripple = true;
            this.fullboot.Size = new System.Drawing.Size(84, 30);
            this.fullboot.TabIndex = 3;
            this.fullboot.Text = "Full Boot";
            this.fullboot.UseVisualStyleBackColor = true;
            // 
            // chgimg
            // 
            this.chgimg.Depth = 0;
            this.chgimg.Location = new System.Drawing.Point(12, 284);
            this.chgimg.MouseState = MaterialSkin.MouseState.HOVER;
            this.chgimg.Name = "chgimg";
            this.chgimg.Primary = true;
            this.chgimg.Size = new System.Drawing.Size(150, 32);
            this.chgimg.TabIndex = 4;
            this.chgimg.Text = "Change";
            this.chgimg.UseVisualStyleBackColor = true;
            this.chgimg.Click += new System.EventHandler(this.chgimg_Click);
            // 
            // gameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.chgimg);
            this.Controls.Add(this.fullboot);
            this.Controls.Add(this.nogui);
            this.Controls.Add(this.fullscreen);
            this.Controls.Add(this.boxArt);
            this.Name = "gameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "null";
            ((System.ComponentModel.ISupportInitialize)(this.boxArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox boxArt;
        private MaterialSkin.Controls.MaterialCheckBox fullscreen;
        private MaterialSkin.Controls.MaterialCheckBox nogui;
        private MaterialSkin.Controls.MaterialCheckBox fullboot;
        private MaterialSkin.Controls.MaterialRaisedButton chgimg;
    }
}