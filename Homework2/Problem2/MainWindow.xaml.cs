using Microsoft.Win32;
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

namespace Problem2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<FulFillData>> Data = new Dictionary<string, List<FulFillData>>();
        public MainWindow()
        {
            InitializeComponent();

            //Load in data
            //Add in data to dictionary -- If the state is already contained, add new list. -- 
            //Sort data
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            //MostFulfilled("Male", MaleListBox);
            //MostFulfilled("Female", FemaleListBox);
            //MostFulfilled("Both", BothListBox);
            MostFulfilledMale();
            MostFulfilledFemale();
            MostFulfilledBoth();
            GreaterThan8List();
            //AddFemaleMean();

            //foreach (var item in Data)
            //{
            //    ListBox.Items.Add(item);
            //}
        }

        private void GreaterThan8List()
        {
            foreach (var state in Data.Keys)
            {
                foreach (var instance in Data[state])
                {
                    if (instance.Mean > 8 || instance.Mean == 8)
                    {
                        GreaterThan8ListBox.Items.Add(instance.State);
                        break;
                    }
                }
            }
        }

        private void AddFemaleMean()
        {
            foreach ( var state in Data.Keys)
            {
                foreach ( var instance in Data[state])
                {
                    if (instance.Gender.ToLower() == "female")
                    {
                        FemaleListBox.Items.Add(instance.State);
                    }
                }
            }
        }

        private void MostFulfilledBoth()
        {
            double MaxMean = 0;
            foreach (var state in Data.Keys)
            {
                foreach (var instance in Data[state])
                {
                    if (instance.Gender.ToLower().Trim() == "both")
                    {
                        if (instance.Mean > MaxMean)
                        {
                            MaxMean = instance.Mean;
                        }
                    }
                }
            }
            foreach (var state in Data.Keys)
            {
                foreach (var instance in Data[state])
                {
                    if (instance.Gender.ToLower().Trim() == "both")
                    {
                        if (instance.Mean == MaxMean)
                        {
                            BothListBox.Items.Add(instance.State);
                        }
                    }
                }
            }
        }

        private void MostFulfilledFemale()
        {
            double MaxMean = 0;
            foreach (var state in Data.Keys)
            {
                foreach (var instance in Data[state])
                {
                    if (instance.Gender.ToLower().Trim() == "female")
                    {
                        if (instance.Mean > MaxMean)
                        {
                            MaxMean = instance.Mean;
                        }
                    }
                }
            }
            foreach (var state in Data.Keys)
            {
                foreach (var instance in Data[state])
                {
                    if (instance.Gender.ToLower().Trim() == "female")
                    {
                        if (instance.Mean == MaxMean)
                        {
                            FemaleListBox.Items.Add(instance.State);
                        }
                    }
                }
            }
        }

        private void MostFulfilledMale()
        {
            double MaxMean = 0;
            foreach (var state in Data.Keys)
            {
                foreach (var instance in Data[state])
                {
                    if (instance.Gender.ToLower().Trim() == "male")
                    {
                        if (instance.Mean > MaxMean)
                        {
                            MaxMean = instance.Mean;
                        }
                    }
                }
            }
            foreach (var state in Data.Keys)
            {
                foreach (var instance in Data[state])
                {
                    if (instance.Gender.ToLower().Trim() == "male")
                    {
                        if (instance.Mean == MaxMean)
                        {
                            MaleListBox.Items.Add(instance.State);
                        }
                    }
                }
            }
        }

        private void MostFulfilled(string gender, ListBox List)
        {
            double MaxMean = 0;
            foreach (var state in Data.Keys)
            {
                foreach (var gend in Data[state])
                {
                    if (gend.Gender == gender)
                    {
                        if (gend.Mean > MaxMean)
                        {
                            MaxMean = gend.Mean;

                        }
                    }
                }
            }
            foreach (var state in Data.Keys)
            {
                foreach (var gend in Data[state])
                {
                    if (MaxMean == gend.Mean)
                    {
                        List.Items.Add(gend.State);
                    }
                }
            }




        }


        private void LoadData()
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads";

            //List<string> States = new List<string>();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Comma Seperated Value documents (.csv)|*.csv";

            if (ofd.ShowDialog() == true)
            {
                var lines = File.ReadAllLines(ofd.FileName);
                string state = " ";
                foreach (var line in lines)
                {
                    var peices = line.Split(',');
                    

                    if (string.IsNullOrWhiteSpace(peices[0]) == false)
                    {
                        state = peices[0];
                    }
                    double mean;
                    int n;
                    if (double.TryParse(peices[2], out mean) == false)
                    {
                        continue;
                    }
                    if (int.TryParse(peices[3], out n) == false)
                    {
                        continue;
                    }

                    if (Data.ContainsKey(peices[0]) == false)
                    {
                        Data.Add(peices[0], new List<FulFillData>());
                        Data[peices[0]].Add(new FulFillData()
                        {
                            State = state,
                            Gender = peices[1],
                            Mean = mean,
                            N = n

                        }
 );

                    }
                    if (Data.ContainsKey(peices[0]) == true)
                    {
                        Data[peices[0]].Add(new FulFillData()
                        {
                            State = state,
                            Gender = peices[1],
                            Mean = mean,
                            N = n

                        }
                         );
                    }

                }



            }
        }
    }
}
