using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace W_Maze_Gui
{
    public static class CsvFiles
    {
        public static StreamWriter sessionCsv;
        public static StreamWriter timestampCsv;
        public static StreamReader ratdataReader;
        public static StreamWriter ratdataWriter;
        public static void openRatDataCsv()
        {
            ratdataReader = new StreamReader("C:\\Users\\Adele\\Documents\\Barnes Lab\\Wmaze\\RatData\\RatData.csv",true);
        }
        public static void openWriteToRatData()
        {
            ratdataWriter = new StreamWriter("C:\\Users\\Adele\\Documents\\Barnes Lab\\Wmaze\\RatData\\RatData.csv");
        }
        public static void closeRatDataCsv()
        {
            ratdataReader.Close();
        }
        public static void openSessionCsv(string number)
        {
            if (!Directory.Exists($"C:\\Users\\Adele\\Documents\\Barnes Lab\\Wmaze\\RatData\\{number}"))
            {
                Directory.CreateDirectory($"C:\\Users\\Adele\\Documents\\Barnes Lab\\Wmaze\\RatData\\{number}");
            }
            sessionCsv = new StreamWriter(($"C:\\Users\\Adele\\Documents\\Barnes Lab\\Wmaze\\RatData\\{number}\\SessionInfo_{number}.csv"),true);

            
        }
        public static void openTimestampCsv(string number)
        {
            //timestampCsv = new StreamWriter(File.OpenWrite($"TimeStamps_{number}_{DateTime.Today.ToString().Replace("/", "")}"));
        }
        public static void close()
        {
            sessionCsv.Close();
            //timestampCsv.Close();
            ratdataWriter.Close();
        }

    }
}
