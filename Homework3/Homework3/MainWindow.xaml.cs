using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<TVShow> TvShows = new List<TVShow>();
        public char[] CharctersToTrim = { ',', ' ', '"' };
        public MainWindow()
        {
            InitializeComponent();

            var lines = File.ReadAllLines("TV Show Data.txt").Skip(1);

            foreach (var line in lines)
            {
                TvShows.Add(new TVShow(line));
            }

            PopulateListBox();
            PopulateCountryFilter();
            PopulateRatingFilter();
            PopulateLanguageFilter();
        }

        private void PopulateLanguageFilter()
        {
            LanguageBox.Items.Add("All");

            LanguageBox.SelectedIndex = 0;

            foreach (var show in TvShows)
            {

                var value = show.Language.Split(',');

                foreach (var item in value)
                {
                    if (string.IsNullOrEmpty(item) == true)
                    {
                        continue;
                    }

                    string cleanedvalue = item.Trim(CharctersToTrim);
                    if (!LanguageBox.Items.Contains(cleanedvalue))
                    {
                        LanguageBox.Items.Add(cleanedvalue);
                    }
                }

            }
        }

        private void PopulateRatingFilter()
        {
            RatingBox.Items.Add("All");

            RatingBox.SelectedIndex = 0;

            foreach (var show in TvShows)
            {

                var value = show.Rated.Split(',');

                foreach (var item in value)
                {
                    if (string.IsNullOrEmpty(item) == true)
                    {
                        continue;
                    }

                    string cleanedvalue = item.Trim(CharctersToTrim);
                    if (!RatingBox.Items.Contains(cleanedvalue))
                    {
                        RatingBox.Items.Add(cleanedvalue);
                    }
                }

            }
        }

        private void PopulateCountryFilter()
        {
            CountryBox.Items.Add("All");

            CountryBox.SelectedIndex = 0;

            foreach (var show in TvShows)
            {

                var value = show.Country.Split(',');

                foreach (var item in value)
                {
                    if (string.IsNullOrEmpty(item) == true)
                    {
                        continue;
                    }

                    string cleanedvalue = item.Trim(CharctersToTrim);
                    if (!CountryBox.Items.Contains(cleanedvalue))
                    {
                        CountryBox.Items.Add(cleanedvalue);
                    }
                }
                
            }
        }

        private void PopulateListBox()
        {
            TVShowListBox.Items.Clear();

            foreach (var show in TvShows)
            {
                TVShowListBox.Items.Add(show);
            }
        }

        private void RatingBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilter();   
        }

        private void UpdateFilter()
        {
            if (RatingBox.SelectedItem is null || CountryBox.SelectedItem is null || LanguageBox.SelectedItem is null)
            {
                return;
            }

            List<TVShow> UpdatedTvShows;

            UpdatedTvShows = FilterRating(TvShows);
            UpdatedTvShows = FilterCountry(UpdatedTvShows);
            UpdatedTvShows = FilterLanguage(UpdatedTvShows);
            UpdateList(UpdatedTvShows);

        }

        private List<TVShow> FilterLanguage(List<TVShow> tvShows)
        {
            List<TVShow> LanguageShows = new List<TVShow>();

            foreach (var show in tvShows)
            {
                if (LanguageBox.SelectedItem.ToString() == "All")
                {
                    LanguageShows.Add(show);
                }
                if (show.Language.Contains(LanguageBox.SelectedItem.ToString().Trim()))
                {
                    LanguageShows.Add(show);
                }

            }

            return LanguageShows;
        }

        private void UpdateList(List<TVShow> updatedTvShows)
        {
            TVShowListBox.Items.Clear();
            foreach (var show in updatedTvShows)
            {
                TVShowListBox.Items.Add(show);
            }
        }

        private List<TVShow> FilterRating(List<TVShow> tvShows)
        {
            List<TVShow> RatingShows = new List<TVShow>();

            foreach (var show in tvShows)
            {
                if (RatingBox.SelectedItem.ToString() == "All")
                {
                    RatingShows.Add(show);
                }
                else if (RatingBox.SelectedItem.ToString() == show.Rated)
                {
                    RatingShows.Add(show);
                }

            }

            return RatingShows;
        }
        private List<TVShow> FilterCountry(List<TVShow> tvShows)
        {
            List<TVShow> CountryShows = new List<TVShow>();

            foreach (var show in tvShows)
            {
                if (CountryBox.SelectedItem.ToString() == "All")
                {
                    CountryShows.Add(show);
                }
                else if (show.Country.Contains(CountryBox.SelectedItem.ToString().Trim()))
                {
                    CountryShows.Add(show);
                }

            }

            return CountryShows;
        }

        private void CountryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilter();
        }

        private void LanguageBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFilter();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            TVShowListBox.Items.Clear();
            PopulateListBox();
            LanguageBox.SelectedIndex = 0;
            CountryBox.SelectedIndex = 0;
            RatingBox.SelectedIndex = 0;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedShow = (TVShow)TVShowListBox.SelectedItem;
            Poster wnd = new Poster();
            wnd.SetUpDialog(SelectedShow);
            wnd.Show();
        }
    }
}
