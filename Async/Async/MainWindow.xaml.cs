using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //_ = DownloadHtmlAsync("http://www.google.com");

            var getHtmlTask = GetHtmlAsync("http://msdn.microsoft.com");
            MessageBox.Show("Waiting for the task to complete");

            var html = await getHtmlTask;
            MessageBox.Show(html.Substring(0, 10));
        }

        public async Task<string> GetHtmlAsync(string url)
        {
            var webCLient = new WebClient();
            return await webCLient.DownloadStringTaskAsync(url);
        }


        public string GetHtml(string url)
        {
            var webCLient = new WebClient();
            return webCLient.DownloadString(url);
        }
        //Task : encapsulate the asyn operation
        public async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);
            //await : Marks the location to the compiler

            using (var streamWriter = new StreamWriter(@"c:\projects\result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }

        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"c:\projects\result.html"))
            {
                streamWriter.Write(html);
            }
        }
    }
}