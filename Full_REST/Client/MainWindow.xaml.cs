using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Web.Script.Serialization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Threading;
using Full_REST.BookDb;
using Newtonsoft.Json;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:20989") };
        private HttpResponseMessage response = null;

        public MainWindow()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }



        private async void Get_All_Books(object sender, RoutedEventArgs e)
        {
            try
            {
                var list = await Get_Deserialize("/api/books", true);
                Print(list);
            }
            catch
            {
                throw new NullReferenceException();
            }
        }

        private async void Get_Book_By_Id(object sender, RoutedEventArgs e)
        {
            res.Text = " ";
            if (idbox.Text == "") MessageBox.Show("Please set id", "About id...");
            try
            {
                var list = await Get_Deserialize("/api/books/", false);
                Print(list);
                idbox.Clear();
            }
            catch { throw new InvalidOperationException(); }
        }

        private async Task<List<Book>> Get_Deserialize(string uri, bool flag)
        {
            response = await client.GetAsync(uri + idbox.Text);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            if (flag)
            {
                return JsonConvert.DeserializeObject<List<Book>>(result);
            }
            Book book = JsonConvert.DeserializeObject<Book>(result);
            return new List<Book> { book };
        }

        private void Print(List<Book> list)
        {
            res.Text = "";
            foreach (Book book in list)
                res.Text += book.Author + "\t" + book.Name + "\t" + book.PublishDate + "\n";
        }
    }
}
