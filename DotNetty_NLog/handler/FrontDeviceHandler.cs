using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetty_NLog.handler
{
    public class FrontDeviceHandler : SimpleChannelInboundHandler<object>
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        public override void ChannelActive(IChannelHandlerContext context)
        {
            LOGGER.Debug("打开连接:{0}", context.Channel.RemoteAddress.ToString());
        }


        public override void ChannelInactive(IChannelHandlerContext context)
        {
            LOGGER.Debug("关闭连接:{0}", context.Channel.RemoteAddress.ToString());
        }

        protected override void ChannelRead0(IChannelHandlerContext context, object message)
        {
            if (message is byte[])
            {
                byte[] messageBytes = message as byte[];
                context.Channel.WriteAndFlushAsync(messageBytes);
            }
        }
    }
}
