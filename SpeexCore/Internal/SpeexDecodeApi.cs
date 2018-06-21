using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static SpeexCore.SpeexCommon;

namespace SpeexCore.Internal
{
    internal class SpeexDecodeApi
    {
        private const string dllPath = SpeexCommon.DLLPath;

        [DllImport(dllPath, EntryPoint = "speex_decoder_init", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr Speex_decoder_init(IntPtr mode);

        [DllImport(dllPath, EntryPoint = "speex_decoder_ctl", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_decoder_ctl(IntPtr state, int request, IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "speex_decode_int", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_decode_int(IntPtr state, ref SpeexBits bits, short[] output);

        [DllImport(dllPath, EntryPoint = "speex_decoder_destroy", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Speex_decoder_destroy(IntPtr state);
    }
}
