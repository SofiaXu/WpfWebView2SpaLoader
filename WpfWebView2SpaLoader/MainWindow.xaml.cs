using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWebView2SpaLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string SourceUrl { get; set; }
        public MainWindow(IServer server)
        {
            InitializeComponent();
            // 这里通过注入的 IServer 对象来获取监听的 Url
            var addresses = server.Features.Get<IServerAddressesFeature>()?.Addresses;
            SourceUrl = addresses is not null ? (addresses.FirstOrDefault() ?? "http://localhost:5000") : "http://localhost:5000";
            // 无 VM，用自身当 VM
            DataContext = this;
        }
    }
}