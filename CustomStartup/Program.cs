using CustomStartup.Classes;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;


namespace CustomStartup {
    internal class Program {
        static void Main(string[] args) {
            string jsonFile = $@"{Directory.GetCurrentDirectory()}\programs.json";

            if (!File.Exists(jsonFile))
                return;

            string programsFile = File.ReadAllText(jsonFile);

            Programs programs = JsonConvert.DeserializeObject<Programs>(programsFile);

            foreach (string processesToClose in programs.Close) {
                try {
                    foreach (Process process in Process.GetProcessesByName(processesToClose))
                        process.Kill();
                }
                catch { }
            }

            foreach (string processesToStart in programs.Start) {
                try {
                    Process.Start(processesToStart);
                }
                catch { }
            }
        }
    }
}
