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

namespace Classes_3
{
    /// <summary>
    /// Interaction logic for SelectedStudent.xaml
    /// </summary>
    public partial class SelectedStudent : Window
    {
        public SelectedStudent()
        {
            InitializeComponent();
        }

        internal void SetUpWindow(Student selectedStudent)
        {
            FirstNameBox.Text = selectedStudent.FirstName;
            LastNameBox.Text = selectedStudent.LastName;
            GPABox.Text = selectedStudent.GPA.ToString();
            MajorBox.Text = selectedStudent.Major;

            streetNameBox.Text = selectedStudent.Address.StreetName;
            streetNumberBox.Text = selectedStudent.Address.StreetNumber.ToString();
            ZipcodeBox.Text = selectedStudent.Address.Zipcode.ToString();
            cityBox.Text = selectedStudent.Address.City;
            stateBox.Text = selectedStudent.Address.State;

        }
    }
}
