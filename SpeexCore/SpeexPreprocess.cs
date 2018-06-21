using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SpeexCore.Enums;
using SpeexCore.Internal;
using SpeexCore.Tools;

namespace SpeexCore
{
    public class SpeexPreprocess : IDisposable
    {
        IntPtr preprocessMemAddress = IntPtr.Zero;
        int _frameSize = 0;
        SpeexPreprocess() { }
        /// <summary>
        /// 初始化Speex预处理实例
        /// </summary>
        /// <param name="sampling_rate">采样率 8000 16000 32000</param>
        /// <param name="frame_size">采样帧大小 对应 10-20ms 的采样帧 一般都是160</param>
        public SpeexPreprocess(int sampling_rate, int frameSize = 160)
        {
            _frameSize = frameSize;
            preprocessMemAddress = SpeexPreprocessApi.Speex_preprocess_state_init(_frameSize, sampling_rate);
        }
        /// <summary>
        /// 设置预处理器属性参数
        /// </summary>
        /// <param name="setPreprocess">预处理器属性</param>
        /// <param name="value">具体参数</param>
        /// <returns>0 成功，-1 未知请求</returns>
        public int Set(SetPreprocess setPreprocess, int value)
        {
            IntPtr intPtr = GCHandle.Alloc(value, GCHandleType.Pinned).AddrOfPinnedObject();
            int result = SpeexPreprocessApi.Speex_preprocess_ctl(preprocessMemAddress, (int)setPreprocess, intPtr);
            return result;
        }
        /// <summary>
        /// 获取预处理器参数值
        /// </summary>
        /// <param name="getPreprocess">预处理器属性</param>
        /// <returns>预处理器属性值</returns>
        public int Get(GetPreprocess getPreprocess)
        {
            int value = 0;
            IntPtr intPtr = GCHandle.Alloc(value, GCHandleType.Pinned).AddrOfPinnedObject();
            int result = SpeexPreprocessApi.Speex_preprocess_ctl(preprocessMemAddress, (int)getPreprocess, intPtr);
            if (result == 0)
            {
                result = Marshal.ReadInt32(intPtr);
            }
            return result;
        }
        /// <summary>
        /// 执行预处理
        /// </summary>
        /// <returns>预处理后的音频数据</returns>
        public byte[] Run(byte[] input)
        {
            if (input == null || input.Length > _frameSize * 2)
            {
                throw new Exception($"值不能为空且每次压缩的数据大小不能超过{_frameSize * 2}个字节");
            }
            input = SpeexHelper.PadArr(input, _frameSize * 2);
            short[] sShort = SpeexHelper.BytesToShorts(input);
            int result = SpeexPreprocessApi.Speex_preprocess_run(preprocessMemAddress, sShort);
            byte[] output = SpeexHelper.ShortsToBytes(sShort);
            return output;
        }

        public void Updata()
        {
            SpeexPreprocessApi.Speex_preprocess_estimate_update(preprocessMemAddress, (short)_frameSize);
        }

        /// <summary>
        /// 对预处理器进行后续的清理工作
        /// </summary>
        public void Dispose()
        {
            SpeexPreprocessApi.Speex_preprocess_state_destroy(preprocessMemAddress);
            GC.Collect();
        }
    }
}
