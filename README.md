# **CustomStartup**

<h1 align="center">
    <img alt="Icon" title="DrinkWater" src="CustomStartup\Assets\Images\icon.ico" />
</h1>

## 💻 **_Projeto_**

O **CustomStartup** é uma aplicação desktop, desenvolvida com o objetivo de otimizar o tempo de inicialização do Windows do usuário, bem como uma melhora na performance do mesmo.

Por meio da redução de aplicações inicializadas diretamente pelo sistema operacional, que passam a ser abertas por este projeto. Assim como o encerramento de processos indesejados.

---

## 🔧 **_Packages_**

- .NETFramework 4.7
- Microsoft.Toolkit.Uwp.Notifications
- Newtonsoft.Json
- WindowsAPICodePack-Core

---

## ⚙ **_Configurações_**

No arquivo: _configs.json_, o usuário pode realizar as devidas configurações.

| Chave       | Tipo do Valor | Descrição                                         |
| ----------- | ------------- | ------------------------------------------------- |
| Description | string        | Descrição da configuração                         |
| Network     | string        | Nome da rede à qual a configuração se aplica      |
| Start       | List\<string> | Lista com os programas a serem inicializado       |
| Close       | List\<string> | Lista com o nome dos processos a serem encerrados |
| RunAlways   | boolean       | Define se esta configuração executa sempre        |

_Observações_:

1. O campo: Description é apenas informativo, não é utilizado para nada
2. Network: é case insensitivo
3. O campo Start pode conter:

   3.1 Links

   3.2 Pastas (caminho completo com barras duplas: "\\\\")

   3.3 Executáveis (caminho completo com barras duplas, nome e extensão do executável: "...\\\\prog.exe")

---

## 🚀 **_Futuras Implementações_**

1. Permitir o usuário utilizar a mesma configuração para mais de uma rede
