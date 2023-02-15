// See https://aka.ms/new-console-template for more information
using LiteDbConsole;
using System.Security.Principal;

Console.WriteLine("Hello, World!");
string str = Environment.MachineName;
string sid = WindowsIdentity.GetCurrent().User.Value;
Console.WriteLine(str);
Console.WriteLine(sid);

LiteContext LiteContext = new LiteContext(str,sid);

Console.WriteLine(LiteContext.GetConnectionString());
