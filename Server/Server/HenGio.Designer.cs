namespace Server
{
    partial class HenGio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HenGio));
            this.Hour = new System.Windows.Forms.NumericUpDown();
            this.Minute = new System.Windows.Forms.NumericUpDown();
            this.Second = new System.Windows.Forms.NumericUpDown();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Second)).BeginInit();
            this.SuspendLayout();
            // 
            // Hour
            // 
            this.Hour.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hour.Location = new System.Drawing.Point(88, 117);
            this.Hour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Hour.Name = "Hour";
            this.Hour.Size = new System.Drawing.Size(107, 34);
            this.Hour.TabIndex = 0;
            // 
            // Minute
            // 
            this.Minute.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minute.Location = new System.Drawing.Point(316, 117);
            this.Minute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Minute.Name = "Minute";
            this.Minute.Size = new System.Drawing.Size(107, 34);
            this.Minute.TabIndex = 1;
            // 
            // Second
            // 
            this.Second.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Second.Location = new System.Drawing.Point(534, 117);
            this.Second.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Second.Name = "Second";
            this.Second.Size = new System.Drawing.Size(107, 34);
            this.Second.TabIndex = 2;
            // 
            // btnShutdown
            // 
            this.btnShutdown.BackColor = System.Drawing.Color.RosyBrown;
            this.btnShutdown.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShutdown.ForeColor = System.Drawing.Color.White;
            this.btnShutdown.Location = new System.Drawing.Point(12, 220);
            this.btnShutdown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(187, 51);
            this.btnShutdown.TabIndex = 3;
            this.btnShutdown.Text = "Shut down";
            this.btnShutdown.UseVisualStyleBackColor = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.RosyBrown;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(522, 220);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(183, 51);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Giờ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(311, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Phút";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(529, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giây";
            // 
            // HenGio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(717, 282);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnShutdown);
            this.Controls.Add(this.Second);
            this.Controls.Add(this.Minute);
            this.Controls.Add(this.Hour);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HenGio";
            this.Text = "HenGio";
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Second)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Hour;
        private System.Windows.Forms.NumericUpDown Minute;
        private System.Windows.Forms.NumericUpDown Second;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}