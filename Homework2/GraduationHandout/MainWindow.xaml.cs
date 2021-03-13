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

namespace GraduationHandout
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

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {


            CreateStudent();
            CreateAddress();
            //Dictionary<Student, Address> StudentDictionary = new Dictionary<Student, Address>();
            //StudentDictionary.Add(CreateStudent(), CreateAddress());

        }

        private Address CreateAddress()
        {
            Address NewAddress = new Address();

            int.TryParse(StreetNumberBox.Text, out int StreetNumber);
            NewAddress.StreetNumber = StreetNumber;
            NewAddress.StreetName = StreetNameBox.Text;
            NewAddress.State = StateBox.Text;
            NewAddress.City = CityBox.Text;
            int.TryParse(ZipCodeBox.Text, out int ZipCode);
            NewAddress.ZipCode = ZipCode;

            StreetNumberBox.Clear();
            StreetNameBox.Clear();
            StateBox.Clear();
            CityBox.Clear();
            ZipCodeBox.Clear();

            return NewAddress;

        }

        public Student CreateStudent()
        {
            Student NewStudent = new Student();

            NewStudent.FirstName = FirstNameBox.Text;
            NewStudent.LastName = LastNameBox.Text;
            double.TryParse(GPABox.Text, out double GPA);
            NewStudent.GPA = GPA;
            NewStudent.Major = MajorBox.Text;

            StudentListBox.Items.Add(NewStudent.ToString());

            FirstNameBox.Clear();
            LastNameBox.Clear();
            GPABox.Clear();
            MajorBox.Clear();

            return NewStudent;
        }

        private void StudentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedStudent = (Student)StudentListBox.SelectedItem;
            ShowAddress address = new ShowAddress();
            Address NewAddress = new Address();
            NewAddress = SelectedStudent.Address;
            address.SetupStudent(SelectedStudent);
            address.ShowAddressBox(NewAddress);
            address.Show();
        }
    }
}
