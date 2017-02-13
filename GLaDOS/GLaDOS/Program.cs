using System;
using System.Media;
using WMPLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace GLaDOS
{
    class Program
    {
        static void Main(string[] args)
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            Console.Title = "--Remote Shell--";
            Console.CursorSize = 100;
            load();
            Directory.SetCurrentDirectory("C:\\GLaDOS_SHELL");
            String command = "";
            String prompt = "";
            do
            {
                if (Directory.GetCurrentDirectory() == "C:\\GLaDOS_SHELL")
                    prompt = "GLaDOS_SHELL [G:]> ";
                else
                {
                    try
                    {
                        prompt = "GLaDOS_Shell [G:" + Directory.GetCurrentDirectory().Substring(15) + "]> ";
                    }
                    catch
                    {
                        Console.WriteLine("Invalid syntax");
                    }
                }
                Console.Write(prompt);
                command = Console.ReadLine().ToLower();


                if (command == "clear" || command == "cls")
                {
                    Console.Clear();
                }
                try
                {
                    if (command == "rm")
                    {
                        Console.Write(">> ");
                        string filetodelete = Directory.GetCurrentDirectory() + "\\" + Console.ReadLine();
                        try
                        {
                            File.Delete(filetodelete);
                            Console.WriteLine("Deleted: " + filetodelete);
                        }
                        catch
                        {
                            Console.WriteLine("Could not find file '{0}'", filetodelete);
                        }
                    }
                }
                catch { }
                try
                {
                    if (command.Substring(0, 2) == "cd")
                    {
                        try
                        {
                            Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "\\" + command.Substring(3));
                        }
                        catch
                        {
                            try
                            {
                                Console.WriteLine("Could not CD to {0}", command.Substring(3));
                            }
                            catch
                            {
                                Console.WriteLine("Invalid syntax");
                            }
                        }
                    }
                }
                catch { }
                try
                {
                    if (command.Substring(0, 29) == "comment /specimen chell /name")
                    {
                        StreamWriter comment = new StreamWriter("C:\\GLaDOS_SHELL\\Logs\\Chell\\" + command.Substring(29) + ".txt");
                        Console.WriteLine("Comment: ");
                        comment.Write(Console.ReadLine());
                        comment.Close();
                    }
                }
                catch { }
                try
                {
                    if (command.Substring(0, 3) == "cat")
                    {
                        try
                        {
                            StreamReader cat = new StreamReader(Directory.GetCurrentDirectory() + "/" + command.Substring(4));
                            Console.Write(cat.ReadToEnd());
                            cat.Close();
                            Console.Write(Directory.GetCurrentDirectory());
                        }
                        catch
                        {
                            Console.WriteLine("Cannot find file " + command.Substring(4));
                        }
                    }
                }
                catch { };
                #region dir
                if (command == "")
                { 
                
                }
                if (command == "dir" | command == "ls")
                {
                    Console.WriteLine(Directory.GetCurrentDirectory());
                    Console.WriteLine("=========================================");
                    Console.WriteLine("Directories:\n");
                    string[] directories = Directory.GetDirectories(Directory.GetCurrentDirectory());
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (string directory in directories)
                    {
                        Console.WriteLine(directory.Substring(Directory.GetCurrentDirectory().Length+1));
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                    Console.WriteLine("Files: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
                    foreach (string file in files)
                    {
                        Console.WriteLine(file.Substring(Directory.GetCurrentDirectory().Length + 1));
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=========================================");
                }
                #endregion
                #region cd
                #endregion
                #region reboot
                if (command == "reboot")
                {
                    Console.Write("Enter password: ");
                    string passwrd = Console.ReadLine();
                    if (passwrd == "science")
                        load();
                    else
                        Console.WriteLine("incorrect password");
                }
                #endregion
                else if (command == "polishturrets.bat")
                {
                    try
                    {
                        Console.WriteLine("Executing polishTurrets.bat");
                        for (int i = 0; i < Directory.GetFiles("C:\\GLaDOS_SHELL\\Security\\Turrets").Length; i++)
                        {
                            Console.WriteLine("Polishing Turret[" + i.ToString() + "]");
                            Thread.Sleep(15);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("error - No existing turrets");
                    }
                }
                else if (command == "addturret.sh")
                {
                    StreamWriter turret = new StreamWriter("C:\\GLaDOS_SHELL\\Security\\Turrets\\Turret [" + Directory.GetFiles("C:\\GLaDOS_SHELL\\Security\\Turrets").Length.ToString()+ "].dat");
                    turret.WriteLine("tur_kill_software.dll");
                    turret.WriteLine("how_to_kill.inf");
                    turret.WriteLine("voices.mp3");

                    Console.Clear();
                    char curChar = '|';
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write("Initilizing addTurret.sh");
                        if (curChar == '|')
                            curChar = '/';
                        else if (curChar == '/')
                            curChar = '-';
                        else if (curChar == '~')
                            curChar = '\\';
                        else
                            curChar = curChar = '|';
                        Console.Write("  " + curChar.ToString());
                        Thread.Sleep(200);
                        Console.Clear();
                    }
                    Console.WriteLine("Initilizing addTurret.sh");
                    Thread.Sleep(1000);
                    Console.WriteLine("loading ammo...");
                    Thread.Sleep(200);
                    Console.WriteLine("testing...");
                    Thread.Sleep(500);
                    Console.WriteLine("shiping...");
                    Thread.Sleep(1000);
                    Console.WriteLine("done");
                    Console.WriteLine("unboxing...");
                    Thread.Sleep(50);
                    Console.WriteLine("setting up...");
                    Thread.Sleep(50);
                    Console.WriteLine("copying tur_kill_software.dll to G:\\Security\\Turrets\\Turret ["+Directory.GetFiles("C:\\GLaDOS_SHELL\\Security\\Turrets").Length.ToString()+"]...");
                    Thread.Sleep(200);
                    Console.WriteLine("copying how_to_kill.inf to G:\\Security\\Turrets\\Turret [" + Directory.GetFiles("C:\\GLaDOS_SHELL\\Security\\Turrets").Length.ToString() + "]...");
                    Thread.Sleep(200);
                    Console.WriteLine("copying voices.mp3 to G:\\Security\\Turrets\\Turret [" + Directory.GetFiles("C:\\GLaDOS_SHELL\\Security\\Turrets").Length.ToString() + "]...");
                    Thread.Sleep(2000);
                    Console.WriteLine("done");
                    turret.Close();
                }
                else if (command == "play")
                {
                    Console.WriteLine();
                    Console.WriteLine("Still Alive");
                    Console.WriteLine("Want You Gone");
                    Console.WriteLine("Cara Mia Addio");
                    Console.Write(">> ");
                    string song = Console.ReadLine().ToLower();
                    if (song == "still alive")
                    {
                        wplayer.controls.stop();
                        wplayer.URL = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Apps\2.0\HD2P3331.J56\2OL0M709.1KC\glad..tion_a55e0dd50ed2d7fd_0009.0008_008fcb05b7861780\Portal - 'Still Alive'.mp3";
                        Console.WriteLine(wplayer.URL);
                        wplayer.controls.play();
                    }
                    if (song == "cara mia addio")
                    {
                        wplayer.controls.stop();
                        wplayer.URL = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Apps\2.0\HD2P3331.J56\2OL0M709.1KC\glad..tion_a55e0dd50ed2d7fd_0009.0008_008fcb05b7861780\Portal 2 Cara Mia Addio (full, HQ audio).mp3";
                        wplayer.controls.play();
                    }
                    if (song == "want you gone")
                    {
                        wplayer.controls.stop();
                        wplayer.URL = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Apps\2.0\HD2P3331.J56\2OL0M709.1KC\glad..tion_a55e0dd50ed2d7fd_0009.0008_008fcb05b7861780\Portal 2 End Credits Song 'Want You Gone' by Jonathan Coulton [1080p HD].mp3";
                        wplayer.controls.play();
                    }
                }
                else if (command == "stop")
                {
                    wplayer.controls.stop();
                }
                else if (command == "write")
                    ascienceWrite();
                else    {}
            }
            while (command != "exit");
        }

        public static void load()
        {
            SetUpFileSystem();
            Console.WindowLeft = Console.WindowTop = 0;
//          Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
//          Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.WindowHeight = 40;
            Console.WindowWidth = 110;
            DrawApertureScience(false);
            loadingScreen(5);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(1500);
            bool Vlogin = false;
            do
            {
                Console.Write("login> ");
                string username = Console.ReadLine().ToLower();
                if (username == "glados")
                {
                    Console.Clear();
                    Console.Write("password> ");
                    string pass = Console.ReadLine();
                    if (pass == "science")
                        Vlogin = true;
                    else
                        Console.WriteLine("incorrect password -- attempt logged");
                }
                else
                    Console.WriteLine("incorrect username -- attempt logged");
            }
            while (!Vlogin);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "--Remote Shell-- USER: GLaDOS";
            Console.WriteLine("GLaDOS [v1.5.3.96] \n(c) 1982 Aperture Science");
            Console.Write("\n\n");
        }


        public static void loadingScreen(int time)
        {
            char curChar = '|';
            for (int i = 0; i < (4 * time); i++)
            {
                Thread.Sleep(250);
                Console.Clear();
                DrawApertureScience(true);
                Console.Write("Loading...");
                if (curChar == '|')
                    curChar = '/';
                else if (curChar == '/')
                    curChar = '-';
                else if (curChar == '-')
                    curChar = '\\';
                else
                    curChar = curChar = '|';
                Console.Write("  " + curChar.ToString());
            }
            Console.Clear();
        }

        #region
        /// <summary>
        /// Draws Aperture-Science Logo
        /// </summary>
        /// <param name="Instant">Instant?</param>
        public static void DrawApertureScience(bool Instant)
        {
            if (!Instant)
            {
                Console.WriteLine("                              ``.---------..`                              ");
                Thread.Sleep(20);
                Console.WriteLine("                        `-:/+ooooooooooooooooo+/.                          ");
                Thread.Sleep(20);
                Console.WriteLine("                   `.`   -/ooooooooooooooooooooo+  `/:.`                   ");
                Thread.Sleep(20);
                Console.WriteLine("                `-/ooo/.   `-/ooooooooooooooooooo`  +ooo/-`                ");
                Thread.Sleep(20);
                Console.WriteLine("              ./oooooooo+:.   `-/oooooooooooooooo:  -oooooo/.              ");
                Thread.Sleep(20);
                Console.WriteLine("            -+ooooooooooooo+:.   `:+ooooooooooooo+  `oooooooo+-`           ");
                Thread.Sleep(20);
                Console.WriteLine("          -+oooooooooooooooooo+:.   `:+ooooooooooo.  /ooooooooo+-          ");
                Thread.Sleep(20);
                Console.WriteLine("        `/ooooooooooooooooooooooo+:.   .:+oooooooo/  -ooooooooooo/`        ");
                Thread.Sleep(20);
                Console.WriteLine("       -oooooooooooooooooooooooooo+/:`    .:+oooooo   ooooooooooooo-       ");
                Thread.Sleep(20);
                Console.WriteLine("      :ooooooooooooooooo++//:--.```         `.:+ooo-  /ooooooooooooo/      ");
                Thread.Sleep(20);
                Console.WriteLine("     /oooooooo++//:--.```                      `./++  .ooooooooooooo+`     ");
                Thread.Sleep(20);
                Console.WriteLine("    :+//:--.```    ``..                           `.   +ooooooooooo/`      ");
                Thread.Sleep(20);
                Console.WriteLine("    `    ``..--:/+++++.                                -ooooooooo+-  `/:   ");
                Thread.Sleep(20);
                Console.WriteLine("  `-::/++++ooooooooo/`                                 `oooooooo+.  -+oo.  ");
                Thread.Sleep(20);
                Console.WriteLine("  /oooooooooooooooo:                                    /oooooo/` `:oooo+  ");
                Thread.Sleep(20);
                Console.WriteLine(" `ooooooooooooooo+.                                     -ooooo-  .+oooooo. ");
                Thread.Sleep(20);
                Console.WriteLine(" -oooooooooooooo/`                                       ooo+.  -+ooooooo: ");
                Thread.Sleep(20);
                Console.WriteLine(" /ooooooooooooo:                                         /o:` `:ooooooooo+ ");
                Thread.Sleep(20);
                Console.WriteLine(" /ooooooooooo+-  `                                       .-  `+ooooooooooo ");
                Thread.Sleep(20);
                Console.WriteLine(" /oooooooooo+`  -/                                          -+oooooooooooo ");
                Thread.Sleep(20);
                Console.WriteLine(" /ooooooooo:` `/oo`                                       `:ooooooooooooo+ ");
                Thread.Sleep(20);
                Console.WriteLine(" -ooooooo+-  .+ooo:                                      `+oooooooooooooo: ");
                Thread.Sleep(20);
                Console.WriteLine(" `oooooo+.  -ooooo+                                     -+ooooooooooooooo. ");
                Thread.Sleep(20);
                Console.WriteLine("  /oooo/` `/ooooooo.                                  `:oooooooooooooooo+  ");
                Thread.Sleep(20);
                Console.WriteLine("  `ooo-  .+oooooooo:                                 `+oooooooo++++//:--`  ");
                Thread.Sleep(20);
                Console.WriteLine("   -+.  -+oooooooooo                                .++++//:-..```   ``    ");
                Thread.Sleep(20);
                Console.WriteLine("    `  :oooooooooooo.  -.`                          .``    ```..-://++:    ");
                Thread.Sleep(20);
                Console.WriteLine("      /ooooooooooooo/  .o+:.                     ```.--://++ooooooooo/     ");
                Thread.Sleep(20);
                Console.WriteLine("      :oooooooooooooo`  oooo+:`        ```.--://++oooooooooooooooooo:      ");
                Thread.Sleep(20);
                Console.WriteLine("       .+oooooooooooo-  /oooooo+:`   `:+oooooooooooooooooooooooooo+-       ");
                Thread.Sleep(20);
                Console.WriteLine("        `/ooooooooooo+  .ooooooooo+:`  `-/ooooooooooooooooooooooo/`        ");
                Thread.Sleep(20);
                Console.WriteLine("          .+oooooooooo`  +ooooooooooo/-`  `-/oooooooooooooooooo+-          ");
                Thread.Sleep(20);
                Console.WriteLine("            ./oooooooo-  :oooooooooooooo/-`  `-+ooooooooooooo+-            ");
                Thread.Sleep(20);
                Console.WriteLine("              .:+ooooo+  `ooooooooooooooooo/-`  `-+oooooooo/.              ");
                Thread.Sleep(20);
                Console.WriteLine("                 ./+ooo`  +ooooooooooooooooooo/-   `:+o+/-`                ");
                Thread.Sleep(20);
                Console.WriteLine("                    .-/:  -oooooooooooooooooooooo/.   `                    ");
            }
            else
            {
                Console.Write(@"                              ``.---------..`                              
                        `-:/+ooooooooooooooooo+/.                          
                   `.`   -/ooooooooooooooooooooo+  `/:.`                   
                `-/ooo/.   `-/ooooooooooooooooooo`  +ooo/-`                
              ./oooooooo+:.   `-/oooooooooooooooo:  -oooooo/.              
            -+ooooooooooooo+:.   `:+ooooooooooooo+  `oooooooo+-`           
          -+oooooooooooooooooo+:.   `:+ooooooooooo.  /ooooooooo+-          
        `/ooooooooooooooooooooooo+:.   .:+oooooooo/  -ooooooooooo/`        
       -oooooooooooooooooooooooooo+/:`    .:+oooooo   ooooooooooooo-       
      :ooooooooooooooooo++//:--.```         `.:+ooo-  /ooooooooooooo/      
     /oooooooo++//:--.```                      `./++  .ooooooooooooo+`     
    :+//:--.```    ``..                           `.   +ooooooooooo/`      
    `    ``..--:/+++++.                                -ooooooooo+-  `/:   
  `-::/++++ooooooooo/`                                 `oooooooo+.  -+oo.  
  /oooooooooooooooo:                                    /oooooo/` `:oooo+  
 `ooooooooooooooo+.                                     -ooooo-  .+oooooo. 
 -oooooooooooooo/`                                       ooo+.  -+ooooooo: 
 /ooooooooooooo:                                         /o:` `:ooooooooo+ 
 /ooooooooooo+-  `                                       .-  `+ooooooooooo 
 /oooooooooo+`  -/                                          -+oooooooooooo 
 /ooooooooo:` `/oo`                                       `:ooooooooooooo+ 
 -ooooooo+-  .+ooo:                                      `+oooooooooooooo: 
 `oooooo+.  -ooooo+                                     -+ooooooooooooooo. 
  /oooo/` `/ooooooo.                                  `:oooooooooooooooo+  
  `ooo-  .+oooooooo:                                 `+oooooooo++++//:--`  
   -+.  -+oooooooooo                                .++++//:-..```   ``    
    `  :oooooooooooo.  -.`                          .``    ```..-://++:    
      /ooooooooooooo/  .o+:.                     ```.--://++ooooooooo/     
      :oooooooooooooo`  oooo+:`        ```.--://++oooooooooooooooooo:      
       .+oooooooooooo-  /oooooo+:`   `:+oooooooooooooooooooooooooo+-       
        `/ooooooooooo+  .ooooooooo+:`  `-/ooooooooooooooooooooooo/`        
          .+oooooooooo`  +ooooooooooo/-`  `-/oooooooooooooooooo+-          
            ./oooooooo-  :oooooooooooooo/-`  `-+ooooooooooooo+-            
              .:+ooooo+  `ooooooooooooooooo/-`  `-+oooooooo/.              
                 ./+ooo`  +ooooooooooooooooooo/-   `:+o+/-`                
                    .-/:  -oooooooooooooooooooooo/.   `                    
                          `/+ooooooooooooooooo+/:-`                        
                               `..-------..`                               ");
            }
        }
#endregion

        public static void SetUpFileSystem()
        {
            checkDir("C:\\GLaDOS_SHELL");
            checkDir("C:\\GLaDOS_SHELL\\Maintenance");
            checkDir("C:\\GLaDOS_SHELL\\Logs");
            checkDir("C:\\GLaDOS_SHELL\\Security");
            checkDir("C:\\GLaDOS_SHELL\\Security\\Turrets");

            checkDir("C:\\GLaDOS_SHELL\\Logs\\Chell");
            makeFile("C:\\GLaDOS_SHELL\\Maintenance\\reloadTurrets.bat", "");
            makeFile("C:\\GLaDOS_SHELL\\Maintenance\\polishTurrets.bat", "");
            makeFile("C:\\GLaDOS_SHELL\\Maintenance\\resetTurrets.bat", "");
            makeFile("C:\\GLaDOS_SHELL\\Security\\addTurret.sh", "");
            for (int i = 0; i < 51; i++)
            {
                makeFile("C:\\GLaDOS_SHELL\\Security\\Turrets\\Turret ["+i.ToString()+"].dat", "");
            }

        }
        static void checkDir(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
        static bool checkFile(string file)
        {
            if (File.Exists(file))
                return true;
            else
                return false;
        }
        static void makeFile(string filename, string text)
        {
            if (!checkFile(filename))
            {
                StreamWriter file = new StreamWriter(filename);
                file.Write(text);
                file.Close();
            }
        }
        public static void appShortcut(string linkName, string Location, string Icon, string whereToSave)
        {
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            using (StreamWriter writer = new StreamWriter(whereToSave + "\\" + linkName + ".url"))
            {
                string app = System.Reflection.Assembly.GetExecutingAssembly().Location;
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + Location);
                //writer.WriteLine("IconIndex=1");
                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
                writer.Flush();
                writer.Close();
            }
        }

      

        public static void ascienceWrite()
        {
            string strdone = "";
            Console.Clear();
            bool done = false;
            string text = "";
            Console.Clear();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("WRITE (v1.0)\n(c) 1982 Aperture Science\n");
            Console.WriteLine("WRITE [1.0.0.0] \n(c) Aperature Science\nUse \'`\' to save and exit");
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write("=");

            //begin
            bool done_write = false;
            string str = "";
            while (!done_write)
            {
                try
                {
                    Console.Write(str);
                    ConsoleKey ck = Console.ReadKey(true).Key;
                    if (ck == ConsoleKey.Enter)
                        str += "\n";
                    else if (ck == ConsoleKey.Backspace)
                        str = str.Substring(0, str.Length - 1);
                    else if (ck == ConsoleKey.Spacebar)
                        str += " ";
                    else if (ck == ConsoleKey.D0)
                        str += "0";
                    else if (ck == ConsoleKey.D1)
                        str += "1";
                    else if (ck == ConsoleKey.D2)
                        str += "2";
                    else if (ck == ConsoleKey.D3)
                        str += "3";
                    else if (ck == ConsoleKey.D4)
                        str += "4";
                    else if (ck == ConsoleKey.D5)
                        str += "5";
                    else if (ck == ConsoleKey.D6)
                        str += "6";
                    else if (ck == ConsoleKey.D7)
                        str += "0";
                    else if (ck == ConsoleKey.D8)
                        str += "0";
                    else if (ck == ConsoleKey.D9)
                        str += "0";
                    else if (ck == ConsoleKey.NumPad0)
                        str += "0";
                    else if (ck == ConsoleKey.NumPad1)
                        str += "1";
                    else if (ck == ConsoleKey.NumPad2)
                        str += "2";
                    else if (ck == ConsoleKey.NumPad3)
                        str += "3";
                    else if (ck == ConsoleKey.NumPad4)
                        str += "4";
                    else if (ck == ConsoleKey.NumPad5)
                        str += "5";
                    else if (ck == ConsoleKey.NumPad6)
                        str += "6";
                    else if (ck == ConsoleKey.NumPad7)
                        str += "7";
                    else if (ck == ConsoleKey.NumPad8)
                        str += "8";
                    else if (ck == ConsoleKey.NumPad9)
                        str += "9";
                    else if (ck == ConsoleKey.Oem3 /* ` */)
                        done_write = true;
                    else
                        str += ck.ToString();
                    Console.Clear();
                    Console.WriteLine("WRITE [1.0.0.0] \n(c) Aperature Science");
                    for (int i = 0; i < Console.WindowWidth; i++)
                        Console.Write("=");
                }
                catch { }
            }
            Console.Clear();
            Console.Write("FileName> ");
            strdone = str;
            StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + Console.ReadLine());
            sw.Write(strdone);
            sw.Close();
        }

    }
}
