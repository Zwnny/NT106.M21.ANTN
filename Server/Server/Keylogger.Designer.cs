namespace Server
{
    partial class Keylogger
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_XuatFile = new System.Windows.Forms.Button();
            this.btn_KeyLogging = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(-4, 323);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1177, 428);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btn_XuatFile
            // 
            this.btn_XuatFile.Location = new System.Drawing.Point(440, 197);
            this.btn_XuatFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_XuatFile.Name = "btn_XuatFile";
            this.btn_XuatFile.Size = new System.Drawing.Size(244, 43);
            this.btn_XuatFile.TabIndex = 1;
            this.btn_XuatFile.Text = "Xuất File";
            this.btn_XuatFile.UseVisualStyleBackColor = true;
            this.btn_XuatFile.Click += new System.EventHandler(this.btn_XuatFile_Click);
            // 
            // btn_KeyLogging
            // 
            this.btn_KeyLogging.Location = new System.Drawing.Point(440, 135);
            this.btn_KeyLogging.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_KeyLogging.Name = "btn_KeyLogging";
            this.btn_KeyLogging.Size = new System.Drawing.Size(244, 43);
            this.btn_KeyLogging.TabIndex = 2;
            this.btn_KeyLogging.Text = "Start";
            this.btn_KeyLogging.UseVisualStyleBackColor = true;
            this.btn_KeyLogging.Click += new System.EventHandler(this.btn_KeyLogging_Click);
            // 
            // Keylogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 766);
            this.Controls.Add(this.btn_KeyLogging);
            this.Controls.Add(this.btn_XuatFile);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Keylogger";
            this.Text = "Keylogger";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_XuatFile;
        private System.Windows.Forms.Button btn_KeyLogging;
    }
}