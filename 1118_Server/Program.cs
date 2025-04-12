using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _1118_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri wsdl_uri = new Uri(ConfigurationManager.AppSettings["wsdl_uri"]);

            ServiceHost host = new ServiceHost(typeof(MemberService));

            //오픈
            MemberService memberService = new MemberService();
            if(memberService.DBopen() == true)
            {
                Console.WriteLine("DB에 연결되었습니다.");
            }
            host.Open();
            Console.WriteLine("서비스를 시작합니다.");
            Console.WriteLine($"WSDL_URI    : {wsdl_uri}");
            Console.WriteLine("멈추시려면 엔터를 눌러주세요..");
            Console.ReadLine();
            //서비스'
            memberService.DBclose();
            host.Abort();
            host.Close();
        }
    }
}
