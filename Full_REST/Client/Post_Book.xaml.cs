using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for Post_Book.xaml
    /// </summary>
    public partial class Post_Book : Window
    {
        private readonly HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:20989") };
        private HttpResponseMessage msg = null;
        public Post_Book()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Name", bname.Text);
            dict.Add("Author", bauthor.Text);
            dict.Add("PublishDate", bpublish.Text);
            HttpContent sc = new FormUrlEncodedContent(dict);
            msg = await client.PostAsync("/api/books/add", sc);
            MessageBox.Show("Method:\t" + msg.RequestMessage.Method + "\n"
                         + "URI:\t" + msg.RequestMessage.RequestUri + "\n" + "Build Version:\t" +
                         msg.RequestMessage.Version.Build + "\n" + "Is Succes:\t" + msg.IsSuccessStatusCode + "\n" +
                         "Server Response Code:\t" + msg.StatusCode);
            Close();
        }
    }
}
