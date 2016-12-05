using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using DotNetty_NLog.common;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetty_NLog.codec
{
    public class CustomProtocolDecoder : ByteToMessageDecoder
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            if (!input.IsReadable())
            {
                return;
            }
            LOGGER.Debug("收到的报文:{0}", DataConvert.bytesToHexString(input.ToArray()));
            int bodyLength = input.ReadableBytes;
            byte[] dataBytes = new byte[bodyLength];
            input.ReadBytes(dataBytes);
            output.Add(dataBytes);
        }
    }
}
