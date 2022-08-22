using System.Diagnostics;
using System.Management;
using System.Text;

public sealed class Minecraft
{
    public Minecraft(string root, Account account, string bat)
    {
        Root = root;
        Account = account;
        BootBatText = bat;
        BootBatPath = Path.Combine(Root, "boot.bat");
        PrepairMinecraft();
    }
    public string Root;
    public Account Account;
    private string BootBatText;
    private string BootBatPath;
    private Process BootBatProcess;
    public void PrepairMinecraft()
    {
        Directory.CreateDirectory(Root);
        File.Create(BootBatPath).Write(Encoding.UTF8.GetBytes(BootBatText).AsSpan());
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
    }
    public bool ExistsMinecraftProcess => MinecraftProcess != null;
    public Process MinecraftProcess{ get {
            var processes = Process.GetProcesses().Where(z => z.ProcessName == "java").Where(z => GetProcessUsername(z).Equals(Account.Name)).ToArray();
            if (processes.Count() == 0)
                return null;
            return processes[0];
        }
    }
    public static string GetProcessUsername(Process process)
    {
        if (!Wrapper.Processes.ContainsKey(process.Id))
        {
            string username = "undefined";
            try
            {
                using var moc = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id).Get();
                string? text = (from mo in moc.Cast<ManagementObject>() select mo["CommandLine"]).FirstOrDefault().ToString();
                if (text != null && text.Contains("username"))
                    username = text.Split("username")[1].Split('-')[0].Split(' ')[1];
            }
            catch { }
            Wrapper.Processes[process.Id] = username;
        }
        return Wrapper.Processes[process.Id];
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