using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;

namespace ConsoleOS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StartupSequence();
            ProgramSwitcher();
        }

        private static void StartupSequence()
        {
            // Simulating the BIOS/UEFI initialization
            Console.WriteLine("Initializing hardware...");
            System.Threading.Thread.Sleep(1500);

            // Simulating the Bootloader
            Console.WriteLine("Loading ConsoleOS...");
            System.Threading.Thread.Sleep(1500);

            // Simulating Kernel Initialization
            Console.WriteLine("Starting kernel...");
            System.Threading.Thread.Sleep(500);

            // Create loading bar here
            Console.Write("Loading: ");
            for (int i = 0; i <= 100; i++)
            {
                Console.Write(i + "%");
                System.Threading.Thread.Sleep(30);
                // clear that line
                Console.SetCursorPosition(8, Console.CursorTop);
                Console.Write(" ");
            }

            Console.WriteLine("ConsoleOS version 0.0.1 (gcc version 9.3.0) #1 SMP ConsoleOS 2024");

            Console.WriteLine("Starting system services...");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("WELCOME TO ConsoleOS");
        }

        private static void ProgramSwitcher()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("Please select a program to run:");
            Console.WriteLine("1. File Explorer");
            Console.WriteLine("2. Security Analysis");
            Console.WriteLine("3. Benchmarker");
            Console.WriteLine("4. Firestorm (Emergency Protocol)");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    FileExplorer();
                    break;
                case 2:
                    SecurityAnalysis();
                    break;
                case 3:
                    Benchmarker();
                    break;
                case 4:
                    Firestorm();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    ProgramSwitcher();
                    break;
            }
        }

        private static void FileExplorer()
        {       
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========== FILE EXPLORER ==========");
            Console.ResetColor();

            string currentDirectory = Directory.GetCurrentDirectory(); // Start in the current working directory

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Current Directory: {currentDirectory}");
                Console.WriteLine("[INFO] Use '..' to go up a level or type a folder/file name to navigate.");
                Console.WriteLine(" ");
                Console.ResetColor();

                // Display files and directories in the current directory
                string[] directories = Directory.GetDirectories(currentDirectory);
                string[] files = Directory.GetFiles(currentDirectory);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Directories:");
                foreach (var dir in directories)
                {
                    Console.WriteLine($"[DIR] {Path.GetFileName(dir)}");
                }

                Console.WriteLine("\nFiles:");
                foreach (var file in files)
                {
                    Console.WriteLine($"[FILE] {Path.GetFileName(file)}");
                }
                Console.ResetColor();

                // Prompt for user input
                Console.WriteLine("Enter folder/file name to navigate or 'exit' to return to the main menu.");
                string userInput = Console.ReadLine();

                // Exit condition
                if (userInput.ToLower() == "exit")
                {
                    break;
                }

                // Navigate to a directory
                if (Directory.Exists(Path.Combine(currentDirectory, userInput)))
                {
                    currentDirectory = Path.Combine(currentDirectory, userInput);
                }
                // Open a file and display its contents
                else if (File.Exists(Path.Combine(currentDirectory, userInput)))
                {
                    string filePath = Path.Combine(currentDirectory, userInput);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Opening file: {filePath}\n");

                    // Display file contents
                    try
                    {
                        string fileContent = File.ReadAllText(filePath);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(fileContent);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error opening file: {ex.Message}");
                    }
                    Console.ResetColor();
                }
                // Go up one directory level
                else if (userInput == "..")
                {
                    currentDirectory = Directory.GetParent(currentDirectory)?.FullName ?? currentDirectory;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid directory or file name.");
                    Console.ResetColor();
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            ProgramSwitcher(); // Return to the program selection menu
        }


        private static void SecurityAnalysis()
        {
            Console.WriteLine("Security Analysis is not implemented yet.");
        }

        private static void Benchmarker()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========== SYSTEM BENCHMARKER ==========");
            Console.WriteLine("Running system performance tests...");
            Console.ResetColor();

            // Simulate CPU Benchmark (in yellow)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[TEST] Running CPU stress test...");
            Console.ResetColor();
            System.Threading.Thread.Sleep(500); // Simulate short delay
            DateTime startTime = DateTime.Now;

            // Simulate a CPU load (just a loop that runs for a bit)
            for (int i = 0; i < 10000000; i++)
            {
                // Simple computation (looping to simulate load)
                Math.Sqrt(i);
                Math.Pow(i, 2);
                Math.Log(i);
                Math.Sin(i);
                Math.Cos(i);
                Math.Tan(i);
                Math.Asin(i);
                Math.Acos(i);
                Math.Atan(i);
                Math.Cosh(i);
                Math.Sinh(i);
                Math.Tanh(i);
                Math.Exp(i);
                Math.Log10(i);
            }

            TimeSpan cpuTestDuration = DateTime.Now - startTime;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[RESULT] CPU test completed in {cpuTestDuration.TotalSeconds:F2} seconds.");
            Console.ResetColor();

            // Simulate Memory Benchmark (in yellow)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[TEST] Running memory test...");
            Console.ResetColor();
            startTime = DateTime.Now;

            // Simulating a large memory allocation
            int[] largeArray = new int[100000000]; // Adjust size for more stress
            for (int i = 0; i < largeArray.Length; i++)
            {
                largeArray[i] = i;
            }

            TimeSpan memoryTestDuration = DateTime.Now - startTime;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[RESULT] Memory test completed in {memoryTestDuration.TotalSeconds:F2} seconds.");
            Console.ResetColor();

            // Simulate Disk Benchmark (in yellow)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[TEST] Running disk write test...");
            Console.ResetColor();
            startTime = DateTime.Now;

            // Simulating writing to a temporary file (disk write test)
            string tempFilePath = Path.Combine(Path.GetTempPath(), "benchmark_test_file.tmp");
            
            Console.WriteLine($"[INFO] Writing test data to: {tempFilePath}");
            
            try
            {
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    for (int i = 0; i < 100000; i++) // Adjust loop for more stress
                    {
                        writer.WriteLine($"Test data line {i}");
                        
                        // Check if the file size exceeds 10GB
                        if (new FileInfo(tempFilePath).Length > 10000000000)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("File size exceeded 10GB. Exiting...");
                            Console.ResetColor();
                            return; // Exit method if the file is too large
                        }
                    }
                }

                TimeSpan diskWriteDuration = DateTime.Now - startTime;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[RESULT] Disk write test completed in {diskWriteDuration.TotalSeconds:F2} seconds.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred during the disk write test: {ex.Message}");
            }
            finally
            {
                // Clean up the temp file if it was created
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }

            Console.ResetColor();

            // Summary of Benchmark
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n========== BENCHMARKING COMPLETE ==========");
            Console.ResetColor();
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            
            ProgramSwitcher();
        }
        
        private static void Firestorm()
        {
            Console.Clear();

            // System Alert (in red)
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("========== SYSTEM ALERT: EMERGENCY PROTOCOL ACTIVATED ==========");
            Console.WriteLine("External attack vector detected. Initiating security analysis...");
            Console.ResetColor();

            System.Threading.Thread.Sleep(1000);

            // Simulate incoming attack logs (in yellow)
            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    $"[ALERT] Unauthorized access attempt detected from IP: 192.168.1.{new Random().Next(1, 255)}");
                Console.WriteLine($"[ALERT] Brute force attack detected on port {new Random().Next(20, 5000)}.");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
            }

            // System Integrity Check (in cyan)
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Analyzing system integrity...");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1500);

            // Simulate integrity checks (in red for issues)
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[CHECK] Firewall: COMPROMISED");
            Console.WriteLine("[CHECK] Kernel processes: UNSTABLE");
            Console.WriteLine("[CHECK] Data integrity: 76% CORRUPTED");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1500);

            // Countermeasures (in green)
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Attempting countermeasures...");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);

            // Simulate countermeasure actions (in yellow for failure)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[ACTION] Blocking IP range: 192.168.1.0/24");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("[ACTION] Restarting compromised services...");
            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ACTION FAILED] Unable to recover kernel processes. SYSTEM IS COMPROMISED.");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);

            // Lockdown (in magenta)
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Initiating system-wide lockdown...");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1500);

            // Display shutdown countdown (in blue)  
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine($"[SYSTEM] Shutdown in {i} seconds...");
                System.Threading.Thread.Sleep(1000);
            }

            Console.ResetColor();

            // Critical Error Message (in red)
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!! CRITICAL ERROR: SYSTEM FAILURE !!");
            Console.WriteLine("ConsoleOS will now shut down to protect data.");
            Console.ResetColor();
            System.Threading.Thread.Sleep(2000);

            // Forcefully exit
            Environment.Exit(-1);
        }
    }
}