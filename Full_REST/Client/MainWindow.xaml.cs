using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using Full_REST.BookDb;
using Newtonsoft.Json;

namespace Client
{
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
                var list = await Get_Deserialize_Async("/api/books", true);
                Print(list);
            }
            catch
            {
                throw new NullReferenceException();
            }
        }

        private async void Get_Book_By_Id(object sender, RoutedEventArgs e)
        {
            res.Text = "";
            if (idbox.Text == "")
            {
                MessageBox.Show("Please set id", "About id...");
                return;
            }
            try
            {
                var list = await Get_Deserialize_Async("/api/books/", false);
                Print(list);
                idbox.Clear();
            }
            catch { throw new InvalidOperationException(); }
        }

        private async Task<List<Book>> Get_Deserialize_Async(string uri, bool flag)
        {
            response = await client.GetAsync(uri + idbox.Text);
            //  response.EnsureSuccessStatusCode(); this can be used to validate your action....
            Print(response);
            var result = await response.Content.ReadAsStringAsync();
            if (flag)
                return JsonConvert.DeserializeObject<List<Book>>(result);
            Book book = JsonConvert.DeserializeObject<Book>(result);
            return new List<Book> { book };
        }

        private void Print(List<Book> list)
        {
            if (ReferenceEquals(list, null)) return;
            res.Text = "";
            foreach (Book book in list)
                res.Text += book.Author + "\t" + book.Name + "\t" + book.PublishDate + "\n";
        }

        private void Print(HttpResponseMessage message)
        {
            info.Text = "";
            info.Text += "Method: \t" + message.RequestMessage.Method + "\n"
                         + "URI:\t" + message.RequestMessage.RequestUri + "\n" + "Build Version:\t" +
                         message.RequestMessage.Version.Build + "\n" + "Is Succes:\t" + message.IsSuccessStatusCode + "\n" +
                         "Server Response Code:\t" + message.StatusCode;
        }

        private void Show_Post(object sender, RoutedEventArgs e)
        {
            new Post_Book().Show();
        }

        private void Show_Put(object sender, RoutedEventArgs e)
        {
            new Put_Book().Show();
        }

        private async void Show_Delete(object sender, RoutedEventArgs e)
        {
            res.Text = "";
            response = await client.GetAsync("/api/books/" + idbox2.Text);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("No such record, Server answer  " + response.StatusCode);
                return;
            }
            
            Print(response);
            response = await client.DeleteAsync("/api/books/" + idbox2.Text);
            Print(response);
        }
    }
}
