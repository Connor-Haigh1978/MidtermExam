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

namespace Homework32
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<SacData> Data = new List<SacData>();
        public MainWindow()
        {
            InitializeComponent();

            //street
            //city
            //zip
            //state
            //beds
            //baths
            //sq__ft
            //type
            //sale_date
            //price
            //latitude
            //longitude
        }
        
        private void GetDataButton_Click(object sender, RoutedEventArgs e)
        {
            var Lines = File.ReadAllLines("Sacramentorealestatetransactions.csv");
            string street = "";
            string city = "";
            string zip = "";
            string state = "";
            string beds = "";
            string baths = "";
            double sq__ft = 0;
            string type = "";
            string sale_date = "";
            double price = 0;
            string latitude = "";
            string longitude = "";
            
            for (int i = 1; i < Lines.Length; i++)
            {
                //SacData NewData = new SacData();

                var line = Lines[i];
                var peices = line.Split(',');
                street = peices[0];

                city = peices[1];
                zip = peices[2];
                state = peices[3];
                beds = peices[4];
                baths = peices[5];
                if (double.TryParse(peices[6], out sq__ft) == false)
                {
                    continue;
                }
                type = peices[7];
                sale_date = peices[8];
                if (double.TryParse(peices[9], out price) == false)
                {
                    continue;
                }
                latitude = peices[10];
                longitude = peices[11];

                //new SacData
                //{
                //    street = street,
                //    city = city,
                //    zip = zip,
                //    state = state,
                //    beds = beds,
                //    baths = baths,
                //    sq__ft = sq__ft,
                //    type = type,
                //    sale_date = sale_date,
                //    price = price,
                //    latitude = latitude,
                //    longitude = longitude
                //};

                Data.Add(new SacData
                {
                    street = street,
                    city = city,
                    zip = zip,
                    state = state,
                    beds = beds,
                    baths = baths,
                    sq__ft = sq__ft,
                    type = type,
                    sale_date = sale_date,
                    price = price,
                    latitude = latitude,
                    longitude = longitude
                });
            }
            foreach (SacData item in Data)
            {
                SacListBox.Items.Add($"{item.street.ToString()} {item.zip.ToString()}");
            }
            FilterForZipCode(Data);
            MostExpensive(Data);
            BiggestHouse(Data);
        }

        private void BiggestHouse(List<SacData> data)
        {
            int largest = 0;
            string street = "";

            foreach (SacData item in data)
            {
                if (item.sq__ft > largest)
                {
                    largest = Convert.ToInt32(item.sq__ft);
                    street = item.street.ToString();
                }
            }
            BiggestList.Items.Add($"{largest.ToString()} {street}");

        }

        private void MostExpensive(List<SacData> data)
        {
            int expensive = 0;
            string street = "";
            foreach (SacData house in data)
            {
                if (house.price > expensive)
                {
                    expensive = Convert.ToInt32(house.price);
                    street = house.street.ToString();
                }
            }
            ExpensiveList.Items.Add($"{expensive.ToString("C")}, {street}");
        }

        private void FilterForZipCode(List<SacData> data)
        {
            ZipCombo.Items.Add("All");

            ZipCombo.SelectedIndex = 0;

            foreach (SacData zip in data)
            {
                if (!ZipCombo.Items.Contains(zip.zip.ToString()))
                {
                    ZipCombo.Items.Add(zip.zip.ToString());
                }
            }
            
        }

        private void ZipCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SacListBox.Items.Clear();
            List<SacData> UpDatedList = new List<SacData>();
            string SlectedItem = ZipCombo.SelectedItem.ToString();
            if (SlectedItem == "All")
            {
                foreach (SacData entry in Data)
                {
                    SacListBox.Items.Add($"{entry.street.ToString()} {entry.zip.ToString()}");
                    UpDatedList.Add(entry);
                }
            }
            else
            {
                foreach (SacData item in Data)
                {

                    if (item.zip.ToString() == SlectedItem)
                    {
                        SacListBox.Items.Add($"{item.street}, {item.zip}");
                        UpDatedList.Add(item);
                    }
                }
            }
            
            ExpensiveList.Items.Clear();
            BiggestList.Items.Clear();
            MostExpensive(UpDatedList);
            BiggestHouse(UpDatedList);
        }
    }
}
