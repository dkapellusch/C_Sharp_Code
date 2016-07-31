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
        public static StreamWriter openSessionCsv(string number)
        {
           
            sessionCsv = new StreamWriter(File.OpenWrite($"SessionInfo_{number}.csv"));
            return sessionCsv;
        }
        public static StreamWriter openTimestampCsv(string number)
        {
            timestampCsv = new StreamWriter(File.OpenWrite($"TimeStamps_{number}_{DateTime.Today.ToString().Replace("/", "")}"));
            return timestampCsv;
        }

    }
}
