namespace W_Maze_Gui
{
    public partial class exitConfirm
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
            this.confirmExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.exitWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmExit
            // 
            this.confirmExit.BackColor = System.Drawing.Color.DarkGreen;
            this.confirmExit.ForeColor = System.Drawing.Color.LightGreen;
            this.confirmExit.Location = new System.Drawing.Point(12, 61);
            this.confirmExit.Name = "confirmExit";
            this.confirmExit.Size = new System.Drawing.Size(50, 50);
            this.confirmExit.TabIndex = 0;
            this.confirmExit.Text = "Yes";
            this.confirmExit.UseVisualStyleBackColor = false;
            this.confirmExit.Click += new System.EventHandler(this.ConfirmButtonClick);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(193, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "No";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.RejectButtonClick);
            // 
            // label1
            // 
            this.exitWarning.AutoSize = true;
            this.exitWarning.Location = new System.Drawing.Point(54, 32);
            this.exitWarning.Name = "label1";
            this.exitWarning.Size = new System.Drawing.Size(149, 13);
            this.exitWarning.TabIndex = 2;
            this.exitWarning.Text = "Are you sure you want to exit?";
            // 
            // exitConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 189);
            this.Controls.Add(this.exitWarning);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.confirmExit);
            this.Name = "exitConfirm";
            this.Text = "exitConfirm";
            this.Load += new System.EventHandler(this.exitConfirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button confirmExit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label exitWarning;
    }
}