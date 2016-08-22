﻿using System;
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
        public bool splash = true;
        private int _elapsed_time;
        private bool _exiting;
        private bool ratWasChosen = false;
        private readonly Form exitConfirm = new ExitConfirm();
        private List<string> ratName = new List<string>();
        private List<string> ratAge = new List<string>();
        private List<string> ratSession = new List<string>();
        private Dictionary<string, string> name_to_age = new Dictionary<string, string>();
        private Dictionary<string, int> name_to_session = new Dictionary<string, int>();
        private static SerialPort serialPort = new SerialPort(); //recently made static; if there are issues with making an instance of W_Maze_GUI, change back
        public BackgroundWorker felix = new BackgroundWorker();
        public int correctCnt;
        public int inboundCnt;
        public int outboundCnt;
        public int repeatCnt;
        public int initialCnt;
        public string sessionNumber;
        public bool saved;
        public int totes;
        public string ratbeingtested;
        public string lastMessage;


        public W_Maze_Gui()
        {
            CsvFiles.openRatDataCsv(); //open RatData.csv so we can read from it and access Rat info
            //serialPort.BaudRate = 9600;
            //serialPort.PortName = "COM3";
            //serialPort.ReadTimeout = 10000;
            //serialPort.Encoding = Encoding.UTF8;
            //serialPort.DiscardNull = true;
            //serialPort.WriteBufferSize = 10000;
            //serialPort.Open();


            while (!CsvFiles.ratdataReader.EndOfStream) //this reads the RatData.csv file and makes a dictionary for the ages and for the session number
            {
                var line = CsvFiles.ratdataReader.ReadLine();
                var vals = line.Split(',');
                name_to_age.Add(vals[0], vals[1]);
                name_to_session.Add(vals[0], int.Parse(vals[2]));
                ratName.Add(vals[0]);
            }
            CsvFiles.closeRatDataCsv();


            InitializeComponent();

            foreach (var rat in ratName) this.RatSelection.Items.Add(rat);
            
        }
        private void W_Maze_Gui_Load(object sender, EventArgs e)
        {
            cleanButton.Hide();
            selectButton.Enabled = false;
            try
            {
                var message = new char[1] { 'L' };
                serialPort.Write(message, 0, 1);
            }
            catch (Exception ex) {; }
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
                switch (messageType)
                {
                    case "w":
                        startButton.ForeColor = Color.White;
                        break;
                    case "c":
                        correctCnt++;
                        correctNum.Text = correctCnt.ToString();
                        lastMessage = "c";
                        break;
                    case "i":
                        inboundCnt++;
                        inboundNum.Text = inboundCnt.ToString();
                        lastMessage = "i";
                        break;
                    case "o":
                        outboundCnt++;
                        outboundNum.Text = outboundCnt.ToString();
                        lastMessage = "o";
                        break;
                    case "r":
                        repeatCnt++;
                        repeatNum.Text = repeatCnt.ToString();
                        lastMessage = "r";
                        break;
                    case "b":
                        initialCnt++;
                        initialNum.Text = initialCnt.ToString();
                        lastMessage = "b";
                        break;
                    case "1":
                        switch (lastMessage)
                        {
                            case "c":
                                CsvFiles.timestampCsv.Write($"1,Correct,{display_time.Text}\n");
                                break;
                            case "i":
                                CsvFiles.timestampCsv.Write($"1,Inbound Error,{display_time.Text}\n");
                                break;
                            case "o":
                                CsvFiles.timestampCsv.Write(($"1,Outbound Error,{display_time.Text}\n"));
                                break;
                            case "r":
                                CsvFiles.timestampCsv.Write(($"1,Repeat Error,{display_time.Text}\n"));
                                break;
                            case "b":
                                CsvFiles.timestampCsv.Write($"1,Initial Error,{display_time.Text}\n");
                                break;
                        }
                        
                        break;
                    case "2":
                        switch (lastMessage)
                        {
                            case "c":
                                CsvFiles.timestampCsv.Write($"2,Correct,{display_time.Text}\n");
                                break;
                            case "i":
                                CsvFiles.timestampCsv.Write($"2,Inbound Error,{display_time.Text}\n");
                                break;
                            case "o":
                                CsvFiles.timestampCsv.Write(($"2,Outbound Error,{display_time.Text}\n"));
                                break;
                            case "r":
                                CsvFiles.timestampCsv.Write(($"2,Repeat Error,{display_time.Text}\n"));
                                break;
                            case "b":
                                CsvFiles.timestampCsv.Write($"2,Initial Error,{display_time.Text}\n");
                                break;
                        }
                        
                        break;
                    case "3":
                        switch (lastMessage)
                        {
                            case "c":
                                CsvFiles.timestampCsv.Write($"3,Correct,{display_time.Text}\n");
                                break;
                            case "i":
                                CsvFiles.timestampCsv.Write($"3,Inbound Error,{display_time.Text}\n");
                                break;
                            case "o":
                                CsvFiles.timestampCsv.Write(($"3,Outbound Error,{display_time.Text}\n"));
                                break;
                            case "r":
                                CsvFiles.timestampCsv.Write(($"3,Repeat Error,{display_time.Text}\n"));
                                break;
                            case "b":
                                CsvFiles.timestampCsv.Write($"3,Initial Error,{display_time.Text}\n");
                                break;
                        }
                        
                        break;
                }
                totes = (inboundCnt + repeatCnt + initialCnt + outboundCnt);
                totalErrNum.Text = totes.ToString();
                totalNum.Text = (totes + correctCnt).ToString();
            }

            if (!felix.IsBusy)
                felix.RunWorkerAsync();

        }

        private void SelectButtonClick(object sender, EventArgs e)
            //When you click "Select" you lock in the rat number and info
        {
            if (RatSelection.SelectedIndex >= 0)
            {
                //Felix(The BackroundWorker)
                felix.DoWork += listen_to_arduino;
                felix.RunWorkerCompleted += run_worker_completed;
                felix.RunWorkerAsync();

                selectButton.Hide();
                RatSelection.Hide();
                saveButton.Enabled = true;
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
                sessionNumber = (name_to_session[chosenRat] - 1).ToString();
                ratbeingtested = ratName[RatSelection.SelectedIndex];
                CsvFiles.openTimestampCsv(chosenRat, sessionNumber);
                CsvFiles.timestampCsv.Write("Feeder,Type,Timestamp\n");
                CsvFiles.ratdataClose();
            }
        }

        private void StartButtonClick(object sender, EventArgs e) //Clicking "Start" starts the timer and you can only start after you have selected a rat and locked it in
        {
            fillButton.Hide();
            if (ratWasChosen)
            {
                startButton.ForeColor = Color.AliceBlue;
                Recording_Time.Enabled = true;
                updateTime();
            }
            else
            {
                var ratWindow = new SelectRatWindow();
                ratWindow.StartPosition = FormStartPosition.CenterParent;
                ratWindow.ShowDialog();

            }
        }

        private void increment_time(object sender, EventArgs e)//Allows the timer to tick up
        {
            _elapsed_time += 1;
            updateTime();

        }

        private void updateTime()//Displays the current length of the session
        {
            var mins_ones = (_elapsed_time / 60) % 10;
            var mins_tens = (_elapsed_time / 60) / 10;
            var secs_ones = (_elapsed_time % 60) % 10;
            var secs_tens = (_elapsed_time % 60) / 10;
            display_time.Text = $"{mins_tens}{mins_ones}:{secs_tens}{secs_ones}";
        }

        private void stopButton_Click(object sender, EventArgs e) //Clicking "Stop" stops the timer
        {
            startButton.ForeColor = Color.FromArgb(0, 40, 0);
            Recording_Time.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
        }
        private void SaveButtonClick(object sender, EventArgs e) //Hitting the save button saves the session info to SessionInfo_{rat#} as well as a screen shot of the GUI
        {
            if (ratWasChosen)
            {
                this.Show();
                stopButton_Click(sender, e);
                saveButton.ForeColor = Color.DarkGray;
                CsvFiles.sessionCsv.Write($"{this.sessionLabel.Text},{this.experimenterBox.Text},{DateTime.Now.ToString()},{this.display_time.Text},{this.correctNum.Text},{this.initialNum.Text},{this.outboundNum.Text},{this.inboundNum.Text},{this.repeatNum.Text},{this.totalErrNum.Text},{this.totalNum.Text},{this.notesBox.Text}\n");
                CsvFiles.close();

                if (!Directory.Exists ($"C:\\Users\\Adele\\Documents\\Barnes Lab\\Wmaze\\RatData\\{ratName[RatSelection.SelectedIndex]}\\ScreenShots"))
                {
                    Directory.CreateDirectory(
                        $"C:\\Users\\Adele\\Documents\\Barnes Lab\\Wmaze\\RatData\\{ratName[RatSelection.SelectedIndex]}\\ScreenShots");
                }
                var bmpScreenCapture = new Bitmap(this.Width, this.Height);
                DrawToBitmap(bmpScreenCapture, new Rectangle(0, 0, bmpScreenCapture.Width, bmpScreenCapture.Height));
                bmpScreenCapture.Save(
                    $"C:\\Users\\Adele\\Documents\\Barnes Lab\\Wmaze\\RatData\\{ratName[RatSelection.SelectedIndex]}\\ScreenShots\\GUIscreenshot_{ratName[RatSelection.SelectedIndex]}_Session{sessionNumber}.gif",
                    ImageFormat.Gif);
                saved = true;
                cleanButton.Show();
            }
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
                if (!saved)
                {
                    if (ratWasChosen)
                    {
                        CsvFiles.openWriteToRatData();
                        
                        foreach (var ratname in name_to_age.Keys)
                        {
                            if (ratname == ratbeingtested)
                            {
                                name_to_session[ratname]--;
                            }
                            CsvFiles.ratdataWriter.Write($"{ratname},{name_to_age[ratname]},{name_to_session[ratname]}\n");
                        
                        }
                        CsvFiles.ratdataClose();
                        CsvFiles.close();
                    }

                   
                }
            }
        }

        private void fillFeeders(object sender, EventArgs e)
        {
            var fill_feeders = new FillFeederWin();
            fill_feeders.StartPosition = FormStartPosition.CenterParent;
            fill_feeders.ShowDialog();
        }

        private void cleanFeeders(object sender, EventArgs e)
        {
            
        }
        public static void sendMessage(int button)
        {
            switch (button)
            {
                case 1:
                    try
                    {
                        var message = new char[1] { 'X' };
                        serialPort.Write(message, 0, 1);
                    }
                    catch (Exception ex) {; }
                    break;
                case 2:
                    try
                    {
                        var message = new char[1] { 'Y' };
                        serialPort.Write(message, 0, 1);
                    }
                    catch (Exception ex) {; }
                    break;
                case 3:
                    try
                    {
                        var message = new char[1] { 'Z' };
                        serialPort.Write(message, 0, 1);
                    }
                    catch (Exception ex) {; }
                    break;
                case 11:
                    try
                    {
                        var message = new char[1] { 'x' };
                        serialPort.Write(message, 0, 1);
                    }
                    catch (Exception ex) {; }
                    break;
                case 22:
                    try
                    {
                        var message = new char[1] { 'y' };
                        serialPort.Write(message, 0, 1);
                    }
                    catch (Exception ex) {; }
                    break;
                case 33:
                    try
                    {
                        var message = new char[1] { 'z' };
                        serialPort.Write(message, 0, 1);
                    }
                    catch (Exception ex) {; }
                    break;
            }
        }
    }

}