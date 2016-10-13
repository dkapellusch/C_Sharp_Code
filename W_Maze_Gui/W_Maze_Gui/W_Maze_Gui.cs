using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

//using System.Imaging;

namespace W_Maze_Gui
{
    public partial class W_Maze_Gui : Form
    {
        private static readonly SerialPort serialPort = new SerialPort();
        //recently made static; if there are issues with making an instance of W_Maze_GUI, change back

        private readonly Form exitConfirm = new ExitConfirm();
        private readonly Dictionary<string, string> name_to_age = new Dictionary<string, string>();
        private readonly Dictionary<string, int> name_to_session = new Dictionary<string, int>();
        private readonly List<string> ratName = new List<string>();
        private int _elapsed_time;
        private bool _exiting;
        public int correctCnt;
        public string day;
        public BackgroundWorker felix = new BackgroundWorker();
        public string hour;
        public int inboundCnt;
        public int initialCnt;
        public string lastMessage;
        public string minute;
        public string month;
        public int outboundCnt;
        private List<string> ratAge = new List<string>();
        public string ratbeingtested;
        private List<string> ratSession = new List<string>();
        private bool ratWasChosen;
        public int repeatCnt;
        public bool saved;
        public string sessionNumber;
        public bool splash = true;
        public int totes;
        public string year;
        bool SessionHasBegun;



        public W_Maze_Gui()
        {
            CsvFiles.OpenRatDataCsv(); //open RatData.csv so we can read from it and access Rat info
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM3";
            serialPort.ReadTimeout = 10000;
            serialPort.Encoding = Encoding.UTF8;
            serialPort.DiscardNull = true;
            serialPort.WriteBufferSize = 10000;
            serialPort.Open();



            while (!CsvFiles.RatdataReader.EndOfStream)
                //this reads the RatData.csv file and makes a dictionary for the ages and for the session number
            {
                var line = CsvFiles.RatdataReader.ReadLine();
                var vals = line.Split(',');
                name_to_age.Add(vals[0], vals[1]);
                name_to_session.Add(vals[0], int.Parse(vals[2]));
                ratName.Add(vals[0]);
            }
            CsvFiles.CloseRatDataCsv();

   

            InitializeComponent();

            foreach (var rat in ratName) RatSelection.Items.Add(rat);
        }

        private string fixDateTime(int x)
        {
            if (x < 10)
                return $"0{x}";
            return x.ToString();
        }

        private void W_Maze_Gui_Load(object sender, EventArgs e) //When the Gui window loads do the following
        {
            cleanButton.Hide();
            selectButton.Enabled = false;

            var moment = new DateTime();
            year = moment.Year.ToString();
            month = fixDateTime(moment.Month);
            day = fixDateTime(moment.Day);
            minute = fixDateTime(moment.Minute);
            hour = fixDateTime(moment.Hour);

    }

        public void listen_to_arduino(object sender, DoWorkEventArgs e)
            //The "listener" that is the mediator between the worker (Felix) and the updater
        {
            try
            {
                var changedData = serialPort.ReadTo("\n");
                e.Result = changedData;
            }
            catch (Exception)
            {
            }
        }

        private void SelectButtonClick(object sender, EventArgs e)
            //When you click "Select" you lock in the rat number and info
        {
            cleanButton.Show();
            if (RatSelection.SelectedIndex >= 0)
            {
                selectButton.Hide();
                RatSelection.Hide();
                saveButton.Enabled = true;
                ratSelectionLabel.Text = $"{ratName[RatSelection.SelectedIndex]}";
                var chosenRat = ratName[RatSelection.SelectedIndex];
                ageLabel.Text = name_to_age[chosenRat];
                sessionLabel.Text = name_to_session[chosenRat].ToString();
                CsvFiles.OpenSessionCsv(chosenRat);
                ratWasChosen = true;
                CsvFiles.OpenWriteToRatData();
                foreach (var ratname in name_to_age.Keys)
                {
                    if (ratname == chosenRat)
                        name_to_session[ratname]++;
                    CsvFiles.RatdataWriter.Write(
                        $"{ratname},{name_to_age[ratname]},{name_to_session[ratname]}\n");
                }
                sessionNumber = (name_to_session[chosenRat] - 1).ToString();
                ratbeingtested = ratName[RatSelection.SelectedIndex];
                CsvFiles.OpenTimestampCsv(chosenRat, sessionNumber);
                CsvFiles.TimestampCsv.Write("Feeder,Type,Timestamp\n");
                CsvFiles.RatdataClose();
            }
        }

