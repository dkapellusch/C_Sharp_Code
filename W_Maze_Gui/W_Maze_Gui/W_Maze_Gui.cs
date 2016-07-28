using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace W_Maze_Gui
{
    public partial class W_Maze_Gui : Form
    {
        public Form exitConfirm = new Form();
        private bool _exiting = false;
        public W_Maze_Gui()
        {

            InitializeComponent();

            //Setting start and stop button fonts
            this.startButton.Font = new Font(startButton.Font, FontStyle.Bold);
            this.startButton.ForeColor = Color.FromArgb(0, 71, 0);

            this.stopButton.Font = new Font(stopButton.Font, FontStyle.Bold);
            this.stopButton.ForeColor = Color.FromArgb(50, 0, 0);

            this.comboBox1.Items.Add("Rat 2012");
        }

        private void W_Maze_Gui_Load(object sender, EventArgs e)
        {

        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            this.startButton.ForeColor = Color.AliceBlue;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            _exiting = true;
            Application.Exit();
        }

        private void RejectButtonClick(object sender, EventArgs e)
        {
            exitConfirm.Close();
        }
        private void W_Maze_Gui_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_exiting)
            {
                exitConfirm.Size = new Size(100, 150);
                exitConfirm.StartPosition = FormStartPosition.CenterParent;

                Button confirmButton = new Button();
                Button rejectButton = new Button();
                TextBox confirmClose = new TextBox();

                exitConfirm.Controls.Add(confirmButton);
                exitConfirm.Controls.Add(rejectButton);
                exitConfirm.Controls.Add(confirmClose);

                confirmButton.Size = new Size(50, 50);
                rejectButton.Size = new Size(50, 50);
                confirmClose.Size = new Size(150, 100);
                confirmButton.Location = new Point(5, 50);
                rejectButton.Location = new Point(55, 50);

                confirmButton.Text = "Yes";
                rejectButton.Text = "No";
                confirmClose.Text = "Close Without Saving?";

                confirmButton.Click += new EventHandler(ConfirmButtonClick);
                rejectButton.Click += new EventHandler(RejectButtonClick);

                exitConfirm.ShowDialog();
                e.Cancel = true;
            }

        }
    }
}
