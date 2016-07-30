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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.ratInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.ratInfo.SuspendLayout();
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
            this.RatSelection.Size = new System.Drawing.Size(101, 24);
            this.RatSelection.Sorted = true;
            this.RatSelection.TabIndex = 3;
            this.RatSelection.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.display_time.Size = new System.Drawing.Size(237, 100);
            this.display_time.TabIndex = 5;
            this.display_time.Text = "00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(598, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rat Number";
            // 
            // feederVisitTitle
            // 
            this.feederVisitTitle.AutoSize = true;
            this.feederVisitTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feederVisitTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.feederVisitTitle.Location = new System.Drawing.Point(31, 88);
            this.feederVisitTitle.Name = "feederVisitTitle";
            this.feederVisitTitle.Size = new System.Drawing.Size(166, 23);
            this.feederVisitTitle.TabIndex = 8;
            this.feederVisitTitle.Text = "Feeder Visits";
            // 
            // Correct
            // 
            this.Correct.AutoSize = true;
            this.Correct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Correct.ForeColor = System.Drawing.SystemColors.Control;
            this.Correct.Location = new System.Drawing.Point(5, 55);
            this.Correct.Name = "Correct";
            this.Correct.Size = new System.Drawing.Size(70, 20);
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
            this.Incorrect.Location = new System.Drawing.Point(5, 108);
            this.Incorrect.Name = "Incorrect";
            this.Incorrect.Size = new System.Drawing.Size(80, 20);
            this.Incorrect.TabIndex = 10;
            this.Incorrect.Text = "Incorrect:";
            this.Incorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total.ForeColor = System.Drawing.SystemColors.Control;
            this.Total.Location = new System.Drawing.Point(5, 160);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(57, 20);
            this.Total.TabIndex = 11;
            this.Total.Text = "Total:";
            this.Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Total, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Correct, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Incorrect, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 210);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(5, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Age:";
            // 
            // ratInfo
            // 
            this.ratInfo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.ratInfo.ColumnCount = 1;
            this.ratInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ratInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ratInfo.Controls.Add(this.label3, 0, 1);
            this.ratInfo.Controls.Add(this.label2, 0, 0);
            this.ratInfo.Location = new System.Drawing.Point(585, 123);
            this.ratInfo.Name = "ratInfo";
            this.ratInfo.RowCount = 2;
            this.ratInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ratInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ratInfo.Size = new System.Drawing.Size(131, 100);
            this.ratInfo.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(5, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Session No.:";
            // 
            // W_Maze_Gui
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(758, 528);
            this.Controls.Add(this.feederVisitTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.display_time);
            this.Controls.Add(this.RatSelection);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ratInfo);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "W_Maze_Gui";
            this.Text = "W-Maze";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.W_Maze_Gui_FormClosing);
            this.Load += new System.EventHandler(this.W_Maze_Gui_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ratInfo.ResumeLayout(false);
            this.ratInfo.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel ratInfo;
        private System.Windows.Forms.Label label3;
    }
}

