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

namespace RickAndMorty2
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            //SetUpWindow();
        }

        public void SetUpWindow(Results SelectedCharacter)
        {
            Results api = SelectedCharacter;


            NameBox.Text = SelectedCharacter.name.ToString();
            //StatusBox.Text = SelectedCharacter.status.ToString();
            //ImageBox.Source = new BitmapImage(new Uri(SelectedCharacter.image));
        }
    }
}
