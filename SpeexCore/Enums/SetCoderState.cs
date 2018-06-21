namespace SpeexCore.Enums
{
    public enum SetCoderState
    {
        /// <summary>
        /// 设置增强/关闭(只有解码器) 1开，0关
        /// </summary>
        Ehn = 0,
        /// <summary>
        /// 压缩质量 取值范围：1-10
        /// </summary>
        Quality = 4,
        /// <summary>
        /// 设置子模式使用
        /// </summary>
        Mode = 6,
        /// <summary>
        /// 低频带子模式使用(仅使用宽带)
        /// </summary>
        LowMode = 8,
        /// <summary>
        /// 设置高频带子模式使用(仅使用宽带)
        /// </summary>
        HighMode = 10,
        /// <summary>
        /// 设置VBR(动态比特率) 1开，0关
        /// </summary>
        Vbr = 12,
        /// <summary>
        /// 为VBR编码设置质量值(0-10)
        /// </summary>
        VbrQuality = 14,
        /// <summary>
        /// 设置编码器的复杂性(0-10)
        /// </summary>
        Complexity = 16,
        /// <summary>
        /// 设置由编码器(或更低)使用的比特率 例：8 16 32
        /// </summary>
        BitRate = 18,
        /// <summary>
        /// 为in-band Speex请求定义一个处理函数(暂未实现)
        /// </summary>
        Handler = 20,
        /// <summary>
        /// 为带用户定义的请求定义一个处理函数
        /// </summary>
        UserHandler = 22,
        /// <summary>
        /// 采样率 8000 16000 32000
        /// </summary>
        SamplingRate = 24,
        /// <summary>
        /// 将编码/解码存储器重置为0
        /// </summary>
        ResetState = 26,
        /// <summary>
        /// 设置VAD(语音活动检测)状态 1开，0关
        /// </summary>
        Vad = 30,
        /// <summary>
        /// 将平均比特率(ABR)设置为n位/秒  例：8 16 32
        /// </summary>
        Abr = 32,
        /// <summary>
        /// 设置DTX(不连续发送)状态 1开，0关
        /// </summary>
        Dtx = 34,
        /// <summary>
        /// 在每一帧中设置子模式编码(1为yes，0为no，设置为不打破标准)
        /// </summary>
        SubmodeEncoding = 36,
        /// <summary>
        /// 为包丢失隐藏(期望损失率)设置调优
        /// </summary>
        PlcTuning = 40,
        /// <summary>
        /// 设置VBR模式允许的最大比特率 例：8 16 32
        /// </summary>
        VbrMaxBitrate = 42,
        /// <summary>
        /// 开启/关闭输入/输出高通滤波 1开，0关
        /// </summary>
        HighPass = 44
    }
}
