using ContactPersonen3.Data;
using ContactPersonen3.ViewModel;
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

namespace ContactPersonen3.View.DialogWindows
{
    /// <summary>
    /// Interaction logic for ShowPersonWindow.xaml
    /// </summary>
    public partial class ShowPersonWindow : Window
    {
        public Person CurrentPerson { get; set; }
        public Address CPAddress { get; set; }
        public ShowPersonWindow(Person person)
        {
            CurrentPerson = person;
            CPAddress = person.Address;

            InitializeComponent();
            lblName.Content = CurrentPerson.Name + " " + CurrentPerson.LastName; ;
            lblPhonenumber.Content = CurrentPerson.Phonenumber;
            lblStreetHousenumber.Content = CPAddress.Street + " " + CPAddress.HouseNumber.ToString();
            lblPostalcodeCity.Content = CPAddress.PostalCode + ", " + CPAddress.City;
            tbRemark.Text = CurrentPerson.Remark;

            imgProfilePic.Source = CurrentPerson.ProfilePicture;

        }

    }
}
