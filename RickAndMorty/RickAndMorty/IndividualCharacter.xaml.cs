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

namespace RickAndMorty
{
    /// <summary>
    /// Interaction logic for IndividualCharacter.xaml
    /// </summary>
    
    
    public partial class IndividualCharacter : Window
    {


        public IndividualCharacter()
        {
            InitializeComponent();

        }

        public void SetUpWindow(Results SelectedCharacter)
        {
            NameBox.Text = SelectedCharacter.name;
            StatusBox.Text = SelectedCharacter.status;
            Photo.Source = new BitmapImage(new Uri(SelectedCharacter.image));
        }
    }
}
