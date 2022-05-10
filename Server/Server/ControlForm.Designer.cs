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
            this.btnHenGio = new System.Windows.Forms.Button();
            this.btnLogger = new System.Windows.Forms.Button();
            this.btnDkChuot = new System.Windows.Forms.Button();
            this.ScreenCapture = new System.Windows.Forms.PictureBox();
            this.btnShareScreen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHenGio
            // 
            this.btnHenGio.Location = new System.Drawing.Point(14, 229);
            this.btnHenGio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHenGio.Name = "btnHenGio";
            this.btnHenGio.Size = new System.Drawing.Size(136, 165);
            this.btnHenGio.TabIndex = 0;
            this.btnHenGio.Text = "Hẹn giờ";
            this.btnHenGio.UseVisualStyleBackColor = true;
            this.btnHenGio.Click += new System.EventHandler(this.btnHenGio_Click);
            // 
            // btnLogger
            // 
            this.btnLogger.Location = new System.Drawing.Point(14, 432);
            this.btnLogger.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogger.Name = "btnLogger";
            this.btnLogger.Size = new System.Drawing.Size(136, 165);
            this.btnLogger.TabIndex = 1;
            this.btnLogger.Text = "Keylogger";
            this.btnLogger.UseVisualStyleBackColor = true;
            this.btnLogger.Click += new System.EventHandler(this.btnLogger_Click);
            // 
            // btnDkChuot
            // 
            this.btnDkChuot.Location = new System.Drawing.Point(14, 644);
            this.btnDkChuot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDkChuot.Name = "btnDkChuot";
            this.btnDkChuot.Size = new System.Drawing.Size(136, 165);
            this.btnDkChuot.TabIndex = 2;
            this.btnDkChuot.Text = "Điều khiển chuột";
            this.btnDkChuot.UseVisualStyleBackColor = true;
            // 
            // ScreenCapture
            // 
            this.ScreenCapture.Location = new System.Drawing.Point(184, 31);
            this.ScreenCapture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ScreenCapture.Name = "ScreenCapture";
            this.ScreenCapture.Size = new System.Drawing.Size(1506, 674);
            this.ScreenCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScreenCapture.TabIndex = 3;
            this.ScreenCapture.TabStop = false;
            // 
            // btnShareScreen
            // 
            this.btnShareScreen.Location = new System.Drawing.Point(14, 31);
            this.btnShareScreen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShareScreen.Name = "btnShareScreen";
            this.btnShareScreen.Size = new System.Drawing.Size(136, 155);
            this.btnShareScreen.TabIndex = 4;
            this.btnShareScreen.Text = "Share screen";
            this.btnShareScreen.UseVisualStyleBackColor = true;
            this.btnShareScreen.Click += new System.EventHandler(this.btnShareScreen_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1713, 817);
            this.Controls.Add(this.btnShareScreen);
            this.Controls.Add(this.ScreenCapture);
            this.Controls.Add(this.btnDkChuot);
            this.Controls.Add(this.btnLogger);
            this.Controls.Add(this.btnHenGio);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.Button btnDkChuot;
        private System.Windows.Forms.PictureBox ScreenCapture;
        private System.Windows.Forms.Button btnShareScreen;
    }
}

