using SpeexCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeexCore.Tools;

namespace SpeexCore
{
    public class SpeexExample : SpeexBase
    {
        /// <summary>
        /// 初始化框架预定义编解码流程的实例
        /// </summary>
        /// <param name="modelType">编解码器状态类型</param>
        /// <param name="quality">压缩质量</param>
        public SpeexExample(ModelType modelType, int quality = 8) : base(modelType, quality)
        {
        }
        /// <summary>
        /// 基于SpeexCore的具体压缩示例实现
        /// 规则 压缩：压缩数据个数+压缩数据 如：byte[42]=byte[4]+byte[38] byte[24]=byte[4]+byte[20] ... 
        /// 根据质量压缩出来的数据个数的int值在内存中的占用数据+压缩数据
        /// 解压：按当前规则动态解析
        /// </summary>
        /// <param name="input">正常的全部音频数据</param>
        /// <returns>压缩后并组合的Speex数据</returns>
        public byte[] Encode(byte[] input)
        {
            input = SpeexHelper.PadArr(input, 320);//补足320 的倍数
            int i = 0;
            IEnumerable<byte> nbyte = null;
            List<byte> receive = new List<byte>();
            while ((nbyte = input.Skip(i).Take(320)).Count() != 0)
            {
                byte[] rec = base.EncodeBase(nbyte.ToArray());
                byte[] lenByte = BitConverter.GetBytes(rec.Length);
                receive.AddRange(lenByte);
                receive.AddRange(rec);
                Console.WriteLine(i);
                i += 320;
            }
            return receive.ToArray();
        }
        /// <summary>
        /// 根据当前压缩规则进行解压，如果压缩规则不是当前规则，解压无效
        /// 请使用SpeexBase的EncodeBase方法对每一帧进行压缩
        /// </summary>
        /// <param name="input">被当前压缩规则压缩的Speex数据</param>
        /// <returns>正常的全部音频数据</returns>
        public byte[] Decode(byte[] input)
        {
            int i = 0;
            List<byte> receive = new List<byte>();
            int rawLen = 0;
            IEnumerable<byte> nbyte = null;
            while ((nbyte = input.Skip(i).Take(4)).Count() != 0)
            {
                rawLen = BitConverter.ToInt32(nbyte.ToArray(), 0);
                if (rawLen != 0)
                {
                    byte[] raw = input.Skip(i + 4).Take(rawLen).ToArray();
                    receive.AddRange(base.DecodeBase(raw));
                    i += (4 + rawLen);
                    Console.WriteLine(i);
                }
            }
            return receive.ToArray();
        }
    }
}
