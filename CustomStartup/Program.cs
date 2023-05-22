using CustomStartup.Classes;
using CustomStartup.Resources;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace CustomStartup {
    internal class Program {
        static void Main(string[] args) {
            try {
                string jsonFile = $@"{Directory.GetCurrentDirectory()}\programs.json";

                if (!File.Exists(jsonFile)) {
                    Notification.SendNotification(
                        "Arquivo com de configuração dos programas não localizado",
                        "Verifique se o arquivo: \"programs.json\" encontra-se na pasta: " + Directory.GetCurrentDirectory()
                    );
                    return;
                }

                string programsFile = File.ReadAllText(jsonFile);

                Programs programs = JsonConvert.DeserializeObject<Programs>(programsFile);

                foreach (string processesToClose in programs.Close) {
                    try {
                        foreach (Process process in Process.GetProcessesByName(processesToClose))
                            process.Kill();
                    }
                    catch (Exception e) {
                        Notification.SendNotification($"Não foi possível encerrar o precesso: {processesToClose}", e.Message);
                    }
                }

                foreach (string processesToStart in programs.Start) {
                    try {
                        Process.Start(processesToStart);
                    }
                    catch (Exception e) {
                        Notification.SendNotification($"Não foi possível inicializar: {processesToStart}", e.Message);
                    }
                }

                Notification.SendNotification($"Inicialização concluida", "😀");
            }
            catch {
                Notification.SendNotification($"Não foi realizar a inicialização", "Certifique-se que o arquivo de configuração dos programas esta correto");
            }
        }
    }
}
