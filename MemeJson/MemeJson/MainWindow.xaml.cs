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

namespace MemeJson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = "https://api.imgflip.com/get_memes";

            //info api;

            List<string> ListMemes = new List<string>();

            using (var client = new HttpClient())
            {
                var JsonData = client.GetStringAsync(url).Result;

                info api = JsonConvert.DeserializeObject<info>(JsonData);

                //ListMemes.Add(api.memes.ToString());
                foreach (var item in api.data.memes.OrderBy(x => x.name ).ToList())
                {
                    MemeList.Items.Add(item);
                }
            }

        }

        private void MemeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelecedItem = (IndividualInfo)MemeList.SelectedItem;
            SelectedMemeInfo wnd = new SelectedMemeInfo();
            wnd.ShowInfo(SelecedItem);
            wnd.Show();
        }
    }
}
