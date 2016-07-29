namespace PCSX2_Spectabis
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.emulatordir = new MaterialSkin.Controls.MaterialLabel();
            this.dirButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 97);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(123, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Current Directory";
            // 
            // emulatordir
            // 
            this.emulatordir.AutoSize = true;
            this.emulatordir.Depth = 0;
            this.emulatordir.Font = new System.Drawing.Font("Roboto", 11F);
            this.emulatordir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.emulatordir.Location = new System.Drawing.Point(13, 122);
            this.emulatordir.MouseState = MaterialSkin.MouseState.HOVER;
            this.emulatordir.Name = "emulatordir";
            this.emulatordir.Size = new System.Drawing.Size(140, 19);
            this.emulatordir.TabIndex = 2;
            this.emulatordir.Text = "c:/emulators/pcsx2";
            // 
            // dirButton
            // 
            this.dirButton.Depth = 0;
            this.dirButton.Location = new System.Drawing.Point(243, 97);
            this.dirButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.dirButton.Name = "dirButton";
            this.dirButton.Primary = true;
            this.dirButton.Size = new System.Drawing.Size(100, 50);
            this.dirButton.TabIndex = 3;
            this.dirButton.Text = "Change";
            this.dirButton.UseVisualStyleBackColor = true;
            this.dirButton.Click += new System.EventHandler(this.dirButton_Click);
            // 
            // materialCheckBox1
            // 
            this.materialCheckBox1.AutoSize = true;
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialCheckBox1.Location = new System.Drawing.Point(9, 566);
            this.materialCheckBox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.Size = new System.Drawing.Size(102, 30);
            this.materialCheckBox1.TabIndex = 4;
            this.materialCheckBox1.Text = "Night Mode";
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            this.materialCheckBox1.CheckedChanged += new System.EventHandler(this.materialCheckBox1_CheckedChanged);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 605);
            this.Controls.Add(this.materialCheckBox1);
            this.Controls.Add(this.dirButton);
            this.Controls.Add(this.emulatordir);
            this.Controls.Add(this.materialLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settingsForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel emulatordir;
        private MaterialSkin.Controls.MaterialRaisedButton dirButton;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox1;
    }
}