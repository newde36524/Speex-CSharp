using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeexCore.Internal
{
    internal class SpeexPreprocessApi
    {
        private const string dllPath = SpeexCommon.DLLPath;

        [DllImport(dllPath, EntryPoint = "speex_preprocess_state_init", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr Speex_preprocess_state_init(int frame_size, int sampling_rate);

        [DllImport(dllPath, EntryPoint = "speex_preprocess_ctl", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_preprocess_ctl(IntPtr st, int request, IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "speex_preprocess_estimate_update", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Speex_preprocess_estimate_update(IntPtr st, short x);

        [DllImport(dllPath, EntryPoint = "speex_preprocess_run", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_preprocess_run(IntPtr st, short[] x);

        [DllImport(dllPath, EntryPoint = "speex_preprocess_state_destroy", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_preprocess_state_destroy(IntPtr st);
    }
}
