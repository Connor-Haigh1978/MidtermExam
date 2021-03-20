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

namespace Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string url = "https://pokeapi.co/api/v2/pokemon?limit=1200";
            AllPokemonAPI api;

            using (var client = new HttpClient())
            {
                string JsonData = client.GetStringAsync(url).Result;
                api = JsonConvert.DeserializeObject<AllPokemonAPI>(JsonData);
            }
            foreach (ResultObject pokemon in api.results.OrderBy(x => x.name).ToList())
            {
                PokemonListBox.Items.Add(pokemon);
            }

        }

        private void PokemonListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPokemonWindow NewWindow = new SelectedPokemonWindow();
            var SelectedPokemon = (ResultObject)PokemonListBox.SelectedItem;
            PokemonInfo api;
            NewWindow.ShowDetails(SelectedPokemon);
            NewWindow.Show();
        }
    }
}
