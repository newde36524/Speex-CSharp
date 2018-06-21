using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeexCore
{
    public class SpeexCommon
    {
        public const string DLLPath = "libspeex.dll";

        [DllImport(DLLPath, EntryPoint = "speex_lib_get_mode", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr Speex_lib_get_mode(int mode);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct SpeexBits
        {
            public IntPtr chars;     //"原始"数据
            public int nbBits;       //存储在流中的字节总数
            public int charPtr;      //字节"游标"的位置
            public int bitPtr;       //位"光标"在当前char中的位置
            public int owner;        //结构"拥有""原始"缓冲区(成员"chars")
            public int overflow;     //如果我们试图读取过去的有效数据,则设置为1
            public int buf_size;     //分配的缓冲区大小 
            public int reserved1;    //保留以供将来使用
            public IntPtr reserved2; //保留以供将来使用
        }
    }
}
