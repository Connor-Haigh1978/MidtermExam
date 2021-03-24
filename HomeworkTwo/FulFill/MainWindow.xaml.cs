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

namespace FulFill
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
        Dictionary<string, List<StateClass>> DictionaryStates = new Dictionary<string, List<StateClass>>();
        List<StateClass> stateClasses = new List<StateClass>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void GetData(string fileName)
        {
            var lines = File.ReadAllLines(fileName);

            string OutputState = " ";

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var peices = line.Split(',');

                
                string gender = peices[1];
                int n;
                double mean;

                if (string.IsNullOrEmpty(peices[0]) == false)
                {
                    OutputState = peices[0];
                }
                if (int.TryParse(peices[3], out n) == false)
                {
                    continue;
                }
                if (double.TryParse(peices[2], out mean) == false)
                {
                    continue;
                }
                //if (string.IsNullOrEmpty(peices[0]) == true)
                //{
                //    var states = lines[i - 1];
                //    var FinalState = states.Split(',');
                //    OutputState = FinalState[0];
                //    if (string.IsNullOrEmpty(OutputState))
                //    {
                //        states = lines[i - 2];
                //        FinalState = states.Split(',');
                //        OutputState = FinalState[0];
                //        if (string.IsNullOrEmpty(OutputState))
                //        {
                //            states = lines[1 - 3];
                //            FinalState = states.Split(',');
                //            OutputState = FinalState[0];
                //        }
                //    }
                //}
                if (DictionaryStates.ContainsKey(OutputState) == false)
                {
                    DictionaryStates.Add(OutputState, new List<StateClass>());
                }
                DictionaryStates[OutputState].Add(new StateClass() { state = OutputState, gender = gender, mean = mean, n = n });


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads"; //This will get the path to their downloads directory,

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Comma Sperated Value documents (.csv) |*.csv";

            if (ofd.ShowDialog() == true)
            {
                GetData(ofd.FileName);
            }

            PopulateData("Male", LineListBox);
            PopulateData("Female", LineListBox);
            PopulateData("Both", LineListBox);
            PopulateMost("Male", MostMale);
            PopulateMost("Female", MostFemale);
            PopulateMost("Both", MostBoth);
            Populate8OrMore();
        }

        private void Populate8OrMore()
        {
            int eight = 8;

            List<string> States = new List<string>();

            foreach (var state in DictionaryStates.Keys)
            {
                foreach (StateClass mean in DictionaryStates[state])
                {
                    if (mean.mean > 8)
                    {
                        //StatesWith8Greater.Items.Add(mean.state);
                        if (States.Contains(mean.state) == false)
                        {
                            States.Add(mean.state);
                        }
                    }
                }
            }
            foreach (var item in States)
            {
                StatesWith8Greater.Items.Add(item);
            }

        }

        private void PopulateMost(string v, ListBox mostMale)
        {
            double MaxMean = 0;
            string State = " ";
            string Gender = " ";

            foreach (var state in DictionaryStates.Keys)
            {
                foreach (StateClass mean in DictionaryStates[state])
                {
                    if (mean.gender == v)
                    {
                        if (mean.mean > MaxMean)
                        {
                            MaxMean = mean.mean;
                        }
                    }

                }
            }
            foreach (var state in DictionaryStates.Keys)
            {
                foreach (StateClass mean in DictionaryStates[state])
                {
                    if (mean.gender == v)
                    {
                        if (mean.mean == MaxMean)
                        {
                            State = mean.state;
                            Gender = mean.gender;
                        }
                    }

                }
            }
            mostMale.Items.Add($"{State}, {Gender}");

            
        }

        private void PopulateData(string v, ListBox lineListBox)
        {
            foreach (var state in DictionaryStates.Keys)
            {
                foreach (StateClass item in DictionaryStates[state])
                {
                    if (item.gender == v)
                    {
                        lineListBox.Items.Add($"{state}, {item.mean.ToString()}, {item.gender.ToString()}");
                    }
                }
            }
        }
    }
}
