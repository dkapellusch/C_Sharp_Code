using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace W_Maze_Gui
{
    public partial class W_Maze_Gui : Form
    {
        private int elapsed_time;

        private bool _exiting;
        private readonly Form exitConfirm = new ExitConfirm();


        public W_Maze_Gui()
        {
            var csvReader = new StreamReader(File.OpenRead("RatData.csv"));
            var ratName = new List<string>();
            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var vals = line.Split(',');
                ratName.Add(vals[0]);
            }
            ratName.RemoveAt(0);
            InitializeComponent();
            foreach (var rat in ratName) this.RatSelection.Items.Add(rat);
        }

        private void W_Maze_Gui_Load(object sender, EventArgs e)
        {
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            startButton.ForeColor = Color.AliceBlue;
            Recording_Time.Enabled = true;
            updateTime();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void W_Maze_Gui_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_exiting)
            {
                _exiting = true;
                exitConfirm.StartPosition = FormStartPosition.CenterParent;
                exitConfirm.ShowDialog();
                e.Cancel = true;
                _exiting = false;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.ForeColor = Color.FromArgb(0, 40, 0);
            Recording_Time.Enabled = false;
        }

        private void updateTime()
        {
            var mins_ones = (elapsed_time / 60) % 10;
            var mins_tens = (elapsed_time / 60) / 10;
            var secs_ones = (elapsed_time % 60) % 10;
            var secs_tens = (elapsed_time % 60) / 10;
            display_time.Text = $"{mins_tens}{mins_ones}:{secs_tens}{secs_ones}";
        }

        private void increment_time(object sender, EventArgs e)
        {
            elapsed_time += 1;
            updateTime();

        }
    }
}