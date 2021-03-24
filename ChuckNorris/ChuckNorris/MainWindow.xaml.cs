
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace ChuckNorris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string CategoryUrl = "https://api.chucknorris.io/jokes/categories";

            GetFilters(CategoryUrl);

        }

        private void GetFilters(string categoryUrl)
        {
            string url = categoryUrl;

            using (var client = new HttpClient())
            {
                var JsonData = client.GetStringAsync(url).Result;

                var Categories = JsonConvert.DeserializeObject<String[]>(JsonData);
                string CategoryOutput = "";

                CategoryComboBox.Items.Add("All");
                CategoryComboBox.SelectedIndex = 0;

                foreach (var category in Categories)
                {
                    char CategoryInput = char.ToUpper(category[0]);
                    CategoryOutput = CategoryInput+category.Substring(1); 
                    CategoryComboBox.Items.Add(CategoryOutput);
                }

            }
        }

        private void JokeButton_Click(object sender, RoutedEventArgs e)
        {
            string SelectedCatagory = CategoryComboBox.SelectedItem.ToString();
            string url = "";

            if (SelectedCatagory == "All")
            {
                url = "https://api.chucknorris.io/jokes/random";
            }
            else
            {
                url = $"https://api.chucknorris.io/jokes/random?category={SelectedCatagory.ToLower()}";
            }
            using (var client = new HttpClient())
            {
                ChuckNorrisAPI api;

                var JsonData = client.GetStringAsync(url).Result;

                api = JsonConvert.DeserializeObject<ChuckNorrisAPI>(JsonData);

                JokeBox.Text = $"{api.value})";
                CategoryBox.Text = api.categories.ToString();
                CreatedAtBox1.Text = api.created_at;
                ImageBox.Source = new BitmapImage(new Uri(api.icon_url));
            }
        }
    }
}