        private void StartButtonClick(object sender, EventArgs e)
            //Clicking "Start" starts the timer and you can only start after you have selected a rat and locked it in
        {
            fillButton.Hide();
            SessionHasBegun = true;
            if (ratWasChosen)
            {
                startButton.ForeColor = Color.AliceBlue;
                Recording_Time.Enabled = true;
                updateTime();

                correctCnt = 0;
                inboundCnt = 0;
                outboundCnt = 0;
                repeatCnt = 0;
                initialCnt = 0;
                totes = 0;

                correctNum.Text = "0";
                inboundNum.Text = "0";
                outboundNum.Text = "0";
                repeatNum.Text = "0";
                initialNum.Text = "0";
                totalErrNum.Text = "0";
                totalNum.Text = "0";
            }
            else
            {
                var ratWindow = new SelectRatWindow();
                ratWindow.StartPosition = FormStartPosition.CenterParent;
                ratWindow.ShowDialog();
            }
            try //sends a message to the UNO to reinitialize variables
            {
                var message = new char[1] { 'L' };
                serialPort.Write(message, 0, 1);
            }
            catch (Exception ex)
            {
                ;
            }

            //Felix(The BackroundWorker)
            felix.DoWork += listen_to_arduino;
            felix.RunWorkerCompleted += run_worker_completed;
            felix.RunWorkerAsync();

            startButton.Enabled = false;
        }

        private void increment_time(object sender, EventArgs e) //Allows the timer to tick up
        {
            _elapsed_time += 1;
            updateTime();
        }

        private void updateTime() //Displays the current length of the session
        {
            var mins_ones = _elapsed_time/60%10;
            var mins_tens = _elapsed_time/60/10;
            var secs_ones = _elapsed_time%60%10;
            var secs_tens = _elapsed_time%60/10;
            display_time.Text = $"{mins_tens}{mins_ones}:{secs_tens}{secs_ones}";
        }

        private void stopButton_Click(object sender, EventArgs e) //Clicking "Stop" stops the timer
        {
            startButton.ForeColor = Color.FromArgb(0, 40, 0);
            Recording_Time.Enabled = false;
        }

        private void ratSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
            //Enables the select button when you choose a rat from the combo box
        {
            selectButton.Enabled = true;
        }

        private void SaveButtonClick(object sender, EventArgs e)
            //Hitting the save button saves the session info to SessionInfo_{rat#} as well as a screen shot of the GUI
        {
            if (ratWasChosen)
            {
                Show();
                stopButton_Click(sender, e);
                saveButton.ForeColor = Color.DarkGray;
                saveButton.Enabled = false;
                CsvFiles.SessionCsv.Write(
                    $"{sessionLabel.Text},{experimenterBox.Text},{DateTime.Now},{display_time.Text},{correctNum.Text},{initialNum.Text},{outboundNum.Text},{inboundNum.Text},{repeatNum.Text},{totalErrNum.Text},{totalNum.Text},{notesBox.Text}\n");
                CsvFiles.Close();

                if (
                    !Directory.Exists(
                        $"C:\\Users\\akoutia\\Documents\\Barnes Lab\\Wmaze\\RatData\\{ratName[RatSelection.SelectedIndex]}\\ScreenShots"))
                    Directory.CreateDirectory(
                        $"C:\\Users\\akoutia\\Documents\\Barnes Lab\\Wmaze\\RatData\\{ratName[RatSelection.SelectedIndex]}\\ScreenShots");
                var bmpScreenCapture = new Bitmap(Width, Height);
                DrawToBitmap(bmpScreenCapture, new Rectangle(0, 0, bmpScreenCapture.Width, bmpScreenCapture.Height));
                bmpScreenCapture.Save(
                    $"C:\\Users\\akoutia\\Documents\\Barnes Lab\\Wmaze\\RatData\\{ratName[RatSelection.SelectedIndex]}\\ScreenShots\\GUIscreenshot_{ratName[RatSelection.SelectedIndex]}_Session{sessionNumber}.gif",
                    ImageFormat.Gif);
                saved = true;

                if (
                    File.Exists(
                        $"C:\\Users\\akoutia\\Documents\\Barnes Lab\\Wmaze\\Videos\\Composite_{year}{month}{day}_{hour}{minute}"))
                {
                    if (
                        !Directory.Exists(
                            $"C:\\Users\\akoutia\\Documents\\Barnes Lab\\Wmaze\\Videos\\{RatSelection.SelectedIndex}"))
                        Directory.CreateDirectory(
                            $"C:\\Users\\akoutia\\Documents\\Barnes Lab\\Wmaze\\Videos\\{RatSelection.SelectedIndex}");

                    File.Move(
                        $"C:\\Users\\akoutia\\Documents\\Barnes Lab\\Wmaze\\Videos\\Composite_{year}{month}{day}_{hour}{minute}.ts",
                        $"C:\\Users\\akoutia\\Documents\\Barnes Lab\\Wmaze\\Videos\\{RatSelection.SelectedIndex}\\Composite_{year}{month}{day}_{hour}{minute}.mpeg");
                }
            }
        }

