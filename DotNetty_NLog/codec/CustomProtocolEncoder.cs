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
    public class CustomProtocolEncoder : MessageToByteEncoder<object>
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        protected override void Encode(IChannelHandlerContext context, object message, IByteBuffer output)
        {
            if (message is byte[])
            {
                byte[] bytes = message as byte[];
                LOGGER.Debug("发出的报文:{0}", DataConvert.bytesToHexString(bytes));
                output.WriteBytes(bytes);
            }
        }
    }
}
