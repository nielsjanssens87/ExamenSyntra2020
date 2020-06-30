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
    /// Interaction logic for ShowCompanyWindow.xaml
    /// </summary>
    public partial class ShowCompanyWindow : Window
    {
        public Company CurrentCompany { get; set; }
        public Address CPAddress { get; set; }
        public ShowCompanyWindow(Company company)
        {
            CurrentCompany = company;
            CPAddress = company.Address;
            InitializeComponent();
            lblName.Content = CurrentCompany.Name;
            lblPhonenumber.Content = CurrentCompany.Phonenumber;
            lblStreetHousenumber.Content = CPAddress.Street + " " + CPAddress.HouseNumber.ToString();
            lblPostalcodeCity.Content = CPAddress.PostalCode + ", " + CPAddress.City;
            lstClosingDays.ItemsSource = CurrentCompany.Closingdays;
            lblOpeninghour.Content = CurrentCompany.OpeningHour;
            lblClosinghour.Content = CurrentCompany.ClosingHour;
            tbRemark.Text = CurrentCompany.Remark;
        }
    }
}
