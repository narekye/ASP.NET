using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
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
            InitializeComponent();
        }



        private async void Get_All_Books(object sender, RoutedEventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                response = await client.GetAsync("/api/books");
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result;
                var list = JsonConvert.DeserializeObject<List<Book>>(result);
                foreach (Book book in list)
                    res.Text += book.Author + "\t" + book.Name + "\t" + book.PublishDate + "\n";
            }
            catch
            {
                throw new NullReferenceException();
            }
        }


    }
}
