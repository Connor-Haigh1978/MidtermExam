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

namespace Pokemon2
{
    /// <summary>
    /// Interaction logic for SelectedPokemonWindow.xaml
    /// </summary>
    public partial class SelectedPokemonWindow : Window
    {
        public Results PokemonSelected { get; set; }
        public SelectedPokemonWindow()
        {
            InitializeComponent();
              
        }

        public void Showdetails(Results SelectedPokemon)
        {
            string url = $"{SelectedPokemon.url}";
            PokemonInfoAPI api = NewMethod(url);
            HeightBox.Text = api.height;
            WeightBox.Text = api.weight;
            NameBox.Text = api.name;
            PokemonImage.Source = new BitmapImage(new Uri(api.sprites.front_default));
        }

        private static PokemonInfoAPI NewMethod(string url)
        {
            PokemonInfoAPI api;

            using (var client = new HttpClient())
            {
                string JsonData = client.GetStringAsync(url).Result;
                api = JsonConvert.DeserializeObject<PokemonInfoAPI>(JsonData);
            }

            return api;
        }

        private void ChangeSprite_Click(object sender, RoutedEventArgs e)
        {
            string ButtonContent = ChangeSprite.Content.ToString().ToLower();
            PokemonInfoAPI api;
            string url = PokemonSelected.url;
            PokemonInfoAPI picture = NewMethod(url);
            switch (ButtonContent)
            {
                case "change to back sprite":
                    PokemonImage.Source = new BitmapImage(new Uri(picture.sprites.front_default));
                    ChangeSprite.Content = "change to front sprite";
                    break;
                case "change to front sprite":
                    PokemonImage.Source = new BitmapImage(new Uri(picture.sprites.back_default));
                    ChangeSprite.Content = "change to back sprite";
                    break;
            }
        }
    }
}
