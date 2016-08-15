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
            ratdataReader = new StreamReader("RatData.csv",true);
        }
        public static void openWriteToRatData()
        {
            ratdataWriter = new StreamWriter("RatData.csv");
        }
        public static void closeRatDataCsv()
        {
            ratdataReader.Close();
        }
        public static void openSessionCsv(string number)
        {
            if (!Directory.Exists($"RatData\\{number}"))
            {
                Directory.CreateDirectory($"RatData\\{number}");
            }
            sessionCsv = new StreamWriter(($"RatData\\{number}\\SessionInfo_{number}.csv"),true);

            
        }
        public static void openTimestampCsv(string number, string session)
        {
            if (!Directory.Exists($"RatData\\{number}\\TimeStamps"))
                {
                Directory.CreateDirectory($"RatData\\{number}\\TimeStamps");
                }
                timestampCsv = new StreamWriter($"RatData\\{number}\\TimeStamps\\TimeStamps_{number}_Session{session}.csv");
        }
        public static void close()
        {
            sessionCsv.Close();
            timestampCsv.Close();
            ratdataWriter.Close();
        }

    }
}
