namespace MinecraftAccountsManager;

public static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(Wrapper.MainWindow = new MainWindow());
    }
}