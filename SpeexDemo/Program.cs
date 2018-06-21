using SpeexCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SpeexCore.Enums;

namespace SpeexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SpeexExample speexInvoke = new SpeexExample(ModelType.SpeexNbMode))
            {
                byte[] receive = speexInvoke.Encode(File.ReadAllBytes(@"01.wav"));
                File.WriteAllBytes("Speex.speex", receive);//保存压缩后的数据
                Console.WriteLine("音频压缩完成");
                byte[] output = speexInvoke.Decode(receive);
                File.WriteAllBytes("02.pcm", output);//解压数据并保存pcm格式
                Console.WriteLine("音频解压完成");
            }
            Console.ReadLine();
        }
    }
}
