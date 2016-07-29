using System;
using System.Drawing;
using System.Windows.Forms;

namespace W_Maze_Gui
{
    public partial class W_Maze_Gui : Form
    {
        private bool _exiting;
        private readonly Form exitConfirm = new ExitConfirm();


        public W_Maze_Gui()
        {
            InitializeComponent();
        }

        private void W_Maze_Gui_Load(object sender, EventArgs e)
        {
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            startButton.ForeColor = Color.AliceBlue;
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
        }
    }
}