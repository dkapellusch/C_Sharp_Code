using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace W_Maze_Gui
{
    static class Extensions
    {
        public static byte[] GetBytes(this string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

    }
}
