using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using Full_REST.BookDb;
using Newtonsoft.Json;

namespace Client
{
    public partial class Put_Book
    {
        private readonly HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:20989") };
        private HttpResponseMessage response = null;
        public Put_Book()
        {
            InitializeComponent();
        }

        private async void Get_Book_By_Id(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ReferenceEquals(null, bid.Text) || bid.Text == "") return;
                response = await client.GetAsync("/api/books/" + bid.Text);
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sorry , Web Api answers that the in db no such record..!!");
                    return;
                }
                var result = await response.Content.ReadAsStringAsync();
                Book book = JsonConvert.DeserializeObject<Book>(result);
                bname.Text = book.Name;
                bauthor.Text = book.Author;
                bpublish.Text = book.PublishDate;
                MessageBox.Show("Method:\t" + response.RequestMessage.Method + "\n"
                        + "URI:\t" + response.RequestMessage.RequestUri + "\n" + "Build Version:\t" +
                        response.RequestMessage.Version.Build + "\n" + "Is Succes:\t" + response.IsSuccessStatusCode + "\n" +
                        "Server Response Code:\t" + response.StatusCode);

            }
            catch { throw new InvalidOperationException(); }
        }

        private async void Put_A_Book(object sender, RoutedEventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Name", bname.Text);
            dict.Add("Author", bauthor.Text);
            dict.Add("PublishDate", bpublish.Text);
            HttpContent sc = new FormUrlEncodedContent(dict);
            response = await client.PutAsync("/api/books/" + bid.Text, sc);
            MessageBox.Show("Method:\t" + (response.RequestMessage.Method) + "\n"
                        + "URI:\t" + response.RequestMessage.RequestUri + "\n" + "Build Version:\t" +
                        response.RequestMessage.Version.Build + "\n" + "Is Succes:\t" + response.IsSuccessStatusCode + "\n" +
                        "Server Response Code:\t" + response.StatusCode);
            Close();
        }
    }
}
