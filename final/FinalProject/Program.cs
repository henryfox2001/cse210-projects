using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Call MainMenu
        Menu choice = new MainMenu();
        
        choice.MenuChoice();
    }
}
