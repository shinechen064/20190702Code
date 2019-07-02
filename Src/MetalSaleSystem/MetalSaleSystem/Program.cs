using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalSaleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // 输入参数不合法
            if (null == args || args.Length <= 1)
            {
                Console.WriteLine("please key something like:MetalSaleSystem.exe sample_command.json order_receipt.txt");
                return;
            }
            string strInputFile = args[0];
            string strOutputFile = args[1];
            if (!File.Exists(strInputFile))
            {
                Console.WriteLine("input file {0} is not exist!", strInputFile);
                return;
            }

        }
        public bool UnpackJsonData(string argFile)
        {
            if(!File.Exists(argFile))
            {
                Console.WriteLine("input file {0} is not exist!", argFile);
                return false;
            }
            return false;
        }
    }

}
