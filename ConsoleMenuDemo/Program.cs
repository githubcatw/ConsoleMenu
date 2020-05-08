using NUDev.ConsoleMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuDemo {

    class Program {

        static int rec = 0;

        static void Main(string[] args) {
            ConsoleMenu cm = new ConsoleMenu();
            cm.greeting = "Welcome to the ConsoleMenu demo!";
            cm.items = new ConsoleMenuItem[] {
                new ConsoleMenuItem {
                    key = ToCKI(ConsoleKey.D1, '1'),
                    execute = new Action(Act),
                    description = "Do something"
                },
                new ConsoleMenuItem {
                    key = ToCKI(ConsoleKey.D2, '2'),
                    execute = new Action(DoNothing),
                    description = "Do nothing"
                },
                ConsoleMenuItem.separator,
                new ConsoleMenuItem {
                    key = ToCKI(ConsoleKey.D3, '3'),
                    execute = new Action(Loop),
                    description = "Define recursion"
                }
            };
            cm.Render();
        }

        // A simple function.
        static void Act() {
            Console.WriteLine("something");
            Console.ReadKey();
            return;
        }

        // Recursive function that renders a ConsoleMenu. Since Render() is an infinite loop
        // you never exit this recursive menu.
        static void Loop() {
            rec++;
            ConsoleMenu cm = new ConsoleMenu();
            cm.greeting = "Welcome to the ConsoleMenu demo! (layer " + rec + ")";
            cm.items = new ConsoleMenuItem[] {
                new ConsoleMenuItem {
                    key = ToCKI(ConsoleKey.D1, '1'),
                    execute = new Action(Act),
                    description = "Do something"
                },
                new ConsoleMenuItem {
                    key = ToCKI(ConsoleKey.D2, '2'),
                    execute = new Action(DoNothing),
                    description = "Do nothing"
                },
                ConsoleMenuItem.separator,
                new ConsoleMenuItem {
                    key = ToCKI(ConsoleKey.D3, '3'),
                    execute = new Action(Loop),
                    description = "Define recursion"
                }
            };
            cm.Render();
            return;
        }

        // A minimal function. This is all you need to make an execute action.
        static void DoNothing() { return; }

        // Helper function that converts a ConsoleKey to ConsoleKeyInfo
        static ConsoleKeyInfo ToCKI(ConsoleKey ck, char ckName) => new ConsoleKeyInfo(ckName, ck, false, false, false);
    }
}
