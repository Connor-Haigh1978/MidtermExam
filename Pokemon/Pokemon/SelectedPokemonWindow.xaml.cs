using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pokemon
{
    /// <summary>
    /// Interaction logic for SelectedPokemonWindow.xaml
    /// </summary>
    public partial class SelectedPokemonWindow : Window
    {
        public PokemonInfo IndividualPokemon { get; set; }

        PokemonInfo api;
        public SelectedPokemonWindow()
        {
            InitializeComponent();
            ChangeSprite.Content = "Change to front sprite";
            
        }

        public void ShowDetails(ResultObject pokemon)
        {
            using (var client = new HttpClient())
            {
                string JsonData = client.GetStringAsync(pokemon.url).Result;
                api = JsonConvert.DeserializeObject<PokemonInfo>(JsonData);

            }

            NameBox.Text = $"Name: {api.name}";
            HeightBox.Text = $"Height: {api.height}";
            WeightBox.Text = $"Weight: {api.weight}";

            ImagePokemon.Source = new BitmapImage(new Uri(api.sprites.back_default));
        }

        private void ChangeSprite_Click(object sender, RoutedEventArgs e)
        {
            bool ButtonContent = false;
            switch (ChangeSprite.Content)
            {
                case "Change to back sprite":
                    ChangeSprite.Content = "Change to front sprite";
                    ImagePokemon.Source = new BitmapImage(new Uri(api.sprites.back_default));
                    break;
                case "Change to front sprite":
                    ChangeSprite.Content = "Change to back sprite";
                    ImagePokemon.Source = new BitmapImage(new Uri(api.sprites.front_default));
                    break;

            }
        }
    }
}
