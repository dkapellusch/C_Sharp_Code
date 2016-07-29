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
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;
namespace W_Maze_Gui
{
    public static class FormConsole
    {
        [DllImport("kernel32.dll",
                 EntryPoint = "GetStdHandle",
                 SetLastError = true,
                 CharSet = CharSet.Auto,
                 CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;
        public static void configureConsole()
        {
            AllocConsole();
            IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
            SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
            StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
            standardOutput.AutoFlush = true;
        }
    }
    public partial class W_Maze_Gui : Form
    {
        private Form exitConfirm = new exitConfirm();
        private bool _exiting = false;


        public W_Maze_Gui()
        {
            FormConsole.configureConsole();
            
            Console.WriteLine("Please write");

            InitializeComponent();
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
