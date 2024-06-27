using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2A_GUI_POE
{
    public static class DataStore
    {
        //used to edit the recipe list from any of the 3 windows
        public static Dictionary<string,Recipe> Book { get; set; } = new Dictionary<string, Recipe>();
        //used to indicate whcih recipe from the list (for editing and displaying)
        public static string selection { get; set; }
        //used to indicate wheather to open the Add/Edit window in Add or Edit Mode.
        public static bool edtmode { get; set; }
    }
}
