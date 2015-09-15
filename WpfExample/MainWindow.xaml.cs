using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string FeedUri = "http://blogs.msdn.com/b/visualstudio/rss.aspx";

        private CancellationTokenSource cancellationToken;



        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<IEnumerable<Item>> QueryRssAsync(CancellationToken token)
        {
            try
            {
                var client = new HttpClient();
                var data = await client.GetAsync(new Uri(FeedUri), token);

                var actualData = await data.Content.ReadAsStringAsync();

                var doc = XDocument.Parse(actualData);
                var dc = XNamespace.Get("http://purl.org/dc/elements/1.1/");

                var query = (from entry in doc.Descendants("item")
                             select new Item
                             {
                                 Title = entry.Element("title").Value,
                                 Link = new Uri(entry.Element("link").Value),
                                 Author = entry.Element(dc + "creator").Value,
                                 PubDate = DateTime.Parse(entry.Element("pubDate").Value, System.Globalization.CultureInfo.InvariantCulture)

                             });

                return query;

            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Operacion cancelada por el usuario");

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.cancellationToken = new CancellationTokenSource();

            this.DataContext = await QueryRssAsync(this.cancellationToken.Token);

        }



        private void Cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            if (this.cancellationToken != null)
            {
                this.cancellationToken.Cancel();
            }

        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var content = (TextBlock)sender;
            var link = (Uri)content.Tag;
            Process.Start(link.AbsoluteUri);
        }


    }
}
