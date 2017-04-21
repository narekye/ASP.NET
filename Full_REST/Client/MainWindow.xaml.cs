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
    public partial class MainWindow
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("http://localhost:20989") };
        private HttpResponseMessage _response;

        public MainWindow()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            _response = await _client.GetAsync(uri + idbox.Text);
            //  _response.EnsureSuccessStatusCode(); this can be used to validate your action....
            Print(_response);
            var result = await _response.Content.ReadAsStringAsync();
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
            _response = await _client.GetAsync("/api/books/" + idbox2.Text);
            if (!_response.IsSuccessStatusCode)
            {
                MessageBox.Show("No such record, Server answer  " + _response.StatusCode);
                return;
            }
            
            Print(_response);
            _response = await _client.DeleteAsync("/api/books/" + idbox2.Text);
            Print(_response);
        }

        private async void Download(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(box.Text);
            try
            {
                res.Text = await _client.GetStringAsync(uri);
            }
            catch
            {
                MessageBox.Show("Oops! Please write correct address");
            }
        }
    }
}
