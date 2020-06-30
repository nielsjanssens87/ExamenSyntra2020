using ContactPersonen3.Data;
using ContactPersonen3.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddPersonWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {
        Person person = new Person();
        Address address = new Address();
        public ContactViewModel CVM { get; set; }
        public AddPersonWindow(ContactViewModel vm)
        {
            CVM = vm;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            person.Name = txtFirstName.Text;
            person.LastName = txtLastName.Text;
            person.Phonenumber = txtPhonenumber.Text;
            address.Street = txtStreet.Text;
            if (int.TryParse(txtHouseNumber.Text, out int result))
            {
                address.HouseNumber = result;
            }
            address.PostalCode = txtPostalCode.Text;
            address.City = txtCity.Text;
            person.Address = address;
            person.Remark = txtRemarks.Text;
            CVM.Contacts.Add(person);
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChoosePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose a profile picture";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
        "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
                person.ProfilePicture = new BitmapImage(new Uri(openFileDialog.FileName));
        }
    }
}
