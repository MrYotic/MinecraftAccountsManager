using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftAccountsManager;
public class ChatManager
{
    public string LogPath { get; set; }
    public TimeSpan Delay { get; set; } = TimeSpan.FromMilliseconds(500);
    public ChatManager(string pathToLog)
    {
        LogPath = pathToLog;
        toggle = true;
        (updater = new Thread(Handler)).Start();
    }
    public delegate void ChatMessageHandler(string message);
    public event ChatMessageHandler? OnChatReceive;
    public Encoding Encoding = Encoding.UTF8;
    private Thread updater;
    private bool toggle = false;
    public void Handler()
    {
        using (FileStream sr = new FileStream(LogPath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
        {
            sr.Position = sr.Length;
            while (toggle)
            {
                try
                {
                    if (sr.Length > sr.Position)
                    {
                        int length = (int)(sr.Length - sr.Position);
                        byte[] buffer = new byte[length];
                        sr.Read(buffer, 0, length);
                        string[] lines = Encoding.GetString(buffer).Split('\n');
                        foreach (string line in lines)
                            OnChatReceive?.Invoke(line);
                    }
                }
                catch { }
                Thread.Sleep(Delay);
            }
            sr.Close();
        }
    }
    public void Dispose()
    {
        toggle = false;
        OnChatReceive = null;
    }
    ~ChatManager() => Dispose();
}