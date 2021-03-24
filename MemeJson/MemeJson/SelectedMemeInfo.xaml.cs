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

namespace MemeJson
{
    /// <summary>
    /// Interaction logic for SelectedMemeInfo.xaml
    /// </summary>
    public partial class SelectedMemeInfo : Window
    {
        public SelectedMemeInfo()
        {
            InitializeComponent();
        }

        internal void ShowInfo(IndividualInfo selecedItem)
        {
            imagebox.Source = new BitmapImage(new Uri(selecedItem.url));
            NameBox.Text = selecedItem.name;
        }
    }
}