        private void W_Maze_Gui_FormClosing(object sender, FormClosingEventArgs e)
            //Opens the exitConfirm form to ensure that you are purposefully exiting the GUI
        {
            if (!_exiting)
            {
                _exiting = true;
                exitConfirm.StartPosition = FormStartPosition.CenterParent;
                exitConfirm.ShowDialog();
                e.Cancel = true;
                _exiting = false;
                if (!saved)
                    if (ratWasChosen)
                    {
                        CsvFiles.OpenWriteToRatData();

                        foreach (var ratname in name_to_age.Keys)
                        {
                            if (ratname == ratbeingtested)
                                name_to_session[ratname]--;
                            CsvFiles.RatdataWriter.Write(
                                $"{ratname},{name_to_age[ratname]},{name_to_session[ratname]}\n");
                        }
                        CsvFiles.RatdataClose();
                        CsvFiles.Close();
                    }
            }
        }

        private void fillFeeders(object sender, EventArgs e) //opens the fill feeders window
        {
            var fill_feeders = new FillFeederWin();
            fill_feeders.StartPosition = FormStartPosition.CenterParent;
            fill_feeders.ShowDialog();
        }

        private void cleanFeeders(object sender, EventArgs e) //opens the clean feeders window
        {
            var fill_feeders = new FillFeederWin();
            fill_feeders.timeToClean();
            fill_feeders.StartPosition = FormStartPosition.CenterParent;
            fill_feeders.ShowDialog();
        }

        public static void sendMessage(string button) //handles messages to be sent to the UNO for filling/cleaning
        {
            switch (button)
            {
                case "1":
                    try
                    {
                        serialPort.Write(new[] {'X'}, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "2":
                    try
                    {
                        serialPort.Write(new[] {'Y'}, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "3":
                    try
                    {
                        serialPort.Write(new[] {'Z'}, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "11":
                    try
                    {
                        serialPort.Write(new[] {'x'}, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "22":
                    try
                    {
                        serialPort.Write(new[] {'y'}, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
                case "33":
                    try
                    {
                        serialPort.Write(new[] {'z'}, 0, 1);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    break;
            }
        }

        public void run_worker_completed(object sender, RunWorkerCompletedEventArgs e)
            //The updater that updates the GUI with the new info and writes to the Timestamp CSV
        {
                if (!e.Cancelled && (e.Error == null) && (e.Result != null) && SessionHasBegun)
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
                                    CsvFiles.TimestampCsv.Write($"1,Correct,{display_time.Text}\n");
                                    break;
                                case "i":
                                    CsvFiles.TimestampCsv.Write($"1,Inbound Error,{display_time.Text}\n");
                                    break;
                                case "o":
                                    CsvFiles.TimestampCsv.Write($"1,Outbound Error,{display_time.Text}\n");
                                    break;
                                case "r":
                                    CsvFiles.TimestampCsv.Write($"1,Repeat Error,{display_time.Text}\n");
                                    break;
                                case "b":
                                    CsvFiles.TimestampCsv.Write($"1,Initial Error,{display_time.Text}\n");
                                    break;
                            }

                            break;
                        case "2":
                            switch (lastMessage)
                            {
                                case "c":
                                    CsvFiles.TimestampCsv.Write($"2,Correct,{display_time.Text}\n");
                                    break;
                                case "i":
                                    CsvFiles.TimestampCsv.Write($"2,Inbound Error,{display_time.Text}\n");
                                    break;
                                case "o":
                                    CsvFiles.TimestampCsv.Write($"2,Outbound Error,{display_time.Text}\n");
                                    break;
                                case "r":
                                    CsvFiles.TimestampCsv.Write($"2,Repeat Error,{display_time.Text}\n");
                                    break;
                                case "b":
                                    CsvFiles.TimestampCsv.Write($"2,Initial Error,{display_time.Text}\n");
                                    break;
                            }

                            break;
                        case "3":
                            switch (lastMessage)
                            {
                                case "c":
                                    CsvFiles.TimestampCsv.Write($"3,Correct,{display_time.Text}\n");
                                    break;
                                case "i":
                                    CsvFiles.TimestampCsv.Write($"3,Inbound Error,{display_time.Text}\n");
                                    break;
                                case "o":
                                    CsvFiles.TimestampCsv.Write($"3,Outbound Error,{display_time.Text}\n");
                                    break;
                                case "r":
                                    CsvFiles.TimestampCsv.Write($"3,Repeat Error,{display_time.Text}\n");
                                    break;
                                case "b":
                                    CsvFiles.TimestampCsv.Write($"3,Initial Error,{display_time.Text}\n");
                                    break;
                            }

                            break;
                    }
                    totes = inboundCnt + repeatCnt + initialCnt + outboundCnt;
                    totalErrNum.Text = totes.ToString();
                    totalNum.Text = (totes + correctCnt).ToString();
                }

                if (!felix.IsBusy)
                    felix.RunWorkerAsync();
            }
        }
    }