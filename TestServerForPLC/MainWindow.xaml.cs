using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.TestServerForPLC;

namespace TestServerForPLC
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Server server;

        public MainWindow()
        {
            InitializeComponent();
            ip.Text = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
            server = new Server();
            server.MainFlow();
            Task.Factory.StartNew(() => RefreshReceive(), TaskCreationOptions.LongRunning);
            Task.Factory.StartNew(() => RefreshCallback(), TaskCreationOptions.LongRunning);
        }

        private async void start_Click(object sender, RoutedEventArgs e)
        {
            await server.StartServer(port.Text);
        }

        private async void send_Click(object sender, RoutedEventArgs e)
        {
            byte lineNo = Convert.ToByte(txt14.Text);
            byte tabNo = Convert.ToByte(txt15.Text);
            byte index = Convert.ToByte(txt16.Text);
            byte blockNo = Convert.ToByte(txt17.Text);
            BLL.PLCStruct.ProvideGoods provideGoods = new BLL.PLCStruct.ProvideGoods(lineNo, tabNo, index, blockNo);
            await server.SendMsg(provideGoods);
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            server.receiveCond = false;
            await Task.Delay(1000);
        }

        /// <summary>
        /// 轮询接收信息
        /// </summary>
        /// <returns></returns>
        private async Task RefreshReceive()
        {
            while (server.receiveCond)
            {
                if (DataCache.ReceiveQueue.Count <= 0)
                {
                    await Task.Delay(200);
                    continue;
                }
                else
                {
                    DataCache.ReceiveQueue.TryDequeue(out BLL.JsonObject.ProvideGoods provideGoods);
                    txt11.Text = "0x0C";
                    txt12.Text = "0x0201";
                    txt13.Text = "0x01";
                    txt14.Text = provideGoods.LineNo.ToString();
                    txt15.Text = provideGoods.TableNo.ToString();
                    txt16.Text = provideGoods.Index.ToString();
                    txt17.Text = provideGoods.BlockNo.ToString();
                    txt18.Text = provideGoods.ToString();
                    await Task.Delay(200);
                }
            }
        }

        /// <summary>
        /// 轮询接受回执
        /// </summary>
        /// <returns></returns>
        private async Task RefreshCallback()
        {
            while (server.callbackCond)
            {
                if (DataCache.CallbackQueue.Count <= 0)
                {
                    await Task.Delay(200);
                    continue;
                }
                else
                {
                    DataCache.CallbackQueue.TryDequeue(out string str);
                    status.Text = str;
                }
            }
        }
    }
}
