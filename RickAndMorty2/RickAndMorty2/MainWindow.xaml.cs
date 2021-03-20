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

namespace RickAndMorty2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        static List<Results> CharacterResultList = new List<Results>();
        public MainWindow()
        {
            InitializeComponent();

            RickAndMortyAPI api;

            string url = "https://rickandmortyapi.com/api/character";

            //PopulateSpecies();

            using (var client = new HttpClient())
            {

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    while (!string.IsNullOrEmpty(url))
                    {
                        var JsonData = client.GetStringAsync(url).Result;

                        api = JsonConvert.DeserializeObject<RickAndMortyAPI>(JsonData);

                        foreach (Results Character in api.results.ToList())
                        {
                            

                            CharacterResultList.Add(Character);
                        }

                        url = api.info.next;
                    }
                    

                    FillStatusFilter(CharacterResultList);
                    FillGenderFilter(CharacterResultList);
                    FillSpeciesFilter(CharacterResultList);
                }

            }

        }

        private void FillSpeciesFilter(List<Results> characterResultList)
        {
            SpeciesBox.Items.Add("All");
            SpeciesBox.SelectedIndex = 0;

            foreach (Results Character in characterResultList)
            {
                if (!SpeciesBox.Items.Contains(Character.species))
                {
                    SpeciesBox.Items.Add(Character.species);
                }
            }
        }

        private void FillGenderFilter(List<Results> characterResultList)
        {
            GenderBox.Items.Add("All");
            GenderBox.SelectedIndex = 0;

            foreach (Results Character in characterResultList)
            {
                if (!GenderBox.Items.Contains(Character.gender))
                {
                    GenderBox.Items.Add(Character.gender);
                }
            }
        }

        private void FillStatusFilter(List<Results> characterResultList)
        {
            StatusBox.Items.Add("All");
            StatusBox.SelectedIndex = 0;
            
            foreach (Results Character in characterResultList)
            {
                if (!StatusBox.Items.Contains(Character.status))
                {
                    StatusBox.Items.Add(Character.status);
                }
            }
        }

        private void SpeciesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListBox();
        }
        private void GenderBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListBox();
        }

        private void StatusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            if (SpeciesBox.SelectedItem is null || GenderBox.SelectedItem is null || SpeciesBox.SelectedItem is null)
            {
                return;
            }
            
            
            List<Results> UpdatedData;

            UpdatedData = UpdateStatusFilter(CharacterResultList);
            UpdatedData = UpdateSpeciesFilter(UpdatedData);
            UpdatedData = UpdateGenderFilter(UpdatedData);

            ShowListBox(UpdatedData);

        }

        private List<Results> UpdateGenderFilter(List<Results> updatedData)
        {

            List<Results> UpdatedSpecies = new List<Results>();

            string SelectedSpecies = GenderBox.SelectedValue.ToString();

            foreach (Results character in updatedData)
            {
                if (SelectedSpecies == character.gender)
                {
                    UpdatedSpecies.Add(character);
                }
                if (SelectedSpecies == "All")
                {
                    UpdatedSpecies.Add(character);
                }
            }




            return UpdatedSpecies;
        }

        private List<Results> UpdateSpeciesFilter(List<Results> updatedData)
        {
            List<Results> UpdatedSpecies = new List<Results>();

            string SelectedSpecies = SpeciesBox.SelectedValue.ToString();

            foreach (Results character in updatedData)
            {
                if (SelectedSpecies == character.species)
                {
                    UpdatedSpecies.Add(character);
                }
                if (SelectedSpecies == "All")
                {
                    UpdatedSpecies.Add(character);
                }
            }
            

            
            
            return UpdatedSpecies;
        }

        private void ShowListBox(List<Results> updatedData)
        {
            CharacterList.Items.Clear();

            foreach (Results item in updatedData)
            {
                CharacterList.Items.Add(item);
            }
        }

        private List<Results> UpdateStatusFilter(List<Results> characterResultList)
        {
            List<Results> UpdatedList = new List<Results>();

            foreach (Results Character in characterResultList)
            {
                if (StatusBox.SelectedItem.ToString() == Character.status)
                {
                    UpdatedList.Add(Character);
                }
                else if(StatusBox.SelectedItem.ToString() == "All")
                {
                    UpdatedList.Add(Character);

                }
            }

            return UpdatedList;
        }

        private void CharacterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedCharacter = (Results)CharacterList.SelectedItem;
            SecondWindow wnd = new SecondWindow();
            wnd.SetUpWindow(SelectedCharacter);
        }
    }
}
