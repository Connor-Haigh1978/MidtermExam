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

namespace GraduationHandout
{
    /// <summary>
    /// Interaction logic for ShowAddress.xaml
    /// </summary>
    public partial class ShowAddress : Window
    {
        public ShowAddress()
        {
            InitializeComponent();
        }

        public void SetupStudent(Student student)
        {
            FirstnameLastname.Text = $"{student.FirstName} {student.LastName}";
        }

        public void ShowAddressBox(Address address)
        {
            AddressBox.Text = address.ToString();

        }
    }
}
