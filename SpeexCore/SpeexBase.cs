using SpeexCore.Enums;
using SpeexCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static SpeexCore.SpeexCommon;
using SpeexCore.Tools;

namespace SpeexCore
{
    public class SpeexBase : IDisposable
    {
        private IntPtr _encodeStateIntptr { get; set; }//音频数据压缩状态
        private SpeexBits _encodeSpeexBits = new SpeexBits();//音频数据压缩比特流
        private IntPtr _decodeStateIntptr { get; set; }//音频数据压缩状态
        private SpeexBits _decodeSpeexBits = new SpeexBits();//音频数据压缩比特流
        SpeexBase() { }
        /// <summary>
        /// 初始化Speex编解码器实例
        /// </summary>
        /// <param name="quality">压缩质量，值越大压缩比越小，音质越清晰，有效范围 1-10</param>
        /// <param name="modelType">编码器类型</param>
        public SpeexBase(ModelType modelType, int quality)
        {
            _encodeStateIntptr = SpeexEncodeApi.Speex_encoder_init(SpeexCommon.Speex_lib_get_mode((int)modelType));//初始化模式结构体 拿到state指针
            _decodeStateIntptr = SpeexDecodeApi.Speex_decoder_init(SpeexCommon.Speex_lib_get_mode((int)modelType));//初始化模式结构体 拿到state指针
            SpeexBitsApi.Speex_bits_init(ref _encodeSpeexBits);//初始化数据结构体
            SpeexBitsApi.Speex_bits_init(ref _decodeSpeexBits);//初始化数据结构体
            this.SetEncode(SetCoderState.Quality, quality);
        }
        /// <summary>
        /// 压缩音频数据
        /// </summary>
        /// <param name="input">需要压缩的音频字节流</param>
        /// <returns>压缩后的Speex数据流</returns>
        public byte[] EncodeBase(byte[] input)
        {
            if (input == null || input.Length > 320)
            {
                throw new Exception("值不能为空且每次压缩的数据大小不能超过320个字节");
            }
            input = SpeexHelper.PadArr(input, 320);
            SpeexBitsApi.Speex_bits_reset(ref _encodeSpeexBits);
            short[] sShort = SpeexHelper.BytesToShorts(input);
            //float[] sInput = SpeexHelper.ShortsToFloats(sShort);
            int i = SpeexEncodeApi.Speex_encode_int(_encodeStateIntptr, sShort, ref _encodeSpeexBits);
            int len = SpeexBitsApi.Speex_bits_nbytes(ref _encodeSpeexBits);
            byte[] outBuffer = new byte[len];
            int outResult = SpeexBitsApi.Speex_bits_write(ref _encodeSpeexBits, outBuffer, outBuffer.Length);
            return outBuffer.Take(outResult).ToArray();
        }
        /// <summary>
        /// 解压Speex音频数据流
        /// </summary>
        /// <param name="input">需要解压的数据流</param>
        /// <returns>解压后的正常音频数据</returns>
        public byte[] DecodeBase(byte[] input)
        {
            SpeexBitsApi.Speex_bits_reset(ref _decodeSpeexBits);
            SpeexBitsApi.Speex_bits_read_from(ref _decodeSpeexBits, input, input.Length);
            //int i = SpeexBitsApi.Speex_bits_nbytes(ref _decodeSpeexBits);
            short[] buffer = new short[160];
            int len = SpeexDecodeApi.Speex_decode_int(_decodeStateIntptr, ref _decodeSpeexBits, buffer);
            return SpeexHelper.ShortsToBytes(buffer);
        }
        /// <summary>
        /// 设置编码器属性
        /// </summary>
        /// <param name="setState">目标编码器属性</param>
        /// <param name="value">设置的值</param>
        /// <returns> 0 没有错误，-1为未知请求，-2为无效参数</returns>
        public int SetEncode(SetCoderState setState, int value)
        {
            IntPtr intPtr = GCHandle.Alloc(value, GCHandleType.Pinned).AddrOfPinnedObject();
            int result = SpeexEncodeApi.Speex_encoder_ctl(_encodeStateIntptr, (int)setState, intPtr);
            return result;
        }
        /// <summary>
        /// 获取编码器设置
        /// </summary>
        /// <param name="getState">目标编码器属性</param>
        /// <returns>编码器属性值 -1为未知请求，-2为无效参数</returns>
        public int GetEncode(GetCoderState getState)
        {
            int value = 0;
            IntPtr intPtr = GCHandle.Alloc(value, GCHandleType.Pinned).AddrOfPinnedObject();
            int result = SpeexEncodeApi.Speex_encoder_ctl(_encodeStateIntptr, (int)getState, intPtr);
            if (result == 0)
            {
                result = Marshal.ReadInt32(intPtr);
            }
            return result;
        }
        /// <summary>
        /// 对Speex编解码器进行后续的清理工作
        /// </summary>
        public void Dispose()
        {
            SpeexEncodeApi.Speex_encoder_destroy(_encodeStateIntptr);
            SpeexDecodeApi.Speex_decoder_destroy(_decodeStateIntptr);
            SpeexBitsApi.Speex_bits_destroy(ref _encodeSpeexBits);
            SpeexBitsApi.Speex_bits_destroy(ref _decodeSpeexBits);
            GC.Collect();
        }
    }
}
