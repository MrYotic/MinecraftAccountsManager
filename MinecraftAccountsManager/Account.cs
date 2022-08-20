using System.Net;
using System.Text;
using static MinecraftAccountsManager.Minecraft;

namespace MinecraftAccountsManager;
public class Account
{
    public Account(string name, string email, string password, string uuid, string accessToken)
    {
        Name = name;
        Email = email;
        Password = password;
        UUID = uuid;
        AccessToken = accessToken;
        new Thread(() => SkinHead = MojangAPI.GetSkinHead(uuid)).Start();
        Minecraft = Wrapper.BootManager.NewMinecraft(this);
        Panel = new AccountPanel(this);
    }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UUID { get; set; }
    public string AccessToken { get; set; }
    [NonSerialized] public Minecraft Minecraft;
    [NonSerialized] public Image SkinHead;
    [NonSerialized] public AccountPanel Panel;
    [NonSerialized] public MinecraftState State = MinecraftState.NotLaunched;
    [NonSerialized] public int queuePos = -1;
    [NonSerialized] public DateTime? joinToServer;
    [NonSerialized] public DateTime? joinToQueue;
    [NonSerialized] public Thread JavaInputThread;
}
public static class MojangAPI
{
    public static Image GetSkin(string uuid)
    {
        try 
        {
            return Image.FromStream(new WebClient().OpenRead(Encoding.UTF8.GetString(Convert.FromBase64String(new WebClient().DownloadString($"https://sessionserver.mojang.com/session/minecraft/profile/{uuid}").Split('\"')[17])).Split('\"')[17]));
        } catch { }
        return new Bitmap(64, 64);
    }
    public static Image GetSkinHead(string uuid) => ((Bitmap)GetSkin(uuid)).Clone(new Rectangle(8, 8, 8, 8), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    public static string GetUUID(string name) => new WebClient().DownloadString($"https://api.mojang.com/users/profiles/minecraft/{name}").Split('\"')[7];
    public static string PrepairAccessToken(string raw) => raw.Contains("%22") ? raw.Split("accessToken%22:%22")[1].Split("%22%2C%22clientToken")[0] : raw;
}