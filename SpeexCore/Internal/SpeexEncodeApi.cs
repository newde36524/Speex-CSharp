using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static SpeexCore.SpeexCommon;

namespace SpeexCore.Internal
{
    internal class SpeexEncodeApi
    {
        private const string dllPath = SpeexCommon.DLLPath;

        [DllImport(dllPath, EntryPoint = "speex_encoder_init", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr Speex_encoder_init(IntPtr mode);

        [DllImport(dllPath, EntryPoint = "speex_encoder_ctl", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_encoder_ctl(IntPtr state, int request, IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "speex_encode", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_encode(IntPtr state, float[] In, ref SpeexBits bits);

        [DllImport(dllPath, EntryPoint = "speex_encode_int", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_encode_int(IntPtr state, short[] In, ref SpeexBits bits);

        [DllImport(dllPath, EntryPoint = "speex_encoder_destroy", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Speex_encoder_destroy(IntPtr state);
    }
}
