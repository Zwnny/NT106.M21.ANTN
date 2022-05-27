namespace Server
{
    partial class ControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.btnHenGio = new System.Windows.Forms.Button();
            this.btnLogger = new System.Windows.Forms.Button();
            this.ScreenCapture = new System.Windows.Forms.PictureBox();
            this.btnShareScreen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHenGio
            // 
            this.btnHenGio.BackColor = System.Drawing.Color.Black;
            this.btnHenGio.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHenGio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnHenGio.Location = new System.Drawing.Point(9, 284);
            this.btnHenGio.Name = "btnHenGio";
            this.btnHenGio.Size = new System.Drawing.Size(141, 132);
            this.btnHenGio.TabIndex = 0;
            this.btnHenGio.Text = "Hẹn giờ";
            this.btnHenGio.UseVisualStyleBackColor = false;
            this.btnHenGio.Click += new System.EventHandler(this.btnHenGio_Click);
            // 
            // btnLogger
            // 
            this.btnLogger.BackColor = System.Drawing.Color.Black;
            this.btnLogger.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLogger.Location = new System.Drawing.Point(9, 499);
            this.btnLogger.Name = "btnLogger";
            this.btnLogger.Size = new System.Drawing.Size(141, 132);
            this.btnLogger.TabIndex = 1;
            this.btnLogger.Text = "Keylogger";
            this.btnLogger.UseVisualStyleBackColor = false;
            this.btnLogger.Click += new System.EventHandler(this.btnLogger_Click);
            // 
            // ScreenCapture
            // 
            this.ScreenCapture.BackColor = System.Drawing.Color.Transparent;
            this.ScreenCapture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ScreenCapture.Location = new System.Drawing.Point(156, 25);
            this.ScreenCapture.Name = "ScreenCapture";
            this.ScreenCapture.Size = new System.Drawing.Size(1333, 644);
            this.ScreenCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScreenCapture.TabIndex = 3;
            this.ScreenCapture.TabStop = false;
            // 
            // btnShareScreen
            // 
            this.btnShareScreen.BackColor = System.Drawing.Color.Black;
            this.btnShareScreen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnShareScreen.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShareScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnShareScreen.Location = new System.Drawing.Point(9, 74);
            this.btnShareScreen.Name = "btnShareScreen";
            this.btnShareScreen.Size = new System.Drawing.Size(141, 132);
            this.btnShareScreen.TabIndex = 4;
            this.btnShareScreen.Text = "Share screen";
            this.btnShareScreen.UseVisualStyleBackColor = false;
            this.btnShareScreen.Click += new System.EventHandler(this.btnShareScreen_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1501, 681);
            this.Controls.Add(this.btnShareScreen);
            this.Controls.Add(this.ScreenCapture);
            this.Controls.Add(this.btnLogger);
            this.Controls.Add(this.btnHenGio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.ControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenCapture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHenGio;
        private System.Windows.Forms.Button btnLogger;
        private System.Windows.Forms.PictureBox ScreenCapture;
        private System.Windows.Forms.Button btnShareScreen;
    }
}

