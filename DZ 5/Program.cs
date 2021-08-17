using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DZ 5{

    class Class1
{
    string login = "";
    string pasword = "";
    public void CheckInputDataNotReg()
    {
        bool chekEnter = false;
        do
        {
            Console.WriteLine("Введите логин:");
            string tmpLogin = Console.ReadLine();

            if (tmpLogin.Length < 2) Console.WriteLine("Логин слишком короткий!");
            else
            {
                if (tmpLogin.Length > 10) Console.WriteLine("Логин слишком длинный!");
                else
                {
                    foreach (char ch in tmpLogin)
                    {
                        if (
                            (ch < '0') ||
                            (ch > '9' && ch < 'A') ||
                            (ch > 'Z' && ch < 'a') ||
                            (ch > 'z')
                          )
                        {
                            Console.WriteLine("Не верный символ в логине, разрешены только латинские символы и цифры.");
                            break;
                        }
                        else
                        {
                            if (tmpLogin[0] < 'A')
                            {
                                Console.WriteLine("Первым символом должна быть буква.");
                                break;
                            }
                            else
                            {
                                login = tmpLogin;
                                chekEnter = true;

                            }
                        }
                    }
                }
            }
        }
        while (!chekEnter);
        Console.WriteLine("Введите пароль:");
        pasword = Console.ReadLine();
        Console.WriteLine("Логин: " + login + ", Пароль: " + pasword);
        Console.ReadLine();
    }

    public void CheckInputDataReg()
    {
        login = "";
        Console.WriteLine("Введите логин:");
        bool chekEnter = false;
        do
        {
            string tmpLogin = Console.ReadLine();
            if (tmpLogin.Length < 2) Console.WriteLine("Логин слишком короткий!");
            else
            {
                if (tmpLogin.Length > 10) Console.WriteLine("Логин слишком длинный!");
                else
                {
                    Regex regexStart = new Regex(@"\b[0-9]");
                    if (regexStart.IsMatch(tmpLogin))
                    {
                        Console.WriteLine("Первым символом должна быть буква.");
                    }
                    else
                    {
                        Regex regex = new Regex(@"[0-9A-Za-z]");
                        if (!regex.IsMatch(tmpLogin))
                        {
                            Console.WriteLine("Символы не соответствуют.");
                        }
                        else
                        {
                            login = tmpLogin;
                            chekEnter = true;
                        }
                    }
                }
            }
        }
        while (!chekEnter);
        Console.WriteLine("Введите пароль:");
        pasword = Console.ReadLine();
        Console.WriteLine("Логин: " + login + ", Пароль: " + pasword);
        Console.ReadLine();
    } 
}
}
