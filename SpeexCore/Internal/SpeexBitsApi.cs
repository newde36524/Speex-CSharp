using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static SpeexCore.SpeexCommon;

namespace SpeexCore.Internal
{
    internal class SpeexBitsApi
    {
        private const string dllPath = SpeexCommon.DLLPath;

        [DllImport(dllPath, EntryPoint = "speex_bits_init", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Speex_bits_init(ref SpeexBits bits);

        [DllImport(dllPath, EntryPoint = "speex_bits_reset", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Speex_bits_reset(ref SpeexBits bits);

        [DllImport(dllPath, EntryPoint = "speex_bits_write", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_bits_write(ref SpeexBits bits, byte[] ouput, int len);

        [DllImport(dllPath, EntryPoint = "speex_bits_init_buffer", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr Speex_bits_init_buffer(ref SpeexBits bits, byte[] ouput, int len);

        [DllImport(dllPath, EntryPoint = "speex_bits_peek", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_bits_peek(ref SpeexBits bits);

        [DllImport(dllPath, EntryPoint = "speex_bits_set_bit_buffer", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Speex_bits_set_bit_buffer(ref SpeexBits bits, byte[] buff, int buffSize);

        [DllImport(dllPath, EntryPoint = "speex_bits_rewind", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_bits_rewind(ref SpeexBits bits);

        [DllImport(dllPath, EntryPoint = "speex_bits_unpack_signed", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_bits_unpack_signed(ref SpeexBits bits, int nbBits);

        [DllImport(dllPath, EntryPoint = "speex_bits_destroy", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Speex_bits_destroy(ref SpeexBits bits);

        [DllImport(dllPath, EntryPoint = "speex_bits_read_from", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Speex_bits_read_from(ref SpeexBits bits, byte[] bytes, int len);

        [DllImport(dllPath, EntryPoint = "speex_bits_nbytes", CallingConvention = CallingConvention.Cdecl)]
        public extern static int Speex_bits_nbytes(ref SpeexBits bits);
    }
}
