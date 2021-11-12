using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.L2;

internal class Credentials
{
    public Credentials(string login, string password)
    {
        this.login = login; 
        this.password = password;   
    }
    private string login;
    private string password;

    public bool IsValid { get => login == "root" && password == "GeekBrains"; }

}
