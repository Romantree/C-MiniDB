using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddrBook
{
    internal class Log // internal 뜻은 네임스페이스 안에 공유되는 클래스
                       //자바에 패키지랑 같은 뜻
    {
        public static void WriteLine(string name, string e)
        {
            string filename = @"c:\dotnet\" + name + ".txt";
            string logtime = DateTime.Now.ToString();

            FileStream aFile = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter aWriter = new StreamWriter(aFile, System.Text.Encoding.Default);

            aWriter.WriteLine("[" + logtime + "]");
            aWriter.WriteLine(e);
            aWriter.Flush();
            aWriter.Close();
        }

    }
}
