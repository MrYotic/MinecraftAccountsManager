using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftAccountsManager;
public class Minecraft
{
    public Minecraft(string root, Account account, string bat)
    {
        Root = root;
        Account = account;
        BootBatText = bat;
        PrepairMinecraft();
    }
    public string Root;
    public Account Account;
    private string BootBatText;
    private string BootBatPath;
    public Process BootBatProcess;
    public Process MinecraftProcess;
    public ChatManager ChatManager;
    public void PrepairMinecraft()
    {
        if (!Directory.Exists(Root))
            Directory.CreateDirectory(Root);
        BootBatPath = Path.Combine(Root, "boot.bat");
        if (File.Exists(BootBatPath))
            File.Delete(BootBatPath);
        File.Create(BootBatPath).Dispose();
        File.WriteAllText(BootBatPath, BootBatText);
    }
    public void Start()
    {
        var processInfo = new ProcessStartInfo("cmd.exe", "/c" + $"\"{BootBatPath}\"")
        {
            WorkingDirectory = Root,
            CreateNoWindow = true,
        };
        BootBatProcess = Process.Start(processInfo);
        new Thread(() =>
        {
            int maxAttempt = 1000;
            int attempt = 0;
            while (!(Account.State != MinecraftState.NotLaunched && Account.State != MinecraftState.Launched))
            {
                Thread.Sleep(100);
                if (attempt > maxAttempt)
                    return;
                attempt++;
            }
            ChatManager = new ChatManager(Path.Combine(Root, "logs", "latest.log"));
            ChatManager.OnChatReceive += Account.Panel.OnChatReceive;
        }).Start();
    }
    public void Close()
    {
        ChatManager.OnChatReceive -= Account.Panel.OnChatReceive;
        ChatManager.Dispose();
        BootBatProcess.Kill();
        MinecraftProcess?.Kill();
        BootBatProcess = MinecraftProcess = null;
    }
    public static Dictionary<MinecraftState, string> MinecraftStringStates = new Dictionary<MinecraftState, string>()
    {
        { MinecraftState.NotLaunched, "Not Launched" },
        { MinecraftState.Launched, "Launched" },
        { MinecraftState.InGame, "In Game" },
        { MinecraftState.InQueue, "In Queue: " },
        { MinecraftState.On2B2T, "On 2B2T: " },
        { MinecraftState.Unknown, "Unknown" }
    };
    public enum MinecraftState
    {
        NotLaunched,
        Launched,
        InGame,
        InQueue,
        On2B2T,
        Unknown,
    }
}