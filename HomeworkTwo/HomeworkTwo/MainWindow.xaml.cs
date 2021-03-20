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

namespace HomeworkTwo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Dictionary<string, List<FufillDataClass>> StateDictionary = new Dictionary<string, List<FufillDataClass>>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {

            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads"; //This will get the path to their downloads directory,

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = path;
            ofd.Filter = "Comma Sperated Value documents (.csv) |*.csv";

            if (ofd.ShowDialog() == true)
            {
                GetData(ofd.FileName);
            }
            
        }

        private void GetData(string path)
        {
            var lines = File.ReadAllLines(path);

            List<FufillDataClass> StateData = new List<FufillDataClass>();

            FufillDataClass NewDataEntry = new FufillDataClass();

            for (int i = 0; i < lines.Length; i++)
            {
               

                var line = lines[i];
                var peices = line.Split(',');

                string state = " ";
                //string gender = peices[1];
                int N;
                double Mean;

                if (int.TryParse(peices[3], out N) == false)
                {
                    continue;
                }
                if (double.TryParse(peices[2], out Mean) == false)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(peices[0]) == false)
                {
                    state = peices[0];
                }
                if (StateDictionary.Keys.Contains(state) == true)
                {
                    StateDictionary[state].Add(new FufillDataClass()
                    {
                        state = state,
                        gender = peices[1],
                        mean = Mean,
                        N = N

                    });
                }
                if (StateDictionary.Keys.Contains(state) == false)
                {
                    StateDictionary.Add(state, new List<FufillDataClass>());
                }
                StateDictionary[state].Add(new FufillDataClass()
                {
                    state = state,
                    gender = peices[1],
                    mean = Mean,
                    N = N

                });
            }
            foreach (var item in StateData)
            {
                StateList.Items.Add(item);
            }

        }
    }
}
