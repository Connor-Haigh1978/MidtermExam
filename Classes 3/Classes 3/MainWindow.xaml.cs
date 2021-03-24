using System;
using System.Collections.Generic;
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

namespace Classes_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitInfor_Click(object sender, RoutedEventArgs e)
        {


            bool Success; //used this soluton from the video
            if (string.IsNullOrWhiteSpace(FirstNameBox.Text) == true)
            {
                Success = false;
                MessageBox.Show("Enter valid First Name");
            }
            if (string.IsNullOrWhiteSpace(LastNameBox.Text) == true)
            {
                Success = false;
                MessageBox.Show("Enter valid Last Name");
            }
            if (string.IsNullOrWhiteSpace(MajorBox.Text) == true)
            {
                Success = false;
                MessageBox.Show("Enter valid Major");
            }
            double GPA;
            if (double.TryParse(GPABox.Text, out GPA) == false)
            {
                Success = false;
                MessageBox.Show("Enter valid GPA");
            }
            int Zip;
            if (int.TryParse(ZipcodeBox.Text, out Zip) == false)
            {
                Success = false;
                MessageBox.Show("Enter valid Zip Code");
            }
            //

            if (string.IsNullOrWhiteSpace(streetNameBox.Text) == true)
            {
                Success = false;
                MessageBox.Show("Enter valid Street Name");
            }
            if (string.IsNullOrWhiteSpace(cityBox.Text) == true)
            {
                Success = false;
                MessageBox.Show("Enter valid City ");
            }
            if (string.IsNullOrWhiteSpace(stateBox.Text) == true)
            {
                Success = false;
                MessageBox.Show("Enter valid State");
            }
            int streetnumber;
            if (int.TryParse(streetNumberBox.Text, out streetnumber) == false)
            {
                Success = false;
                MessageBox.Show("Enter a valid Street Number");
            }
            if (Success = false)
            {
                return;
            }

            Student student = new Student()
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                GPA = GPA,
                Major = MajorBox.Text
            };

            student.SetAddress(streetnumber, streetNameBox.Text, stateBox.Text, cityBox.Text, Zip);
            StudentListBox.Items.Add(student);
        }   

        private bool CheckInputDouble(TextBox gPABox)
        {
            double reponse = 0;
            bool success = true;
            if (string.IsNullOrEmpty(gPABox.Text) == false)
            {
                double.TryParse(gPABox.Text, out reponse);
                success = true;
            }
            else
            {
                MessageBox.Show($"{gPABox.Name} does not have a valid input");
                success = false;
            }
            //if (success = false)
            //{
            //    break;
            //}
            return success;
        }

        public bool CheckForInputString(TextBox textBox)
        {
            string response = " ";
            bool success;
            if (string.IsNullOrEmpty(textBox.Text) == false)
            {
                response = textBox.Text;
                success = true;
            }
            else
            {
                MessageBox.Show($"{textBox.Name} text is not filled", "enter valid response");
                success = false;
            }
            return success;
        }

        public void StudentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedStudent wnd = new SelectedStudent();
            var SelectedStudent = (Student)StudentListBox.SelectedItem;
            wnd.SetUpWindow(SelectedStudent);
            wnd.ShowDialog();
        }
    }
}
