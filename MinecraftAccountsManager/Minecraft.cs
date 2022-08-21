using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
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
    private Process BootBatProcess;
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
        File.WriteAllText(Path.Combine(Root, "state.txt"), "Launched");
        var processInfo = new ProcessStartInfo("cmd.exe", "/c" + $"\"{BootBatPath}\"")
        {
            WorkingDirectory = Root,
            CreateNoWindow = true,
        };
        BootBatProcess = Process.Start(processInfo);
    }
    public void Close()
    {
        BootBatProcess?.Kill();
        MinecraftProcess?.Kill();
        BootBatProcess = null;
    }
    public bool ExistsMinecraftProcess => Process.GetProcesses().Where(z => z.ProcessName == "java").Where(z => GetProcessUsername(z).Equals(Account.Name)).Count() != 0;
    public Process MinecraftProcess => Process.GetProcesses().Where(z => z.ProcessName == "java").Where(z => GetProcessUsername(z).Equals(Account.Name)).FirstOrDefault();
    public static string GetProcessUsername(Process process)
    {
        try
        {
            using (ManagementObjectCollection moc = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id).Get())
            {
                string text = (from mo in moc.Cast<ManagementObject>() select mo["CommandLine"]).First().ToString();
                if (text.Contains("username"))
                    return text.Split("username")[1].Split('-')[0].Split(' ')[1];
            }
        }
        catch { }
        return "Undefind";
    }
    public static Dictionary<int, string> Dimensions = new Dictionary<int, string>()
    {
        { -1, "Nether" },
        { 0, "Overworld" },
        { 1, "End" }
    };
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