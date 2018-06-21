using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeexCore.Enums
{
    public enum SetPreprocess
    {
        /// <summary>
        /// 预处理降噪状态
        /// </summary>
        Denoise = 0,
        /// <summary>
        /// 设置预处理器自动增益控制状态 1开0关
        /// </summary>
        Agc = 2,
        /// <summary>
        /// 设置预处理器语音活动检测状态
        /// </summary>
        Vad = 4,
        /// <summary>
        /// 设置预处理器自动增益控制级别(浮动)
        /// </summary>
        AgcLevel = 6,
        /// <summary>
        /// 设置预处理器反混响状态
        /// </summary>
        Dereverb = 8,
        /// <summary>
        /// 设置预处理器反混响级别
        /// </summary>
        DereverbLevel = 10,
        /// <summary>
        /// 设置预处理器反混响衰变
        /// </summary>
        DereverbDecay = 12,
        /// <summary>
        /// 设置VAD所需的从沉默到语音的概率
        /// </summary>
        ProbStart = 14,
        /// <summary>
        /// 设置VAD所需的保持在语音状态的概率(整数百分比)
        /// </summary>
        ProbContinue = 16,
        /// <summary>
        /// 在dB中设置最大衰减(负数)
        /// </summary>
        NoiseSuppress = 18,
        /// <summary>
        /// 在dB(负数)中设置最大衰减的最大值
        /// </summary>
        EchoSuppress = 20,
        /// <summary>
        /// 当接近结束时，在dB中设置最大衰减值(负数)
        /// </summary>
        EchoSuppressActive = 22,
        /// <summary>
        /// 设置相应的回波消除器状态，这样就可以执行剩余的回波抑制(没有剩余的回波抑制)
        /// </summary>
        EchoState = 24,
        /// <summary>
        /// 在db/秒(int32)中设置最大增益
        /// </summary>
        AgcIncrement = 26,
        /// <summary>
        /// 在db/秒(int32)中设置最大增益减少
        /// </summary>
        AgcDecrement = 28,
        /// <summary>
        /// 在dB中设置最大增益(int32)
        /// </summary>
        AgcMaxGain = 30,
        /// <summary>
        /// 设置预处理器自动增益控制级别(int32)
        /// </summary>
        AgcTarget = 46
    }
}
