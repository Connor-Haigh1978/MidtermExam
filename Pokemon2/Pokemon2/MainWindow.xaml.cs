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

namespace Pokemon2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AllPokemonAPI api;
            string url = "https://pokeapi.co/api/v2/pokemon?offset=20&limit=1200";

            using (var client = new HttpClient())
            {
                string JsonData = client.GetStringAsync(url).Result;
                api = JsonConvert.DeserializeObject<AllPokemonAPI>(JsonData);

                foreach (Results Pokemon in api.results.OrderBy(x => x.name).ToList())
                {
                    PokemonListBox.Items.Add(Pokemon);
                }
            }
        }

        private void PokemonListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedPokemon = (Results)PokemonListBox.SelectedItem;
            SelectedPokemonWindow window = new SelectedPokemonWindow();
            window.Showdetails(SelectedPokemon);
            window.PokemonSelected = SelectedPokemon;
            window.ShowDialog();
        }
    }
}
