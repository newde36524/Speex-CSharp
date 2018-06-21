using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeexCore.Tools
{
    public class SpeexHelper
    {
        public static float[] ShortsToFloats(short[] input)
        {
            List<float> list = new List<float>();
            for (int i = 0; i < input.Length; i++)
            {
                list.Add(input[i]);
            }
            return list.ToArray();
        }

        public static float[] BytesToFloats(byte[] input)
        {
            List<float> list = new List<float>();
            for (int i = 0; i < input.Length; i += 4)
            {
                float f = BitConverter.ToSingle(input, i);
                list.Add(f);
            }
            return list.ToArray();
        }

        public static short[] BytesToShorts(byte[] input)
        {
            List<short> list = new List<short>();
            for (int i = 0; i < input.Length; i += 2)
            {
                short s = BitConverter.ToInt16(input, i);
                list.Add(s);
            }
            return list.ToArray();
        }

        public static byte[] ShortsToBytes(short[] input)
        {
            List<byte> list = new List<byte>();
            for (int i = 0; i < input.Length; i++)
            {
                byte[] s = BitConverter.GetBytes(input[i]);
                list.AddRange(s);
            }
            return list.ToArray();
        }

        public static short[] BytesToShorts(byte[] input, int offset, int length)
        {
            short[] processedValues = new short[length / 2];
            for (int c = 0; c < processedValues.Length; c++)
            {
                processedValues[c] = (short)(((int)input[(c * 2) + offset]) << 0);
                processedValues[c] += (short)(((int)input[(c * 2) + 1 + offset]) << 8);
            }

            return processedValues;
        }
        public static byte[] ShortsToBytes(short[] input, int offset, int length)
        {
            byte[] processedValues = new byte[length * 2];
            for (int c = 0; c < length; c++)
            {
                processedValues[c * 2] = (byte)(input[c + offset] & 0xFF);
                processedValues[c * 2 + 1] = (byte)((input[c + offset] >> 8) & 0xFF);
            }
            return processedValues;
        }

        /// <summary>
        /// 补足制定倍数的数组
        /// </summary>
        /// <typeparam name="T">制定数组类型</typeparam>
        /// <param name="input">需要补足的数组</param>
        /// <param name="targetMultiple">目标倍数</param>
        /// <returns></returns>
        public static T[] PadArr<T>(T[] input, int targetMultiple)
        {
            int len = input.Length;
            if (len % targetMultiple != 0)
            {
                int targetLen = len - len % targetMultiple + targetMultiple;
                T[] tArr = new T[targetLen];
                input.CopyTo(tArr, 0);
                return tArr;
            }
            else
            {
                return input;
            }
        }
        /// <summary>
        /// 判断大小端
        /// </summary>
        /// <returns></returns>
        public static bool IsBig()
        {
            long a = 0x1234;//小端数据
            byte[] b = BitConverter.GetBytes(a);
            string s = b[0].ToString("X2");//34  大端
            string t = a.ToString("X4");//1234
            if (t.IndexOf(s) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
