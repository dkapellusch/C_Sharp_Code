namespace W_Maze_Gui
{
    partial class W_Maze_Gui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(W_Maze_Gui));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.RatSelection = new System.Windows.Forms.ComboBox();
            this.Recording_Time = new System.Windows.Forms.Timer(this.components);
            this.display_time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.feederVisitTitle = new System.Windows.Forms.Label();
            this.Correct = new System.Windows.Forms.Label();
            this.Incorrect = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.correctNum = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.incorrectNum = new System.Windows.Forms.Label();
            this.totalNum = new System.Windows.Forms.Label();
            this.experimenterLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.AutoSize = true;
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(172)))), ((int)(((byte)(57)))));
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.startButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(0)))));
            this.startButton.Location = new System.Drawing.Point(272, 178);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(92, 44);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // stopButton
            // 
            this.stopButton.AutoSize = true;
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopButton.Location = new System.Drawing.Point(391, 178);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(92, 45);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // RatSelection
            // 
            this.RatSelection.AllowDrop = true;
            this.RatSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.RatSelection.DisplayMember = "RatSelection";
            this.RatSelection.DropDownHeight = 100;
            this.RatSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RatSelection.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.RatSelection.FormattingEnabled = true;
            this.RatSelection.IntegralHeight = false;
            this.RatSelection.Location = new System.Drawing.Point(602, 67);
            this.RatSelection.Name = "RatSelection";
            this.RatSelection.Size = new System.Drawing.Size(101, 21);
            this.RatSelection.Sorted = true;
            this.RatSelection.TabIndex = 3;
            this.RatSelection.SelectedIndexChanged += new System.EventHandler(this.SelectionChangeCommitted);
            this.RatSelection.Click += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Recording_Time
            // 
            this.Recording_Time.Interval = 1000;
            this.Recording_Time.Tick += new System.EventHandler(this.increment_time);
            // 
            // display_time
            // 
            this.display_time.AutoSize = true;
            this.display_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.display_time.ForeColor = System.Drawing.Color.RoyalBlue;
            this.display_time.Location = new System.Drawing.Point(282, 67);
            this.display_time.MinimumSize = new System.Drawing.Size(200, 100);
            this.display_time.Name = "display_time";
            this.display_time.Size = new System.Drawing.Size(200, 100);
            this.display_time.TabIndex = 5;
            this.display_time.Text = "00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(598, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rat Number";
            // 
            // feederVisitTitle
            // 
            this.feederVisitTitle.AutoSize = true;
            this.feederVisitTitle.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feederVisitTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.feederVisitTitle.Location = new System.Drawing.Point(15, 19);
            this.feederVisitTitle.Name = "feederVisitTitle";
            this.feederVisitTitle.Size = new System.Drawing.Size(153, 22);
            this.feederVisitTitle.TabIndex = 8;
            this.feederVisitTitle.Text = "Feeder Visits";
            // 
            // Correct
            // 
            this.Correct.AutoSize = true;
            this.Correct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Correct.ForeColor = System.Drawing.SystemColors.Control;
            this.Correct.Location = new System.Drawing.Point(3, 10);
            this.Correct.Name = "Correct";
            this.Correct.Size = new System.Drawing.Size(58, 17);
            this.Correct.TabIndex = 9;
            this.Correct.Text = "Correct:";
            this.Correct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Correct.Click += new System.EventHandler(this.label3_Click);
            // 
            // Incorrect
            // 
            this.Incorrect.AutoSize = true;
            this.Incorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Incorrect.ForeColor = System.Drawing.SystemColors.Control;
            this.Incorrect.Location = new System.Drawing.Point(3, 10);
            this.Incorrect.Name = "Incorrect";
            this.Incorrect.Size = new System.Drawing.Size(67, 17);
            this.Incorrect.TabIndex = 10;
            this.Incorrect.Text = "Incorrect:";
            this.Incorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.ForeColor = System.Drawing.SystemColors.Control;
            this.Total.Location = new System.Drawing.Point(3, 12);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(50, 17);
            this.Total.TabIndex = 11;
            this.Total.Text = "Total:";
            this.Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Age:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Session No.:";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ageLabel.ForeColor = System.Drawing.Color.Cyan;
            this.ageLabel.Location = new System.Drawing.Point(47, 18);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(0, 18);
            this.ageLabel.TabIndex = 16;
            // 
            // sessionLabel
            // 
            this.sessionLabel.AutoSize = true;
            this.sessionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionLabel.ForeColor = System.Drawing.Color.Cyan;
            this.sessionLabel.Location = new System.Drawing.Point(112, 72);
            this.sessionLabel.Name = "sessionLabel";
            this.sessionLabel.Size = new System.Drawing.Size(0, 18);
            this.sessionLabel.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.sessionLabel);
            this.panel1.Location = new System.Drawing.Point(583, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 112);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ageLabel);
            this.panel2.Location = new System.Drawing.Point(583, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 58);
            this.panel2.TabIndex = 19;
            // 
            // correctNum
            // 
            this.correctNum.AutoSize = true;
            this.correctNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctNum.ForeColor = System.Drawing.Color.Cyan;
            this.correctNum.Location = new System.Drawing.Point(120, 9);
            this.correctNum.Name = "correctNum";
            this.correctNum.Size = new System.Drawing.Size(16, 18);
            this.correctNum.TabIndex = 20;
            this.correctNum.Text = "0";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.Black;
            this.saveButton.Location = new System.Drawing.Point(601, 444);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(115, 44);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.feederVisitTitle);
            this.panel3.Location = new System.Drawing.Point(12, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 63);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.Correct);
            this.panel4.Controls.Add(this.correctNum);
            this.panel4.Location = new System.Drawing.Point(12, 130);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(187, 38);
            this.panel4.TabIndex = 23;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(187, 38);
            this.panel5.TabIndex = 24;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.incorrectNum);
            this.panel6.Controls.Add(this.Incorrect);
            this.panel6.Location = new System.Drawing.Point(12, 168);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(187, 38);
            this.panel6.TabIndex = 24;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.totalNum);
            this.panel7.Controls.Add(this.Total);
            this.panel7.Location = new System.Drawing.Point(12, 206);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(187, 41);
            this.panel7.TabIndex = 25;
            // 
            // incorrectNum
            // 
            this.incorrectNum.AutoSize = true;
            this.incorrectNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrectNum.ForeColor = System.Drawing.Color.Cyan;
            this.incorrectNum.Location = new System.Drawing.Point(120, 9);
            this.incorrectNum.Name = "incorrectNum";
            this.incorrectNum.Size = new System.Drawing.Size(16, 18);
            this.incorrectNum.TabIndex = 11;
            this.incorrectNum.Text = "0";
            // 
            // totalNum
            // 
            this.totalNum.AutoSize = true;
            this.totalNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNum.ForeColor = System.Drawing.Color.Cyan;
            this.totalNum.Location = new System.Drawing.Point(119, 11);
            this.totalNum.Name = "totalNum";
            this.totalNum.Size = new System.Drawing.Size(17, 18);
            this.totalNum.TabIndex = 26;
            this.totalNum.Text = "0";
            // 
            // experimenterLabel
            // 
            this.experimenterLabel.AutoSize = true;
            this.experimenterLabel.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.experimenterLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.experimenterLabel.Location = new System.Drawing.Point(17, 320);
            this.experimenterLabel.Name = "experimenterLabel";
            this.experimenterLabel.Size = new System.Drawing.Size(125, 17);
            this.experimenterLabel.TabIndex = 26;
            this.experimenterLabel.Text = "Experimenter:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(137, 318);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 22);
            this.textBox1.TabIndex = 27;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(20, 382);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(254, 125);
            this.textBox2.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(21, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Notes";
            // 
            // W_Maze_Gui
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(758, 528);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.experimenterLabel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.display_time);
            this.Controls.Add(this.RatSelection);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "W_Maze_Gui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "W-Maze";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.W_Maze_Gui_FormClosing);
            this.Load += new System.EventHandler(this.W_Maze_Gui_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ComboBox RatSelection;
        private System.Windows.Forms.Timer Recording_Time;
        private System.Windows.Forms.Label display_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label feederVisitTitle;
        private System.Windows.Forms.Label Correct;
        private System.Windows.Forms.Label Incorrect;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label correctNum;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label incorrectNum;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label totalNum;
        private System.Windows.Forms.Label experimenterLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}

