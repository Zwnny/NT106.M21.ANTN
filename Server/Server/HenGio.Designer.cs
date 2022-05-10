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
            this.Hour = new System.Windows.Forms.NumericUpDown();
            this.Minute = new System.Windows.Forms.NumericUpDown();
            this.Second = new System.Windows.Forms.NumericUpDown();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Second)).BeginInit();
            this.SuspendLayout();
            // 
            // Hour
            // 
            this.Hour.Location = new System.Drawing.Point(107, 152);
            this.Hour.Name = "Hour";
            this.Hour.Size = new System.Drawing.Size(120, 26);
            this.Hour.TabIndex = 0;
            // 
            // Minute
            // 
            this.Minute.Location = new System.Drawing.Point(335, 152);
            this.Minute.Name = "Minute";
            this.Minute.Size = new System.Drawing.Size(120, 26);
            this.Minute.TabIndex = 1;
            // 
            // Second
            // 
            this.Second.Location = new System.Drawing.Point(562, 152);
            this.Second.Name = "Second";
            this.Second.Size = new System.Drawing.Size(120, 26);
            this.Second.TabIndex = 2;
            // 
            // btnShutdown
            // 
            this.btnShutdown.Location = new System.Drawing.Point(221, 310);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(126, 49);
            this.btnShutdown.TabIndex = 3;
            this.btnShutdown.Text = "Shut down";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(458, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 49);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // HenGio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnShutdown);
            this.Controls.Add(this.Second);
            this.Controls.Add(this.Minute);
            this.Controls.Add(this.Hour);
            this.Name = "HenGio";
            this.Text = "HenGio";
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Second)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Hour;
        private System.Windows.Forms.NumericUpDown Minute;
        private System.Windows.Forms.NumericUpDown Second;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnCancel;
    }
}