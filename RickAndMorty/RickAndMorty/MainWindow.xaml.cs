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

namespace RickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            RickAndMortyAPI api;


            using (var client = new HttpClient())
            {
                string url = "https://rickandmortyapi.com/api/character";

                while (string.IsNullOrWhiteSpace(url) == false)
                {
                    string JsonData = client.GetStringAsync(url).Result;

                    api = JsonConvert.DeserializeObject<RickAndMortyAPI>(JsonData);

                    foreach (Results character in api.results)
                    {
                        CharacterList.Items.Add(character);
                    }

                    url = api.info.next;
                }
            }

        }

        private void CharacterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedCharacter = (Results)CharacterList.SelectedItem;
            IndividualCharacter wnd = new IndividualCharacter();
            wnd.SetUpWindow(SelectedCharacter);
            wnd.Show();
        }
    }
}
