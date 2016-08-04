using System;
using System.Drawing;
//using System.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
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
        private Dictionary<string, string> name_to_age = new Dictionary<string, string>();
        private Dictionary<string, int> name_to_session = new Dictionary<string, int>();
        private SerialPort serialPort = new SerialPort();
        public BackgroundWorker felix = new BackgroundWorker();
        public int correctCnt;
        public int inboundCnt;
        public int outboundCnt;
        public int repeatCnt;
        public int initialCnt;


        public W_Maze_Gui()
        {
            CsvFiles.openRatDataCsv(); //open RatData.csv so we can read from it and access Rat info
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM3";
            serialPort.Open();

            while (!CsvFiles.ratdataReader.EndOfStream) //this reads the RatData.csv file and makes a dictionary for the ages and for the session number
            {
                var line = CsvFiles.ratdataReader.ReadLine();
                var vals = line.Split(',');
                name_to_age.Add(vals[0], vals[1]);
                name_to_session.Add(vals[0], Int32.Parse(vals[2]));
                ratName.Add(vals[0]);
            }
            CsvFiles.closeRatDataCsv();

            //Felix(The BackroundWorker)
            felix.DoWork += listen_to_arduino;
            felix.RunWorkerCompleted += run_worker_completed;

            felix.RunWorkerAsync();
            InitializeComponent();
            foreach (var rat in ratName) this.RatSelection.Items.Add(rat);

        }
        public void listen_to_arduino(object sender, DoWorkEventArgs e) //The "listener" that is the mediator between the worker (Felix) and the updater
        {

            try
            {
                var changedData = serialPort.ReadTo("\n");
                e.Result = changedData;
            }
            catch (Exception) { }

        }

        public void run_worker_completed(object sender, RunWorkerCompletedEventArgs e)//The updater that updates the GUI with the new info
        {
            if (!e.Cancelled && e.Error == null && e.Result != null)
            {
                var messageType = e.Result.ToString().Substring(0, 1);
                //CsvFiles.timestampCsv.Write($"{messageType},{DateTime.Today.ToShortTimeString()} \n");
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

        private void W_Maze_Gui_Load(object sender, EventArgs e)
        {
        }
        private void SelectButtonClick(object sender, EventArgs e)//When you click "Select" you lock in the rat number and info
        {
            selectButton.Hide();
            RatSelection.Hide();
            ratSelectionLabel.Text = $"{ratName[RatSelection.SelectedIndex]}";
            var chosenRat = ratName[RatSelection.SelectedIndex];
            ageLabel.Text = name_to_age[chosenRat];
            sessionLabel.Text = name_to_session[chosenRat].ToString();
            CsvFiles.openSessionCsv(chosenRat);
            ratWasChosen = true;
            CsvFiles.openWriteToRatData();
            foreach (var ratname in name_to_age.Keys)
            {
                if (ratname == chosenRat)
                {
                    name_to_session[ratname]++;
                }
                CsvFiles.ratdataWriter.Write($"{ratname},{name_to_age[ratname]},{name_to_session[ratname]}\n");
            }
            //CsvFiles.openTimestampCsv(chosenRat);

        }

        private void StartButtonClick(object sender, EventArgs e) //Clicking "Start" starts the timer and you can only start after you have selected a rat and locked it in
        {
            if (ratWasChosen)
            {
                startButton.ForeColor = Color.AliceBlue;
                Recording_Time.Enabled = true;
                updateTime();
            }
            else;
        }

        private void increment_time(object sender, EventArgs e)//Allows the timer to tick up
        {
            elapsed_time += 1;
            updateTime();

        }

        private void updateTime()//Displays the current length of the session
        {
            var mins_ones = (elapsed_time / 60) % 10;
            var mins_tens = (elapsed_time / 60) / 10;
            var secs_ones = (elapsed_time % 60) % 10;
            var secs_tens = (elapsed_time % 60) / 10;
            display_time.Text = $"{mins_tens}{mins_ones}:{secs_tens}{secs_ones}";
        }

        private void stopButton_Click(object sender, EventArgs e) //Clicking "Stop" stops the timer
        {
            startButton.ForeColor = Color.FromArgb(0, 40, 0);
            Recording_Time.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void SaveButtonClick(object sender, EventArgs e) //Hitting the save button saves the session info to SessionInfo_{rat#} as well as a screen shot of the GUI
        {
            saveButton.ForeColor = Color.DarkGray;
            CsvFiles.sessionCsv.Write($"{this.sessionLabel.Text},{this.experimenterBox.Text},{DateTime.Now.ToString()},{this.display_time.Text}," +
            $"{this.correctNum.Text},{this.initialNum.Text},{this.outboundNum.Text},{this.inboundNum.Text},{this.repeatNum.Text},{this.totalErrNum.Text},{this.totalNum.Text}," +
            $"{this.notesBox.Text}\n");
            CsvFiles.close();

        }
        private void W_Maze_Gui_FormClosing(object sender, FormClosingEventArgs e) //Opens the exitConfirm form to ensure that you are purposefully exiting the GUI
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

    }

}