using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetty_NLog.codec;
using DotNetty_NLog.handler;
using Microsoft.Extensions.Logging;
using NLog;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetty_NLog
{
    class Program
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();




        static async Task RunServerAsync()
        {
            //String getewayPort = ConfigurationManager.AppSettings["Gateway.Port"];
            //String getewayPort = "5061";
            //var bossGroup = new MultithreadEventLoopGroup(1);
            //var workerGroup = new MultithreadEventLoopGroup(Environment.ProcessorCount);
            //try
            //{
            //    var bootstrap = new ServerBootstrap();
            //    bootstrap
            //        .Group(bossGroup, workerGroup)
            //        .Channel<TcpServerSocketChannel>()
            //        .Option(ChannelOption.SoBacklog, 512)
            //        .ChildOption(ChannelOption.TcpNodelay, true)
            //        .Option(ChannelOption.SoReuseaddr, true)
            //        .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
            //        {
            //            IChannelPipeline pipeline = channel.Pipeline;
            //            pipeline.AddLast(new CustomProtocolDecoder());
            //            pipeline.AddLast(new CustomProtocolEncoder());
            //            pipeline.AddLast(new FrontDeviceHandler());
            //        }));

            //    IChannel boundChannel = await bootstrap.BindAsync(int.Parse(getewayPort));
            //    Console.ReadLine();
            //    await boundChannel.CloseAsync();
            //}
            //finally
            //{
            //    await Task.WhenAll(
            //        workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
            //        bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
            //}
        }

        static void Main(string[] args)
        {
            RunServerAsync().Wait();
        }
    }
}
