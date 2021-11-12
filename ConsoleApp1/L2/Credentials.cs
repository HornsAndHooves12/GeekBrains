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
internal class GoodNumber
{
    private byte[] _digits;
    public int Number { get; private set; }
    private int _sum;

    public GoodNumber(int digitsCount)
    {
        _digits = new byte[digitsCount];
    }

    public void Increment()
    {
        Number++;
        for (int i = 0; i < _digits.Length; i++)
        {
            _digits[i]++;
            if (_digits[i] < 10)
            {
                _sum++;
                break;
            }
            _digits[i] = 0;
            _sum -= 9;
        }
    }

    public bool IsGood()
    {
        return Number % _sum == 0;
    }
}