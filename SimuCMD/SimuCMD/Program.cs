using Aras.IOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            string ServerName = string.Empty;
            string DBName = string.Empty;
            string UserName = string.Empty;
            string PWD = string.Empty;
            ConsoleKeyInfo cki;
            Console.WriteLine("Simu 科技[版本  1.0.0.1]");
            Console.WriteLine("(C) 2016 Simu 保留所有的权利");
            Console.WriteLine();
            Console.WriteLine();
            RD: Console.Write("Simu >");
            string cmd=Console.ReadLine();
            switch(cmd)
            {
                case "-login":
                    if(flag)
                    {
                        Console.WriteLine("已经登陆");
                        break;
                    }
                    Console.Write("服务器地址 >");
                    ServerName = Console.ReadLine();
                    Console.Write("数据库名称 >");
                    DBName = Console.ReadLine();
                    Console.Write("用户名 >");
                    UserName = Console.ReadLine();
                    Console.Write("密码 >");
                    do
                    {
                        cki = Console.ReadKey(true);
                        if (cki.Key != ConsoleKey.Enter)
                        {
                            Console.Write("*");
                            PWD += cki.KeyChar.ToString();
                        }
                    } while (cki.Key != ConsoleKey.Enter);
                    HttpServerConnection connection = IomFactory.CreateHttpServerConnection(ServerName, DBName, UserName, Innovator.ScalcMD5(PWD));
                    Item loginResult = connection.Login();
                    if (loginResult.isError())
                    {
                        Console.WriteLine("登陆失败");
                    }
                    else
                    {
                        flag = true;                                                  //登陆成功
                        Console.WriteLine();
                        Console.WriteLine("登陆成功");
                    }
                    break;
                case "-licence":
                    if (flag)
                    {
                        Console.WriteLine("编号   模块名称    编码	   功能	           授权方式        数量（支持注册用户数）");
                        Console.WriteLine("1      项目管理    CPM    项目管理          网络授权                  200");
                        Console.WriteLine("                  CCM    沟通管理           网络授权                  200");
                        Console.WriteLine("2      设计管理    DCM    设计协同	     网络授权                  200");
                        Console.WriteLine("                  CCN    工程变更管理       网络授权                  200");
                        Console.WriteLine("                  CAN    自动编码           网络授权                  200");
                        Console.WriteLine("3      文档管理    CDM    文档管理	    网络授权                  200");
                        Console.WriteLine("                  AX     3D ActiveX        网络授权                  200");
                        Console.WriteLine("                  REV    ForRevit           网络授权                  30");
                        Console.WriteLine("                  EDI    3D Editor          网络授权                  30");
                        Console.WriteLine("                  PTM    构件管理           网络授权                 200");
                        Console.WriteLine("                  IFVM   VMWare 接口        网络授权                  200");
                        Console.WriteLine("                  BSP    系统基础服务       网络授权                    1");
                        Console.WriteLine("                  IFI    IOS移动端接口      网络授权                  200");
                        Console.WriteLine("                  IFA    安卓移动端接口     网络授权                  200");
                        Console.WriteLine("结束");
                    }
                    else
                    {
                        Console.WriteLine("未登录");
                        break;
                    }
                    break;
                case "exit":
                    Environment.Exit(0);                                     //退出
                    break;
                default:Console.WriteLine("你输入的命令无法识别");break;
            }
            goto RD;
        }
    }
}
