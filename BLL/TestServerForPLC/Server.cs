using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace BLL.TestServerForPLC
{
    public class Server
    {
        private IEventLoopGroup bossGroup;
        private IEventLoopGroup workerGroup;
        private ServerBootstrap bootstrap;
        public IChannel client;
        public bool receiveCond;
        public bool callbackCond;

        public Server()
        {
            receiveCond = true;
            callbackCond = true;
        }

        /// <summary>
        /// 主流程开启
        /// </summary>
        public void MainFlow()
        {
            bossGroup = new MultithreadEventLoopGroup(1);
            workerGroup = new MultithreadEventLoopGroup();
            bootstrap = new ServerBootstrap();
            bootstrap
                .Group(bossGroup, workerGroup)
                .Channel<TcpServerSocketChannel>()
                .Option(ChannelOption.SoBacklog, 100)
                .Handler(new LoggingHandler("LSTN"))
                .ChildHandler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    IChannelPipeline pipeline = channel.Pipeline;
                    pipeline.AddLast(new LoggingHandler("CONN"));
                    pipeline.AddLast(new ClientHandler());
                }));
        }

        /// <summary>
        /// 开始监听
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task StartServer(string port)
        {
            client = await bootstrap.BindAsync(Convert.ToInt32(port));
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="byteBuffer"></param>
        /// <returns></returns>
        public async Task SendMsg(PLCStruct.ProvideGoods provideGoods)
        {
            await client.WriteAndFlushAsync(provideGoods.ToByteBuffer());
        }

        /// <summary>
        /// 结束主流程
        /// </summary>
        public async Task CloseMainFlow()
        {
            try
            {
                // 关闭客户端
                await client.CloseAsync();
            }
            finally
            {
                // 终止工作线程
                await bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
                await workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
            }
        }

    }
}
