using Newtonsoft.Json;
using System.Text;

namespace MinecraftAccountsManager;
public static class Wrapper
{
    public static MainWindow MainWindow { get; set; }
    public static string Root = @"C:\DooD.Inc\MinecraftAccountsManager";
    public static MinecraftBootManager BootManager = new MinecraftBootManager("C:/Program Files/Java/jre1.8.0_311/bin/java.exe", 512, 4096, 640, 482);
    public static List<Account> Accounts = new List<Account>();
    static Wrapper()
    {
        new List<string> { @"C:\DooD.Inc\", @"C:\DooD.Inc\MinecraftAccountsManager" }.Where(z => !Directory.Exists(z)).ToList().ForEach(z => Directory.CreateDirectory(z));
    }
    public static void SaveAccounts()
    {
        File.WriteAllText(Path.Combine(Root, "accounts.json"), JsonConvert.SerializeObject(Accounts, new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented
        }));
    }
    public static void LoadAccounts()
    {
        string accountsFile = Path.Combine(Root, "accounts.json");
        if(File.Exists(accountsFile))
            Accounts = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(accountsFile));
    }
    public static string TimeSpanToString(TimeSpan span) =>
    ((span.Days > 0 ? span.Days % 365 + "d " : "") +
    (span.Hours > 0 ? span.Hours + "h " : "") +
    (span.Minutes > 0 ? span.Minutes + "m" : "1m"/*WHY 1???? NO QUESTIONS, STFU AND WRITE CODE ON PYTHON*/)).Trim();
    public static string ReadStream(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        return Encoding.UTF8.GetString(buffer);
    }
}