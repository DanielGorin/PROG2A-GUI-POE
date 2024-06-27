using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2A_GUI_POE
{
    public static class DataStore
    {
        public static Dictionary<string,Recipe> Book { get; set; } = new Dictionary<string, Recipe>();
        public static string selection { get; set; }
    }
}
