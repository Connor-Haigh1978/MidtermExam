using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Homework3
{
    /// <summary>
    /// Interaction logic for Poster.xaml
    /// </summary>
    public partial class Poster : Window
    {
        public Poster()
        {
            InitializeComponent();

        }

        public void SetUpDialog(TVShow SelectedShow)
        {
            TitleBox.Text = SelectedShow.Title;
            PlotBox.Text = SelectedShow.Plot;
            PosterBox.Source = new BitmapImage(new Uri(SelectedShow.Poster));
        }
    }
}
