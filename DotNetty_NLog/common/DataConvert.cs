using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetty_NLog.common
{
    public class DataConvert
    {
        /// <summary>
        ///  把十六进制字符串转换成字节数组.
        /// </summary>
        /// <param name="InString"></param>
        /// <returns></returns>
        public static byte[] hexStringToBytes(string InString)
        {
            string[] ByteStrings;
            ByteStrings = InString.Split(" ".ToCharArray());
            byte[] ByteOut;
            ByteOut = new byte[ByteStrings.Length - 1];
            for (int i = 0; i < ByteStrings.Length - 1; i++)
            {
                ByteOut[i] = Convert.ToByte(ByteStrings[i], 16);
            }
            return ByteOut;
        }
        /// <summary>
        /// 字节数组转换十六进制字符串.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static String bytesToHexString(byte[] src)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte inByte in src)
            {
                stringBuilder.Append(inByte.ToString("X2") + " ");
            }
            return stringBuilder.ToString();
        }
        /// <summary>
        /// 将4个字节的字节数组转换为Int值 
        /// 由高位到低位
        /// </summary>
        /// <param name="bytes">byte[]</param>
        /// <returns>int</returns>
        public static int bytes2Int(byte[] bytes)
        {
            int result = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                result += ((int)(bytes[i] & 0xFF)) << (8 * (bytes.Length - i - 1));
            }
            return result;
        }
        /// <summary>
        /// 高字节在前BCD转Int
        ///
        ///方法添加日期: 2014年1月8日 创建者:刘源
        /// </summary>
        /// <param name="len"></param>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static int bcd2HighInt(int len, byte[] buf)
        {
            int dec = 0;
            int k = 1;

            for (int i = len; i > 0; i--)
            {
                dec = dec + (int)(((buf[i - 1] & 0xf0) >> 4) * 10 + (buf[i - 1] & 0x0f)) * k;
                k = k * 100;
            }
            return dec;
        }

    }
}
