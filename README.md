A program with which you can manage the launch / shutdown / status of accounts on 2b2t.

![image](https://user-images.githubusercontent.com/55879406/185969712-448335ed-0b5b-49b0-9750-cd2731f2c4d4.png)

Only Windows, .Net 6.0. WinForms.

For building(publishing): 
```
cd your_project_path
dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained false
```
Example of publishing:
```
cd C:\Users\u\source\repos\MinecraftAccountsManager
dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained false
```
