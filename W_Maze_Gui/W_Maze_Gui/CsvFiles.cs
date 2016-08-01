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
        public static void openSessionCsv(string number)
        {
           
            sessionCsv = new StreamWriter(($"SessionInfo_{number}.csv"),true);
        }
        public static void openTimestampCsv(string number)
        {
            timestampCsv = new StreamWriter(File.OpenWrite($"TimeStamps_{number}_{DateTime.Today.ToString().Replace("/", "")}"));
            return timestampCsv;
        }

    }
}
