using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace W_Maze_Gui
{

    public partial class W_Maze_Gui : Form
    {

        private int elapsed_time;
        private bool _exiting;
        private bool ratWasChosen = false;
        private readonly Form exitConfirm = new ExitConfirm();
        private List<string> ratName = new List<string>();
        private List<string> ratAge = new List<string>();
        private List<string> ratSession = new List<string>();
        private Dictionary<string, string> ageDic = new Dictionary<string, string>();
        private Dictionary<string, int> sessionDic = new Dictionary<string, int>();
        private SerialPort serialPort = new SerialPort();
        public BackgroundWorker felix = new BackgroundWorker();
        public int correctCnt;
        public int inboundCnt;
        public int outboundCnt;
        public int repeatCnt;
        public int initialCnt;

        public W_Maze_Gui()
        {
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM3";
            serialPort.Open();
            var csvReader = new StreamReader(File.OpenRead("RatData.csv"));
            var csvWriter = new StreamWriter(File.OpenWrite("RatData.csv"));
            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var vals = line.Split(',');
                ageDic.Add(vals[0], vals[1]);
                sessionDic.Add(vals[0], Int32.Parse(vals[2]));
                ratName.Add(vals[0]);
            }

            felix.DoWork += listen_to_arduino;
            felix.RunWorkerCompleted += run_worker_completed;

            felix.RunWorkerAsync();
            InitializeComponent();
            foreach (var rat in ratName) this.RatSelection.Items.Add(rat);

        }


        public void run_worker_completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null && e.Result != null)
            {

                var messageType = e.Result.ToString().Substring(0, 1);
                switch (messageType)
                {
                    case "c":
                        correctCnt++;
                        correctNum.Text = correctCnt.ToString();
                        break;
                    case "i":
                        inboundCnt++;
                        inboundNum.Text = inboundCnt.ToString();
                        break;
                    case "o":
                        outboundCnt++;
                        outboundNum.Text = outboundCnt.ToString();
                        break;
                    case "r":
                        repeatCnt++;
                        repeatNum.Text = repeatCnt.ToString();
                        break;
                    case "b":
                        initialCnt++;
                        initialNum.Text = initialCnt.ToString();
                        break;

                }
            }

            if (!felix.IsBusy)
                felix.RunWorkerAsync();

        }
        public void listen_to_arduino(object sender, DoWorkEventArgs e)
        {

            try
            {
                var changedData = serialPort.ReadTo("\n");

                //InstanceOfUpdateGuiThings.OnDataChanged(changedData);
                e.Result = changedData;
            }
            catch (Exception) { }

        }

        private void W_Maze_Gui_Load(object sender, EventArgs e)
        {
        }
        private void SelectButtonClick(object sender, EventArgs e)
        {
            selectButton.Hide();
            RatSelection.Hide();
            ratSelectionLabel.Text = $"{ratName[RatSelection.SelectedIndex]}";
            var chosenRat = ratName[RatSelection.SelectedIndex];
            ageLabel.Text = ageDic[chosenRat];
            sessionLabel.Text = sessionDic[chosenRat].ToString();
            CsvFiles.openSessionCsv(chosenRat);
            ratWasChosen = true;
            csvWriter.Write()
            //CsvFiles.openTimestampCsv(chosenRat);

        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            saveButton.ForeColor = Color.DarkGray;
            CsvFiles.sessionCsv.Write($"{this.sessionLabel.Text},{this.experimenterBox.Text},{DateTime.Now.ToString()},{this.display_time.Text}," +
            $"{this.correctNum.Text},{this.initialNum.Text},{this.outboundNum.Text},{this.inboundNum.Text},{this.repeatNum.Text},{this.totalErrNum.Text},{this.totalNum.Text}," +
            $"{this.notesBox.Text}\n");

            CsvFiles.close();
            startButton.Hide();
            stopButton.Hide();
            experimenterBox.Enabled = false;
            notesBox.Enabled = false;
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            if (ratWasChosen)
            {
                startButton.ForeColor = Color.AliceBlue;
                Recording_Time.Enabled = true;
                updateTime();
            }
            else;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}