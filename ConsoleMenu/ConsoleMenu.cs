using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUDev.ConsoleMenu {
    /// <summary>
    /// A console-based menu.
    /// </summary>
    public class ConsoleMenu {
        /// <summary>
        /// The ConsoleMenuItems it consists of.
        /// </summary>
        public ConsoleMenuItem[] items;
        /// <summary>
        /// A greeting message, shown at the start.
        /// </summary>
        public string greeting;
        /// <summary>
        /// Render a ConsoleMenu to the console. This function is an infinite loop.
        /// </summary>
        public void Render() {
            // Forever:
            while (true) {
                // Print the greeting
                Console.WriteLine(greeting);
                // Ask for input
                Console.WriteLine("What do you want to do?\n");
                // For each MenuItem:
                foreach (var i in items) {
                    // If it's a separator:
                    if (isSeparator(i))
                        // Write a blank line
                        Console.WriteLine();
                    // Else:
                    else
                        // Write its key and descripion
                        Console.WriteLine(i.key.KeyChar + ": " + i.description);
                }
                // Write another blank space
                Console.WriteLine();
                // Ask for input
                Console.Write("> ");
                var key = Console.ReadKey().Key;
                // For each item:
                foreach (var i in items) {
                    // Clear the screen
                    Console.Clear();
                    // If we input the item's key and it isn't a separator:
                    if (i.key.Key == key && !isSeparator(i)) {
                        // Execute the item
                        i.execute();
                        // Clear the screen again
                        Console.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Is the passed menu item a separator?
        /// </summary>
        /// <param name="suspect"></param>
        /// <returns></returns>
        bool isSeparator(ConsoleMenuItem suspect) => suspect == ConsoleMenuItem.separator || suspect.description == "Sepr.=2";
    }
}
