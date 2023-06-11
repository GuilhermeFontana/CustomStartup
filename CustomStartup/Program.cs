using CustomStartup.Classes;
using CustomStartup.Resources;
using Microsoft.WindowsAPICodePack.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CustomStartup {
    internal class Program {
        static void Main(string[] args) {
            try {
                string jsonFile = $@"{Directory.GetCurrentDirectory()}\programs.json";

                if(!File.Exists(jsonFile)) {
                    Notification.SendNotification(
                        "Arquivo com de configuração dos programas não localizado",
                        "Verifique se o arquivo: \"programs.json\" encontra-se na pasta: " + Directory.GetCurrentDirectory()
                    );
                    return;
                }

                string programsFile = File.ReadAllText(jsonFile);


                string networkName = string.Empty;
                NetworkCollection networks = NetworkListManager.GetNetworks(NetworkConnectivityLevels.Connected);
                foreach(Network network in networks) {
                    networkName = network.Name;
                }

                List<Config> configs = JsonConvert.DeserializeObject<Configurations>(programsFile).Configs.Where(x => (x.Network.ToLower() == networkName.ToLower() || x.RunAlways)).ToList();

                if(configs.Count == 0) {
                    Notification.SendNotification(
                        "Nenhuma configuração não encontrada",
                        $"Verifique se há configuração correspondente à sua rede atual (Network: {networkName}) " +
                        $"ou marcado para executar sempre (RunAlways: true)"
                    );
                    return;
                }

                foreach(Config config in configs) {
                    foreach(string processesToClose in config.Close) {
                        try {
                            foreach(Process process in Process.GetProcessesByName(processesToClose))
                                process.Kill();
                        }
                        catch(Exception e) {
                            Notification.SendNotification($"Não foi possível encerrar o precesso: {processesToClose}", e.Message);
                        }
                    }

                    foreach(string processesToStart in config.Start) {
                        try {
                            Process.Start(processesToStart);
                        }
                        catch(Exception e) {
                            Notification.SendNotification($"Não foi possível inicializar: {processesToStart}", e.Message);
                        }
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
