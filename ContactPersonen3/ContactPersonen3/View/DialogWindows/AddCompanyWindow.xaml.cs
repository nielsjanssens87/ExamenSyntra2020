using ContactPersonen3.Data;
using ContactPersonen3.Model;
using ContactPersonen3.ViewModel;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddCompanyWindow.xaml
    /// </summary>
    public partial class AddCompanyWindow : Window
    {
        public ContactViewModel CVM { get; set; }
        public AddCompanyWindow(ContactViewModel vm)
        {
            CVM = vm;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DateTime currentOpeninghour = new DateTime();
            DateTime currentClosinghour = new DateTime();
            currentOpeninghour = currentOpeninghour.AddHours(Convert.ToDouble(txtOpeninghour.Text));
            currentOpeninghour = currentOpeninghour.AddMinutes(Convert.ToDouble(txtOpeningminutes.Text));
            currentClosinghour = currentClosinghour.AddHours(Convert.ToDouble(txtClosinghour.Text));
            currentClosinghour = currentClosinghour.AddMinutes(Convert.ToDouble(txtClosingminutes.Text));

            Company company = new Company();
            Address address = new Address();
            company.Name = txtName.Text;
            company.Phonenumber = txtPhonenumber.Text;
            address.Street = txtStreet.Text;
            if (int.TryParse(txtHouseNumber.Text, out int result))
            {
                address.HouseNumber = result;
            }
            address.PostalCode = txtPostalCode.Text;
            address.City = txtCity.Text;
            company.Address = address;
            company.Remark = txtRemarks.Text;
            CVM.Contacts.Add(company);
            bool noneChecked = true;
            if (chkMonday.IsChecked.Value)
            {
                company.Closingdays.Add(Daysinweek.Monday);
                noneChecked = false;
            }
            if (chkTuesday.IsChecked.Value)
            {
                company.Closingdays.Add(Daysinweek.Tuesday);
                noneChecked = false;
            }
            if (chkWednesday.IsChecked.Value)
            {
                company.Closingdays.Add(Daysinweek.Wednesday);
                noneChecked = false;
            }
            if (chkThursday.IsChecked.Value)
            {
                company.Closingdays.Add(Daysinweek.Thursday);
                noneChecked = false;
            }
            if (chkFriday.IsChecked.Value)
            {
                company.Closingdays.Add(Daysinweek.Friday);
                noneChecked = false;
            }
            if (chkSaturday.IsChecked.Value)
            {
                company.Closingdays.Add(Daysinweek.Saturday);
                noneChecked = false;
            }
            if (chkSunday.IsChecked.Value)
            {
                company.Closingdays.Add(Daysinweek.Sunday);
                noneChecked = false;
            }
            if (noneChecked)
            {
                company.Closingdays.Add(Daysinweek.none);
            }
            company.OpeningHour = currentOpeninghour;
            company.ClosingHour = currentClosinghour;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
