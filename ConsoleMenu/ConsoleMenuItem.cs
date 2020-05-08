using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUDev.ConsoleMenu {
    /// <summary>
    /// An item in a ConsoleMenu.
    /// </summary>
    public class ConsoleMenuItem {
        /// <summary>
        /// Its key.
        /// </summary>
        public ConsoleKeyInfo key;
        /// <summary>
        /// Its description, shown in a ConsoleMenu.
        /// </summary>
        public string description;
        /// <summary>
        /// What should the item execute when chosen?
        /// </summary>
        public Action execute;
        /// <summary>
        /// Special separator item, shown as a new line.
        /// </summary>
        public static ConsoleMenuItem separator {
            get {
                return new ConsoleMenuItem {
                    // This description is a marker if the code fails to find a separator by reference
                    description = "Sepr.=2",
                    // Set its execute function to a little secret
                    execute = new Action(() => Console.WriteLine("You managed to execute a separator."))
                };
            }
        }
    }
}
