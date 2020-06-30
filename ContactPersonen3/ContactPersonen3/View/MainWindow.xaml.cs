using ContactPersonen3.Data;
using ContactPersonen3.Model;
using ContactPersonen3.View.DialogWindows;
using ContactPersonen3.ViewModel;
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

namespace ContactPersonen3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ContactViewModel vm = new ContactViewModel();

        public MainWindow()
        {
            #region Creation of dummy contacts (hardcoded)

            Person persoon1 = new Person();
            Person persoon2 = new Person();
            Company bedrijf1 = new Company();
            Company bedrijf2 = new Company();

            persoon1.Name = "Fred";
            persoon1.LastName = "Flintstone";
            persoon1.Phonenumber = "+32 345 56 56";
            persoon1.Remark = "Bekend van Televisie. Verhuisde van Bedrock naar Antwerpen";
            persoon1.Address.City = "Antwerpen";
            persoon1.Address.HouseNumber = 50;
            persoon1.Address.PostalCode = "2000";
            persoon1.Address.Street = "Fopstraat";

            persoon2.Name = "Homer";
            persoon2.LastName = "Simpson";
            persoon2.Phonenumber = "+75 156 65658";
            persoon2.Remark = "Vader van Bart, Lisa en Maggie";
            persoon2.Address.City = "Springfield";
            persoon2.Address.HouseNumber = 742;
            persoon2.Address.PostalCode = "US 65801";
            persoon2.Address.Street = "Evergreen Terrace";

            bedrijf1.Name = "Badsoft inc";
            bedrijf1.Phonenumber = "+45 489 489 654";
            bedrijf1.Address.City = "Dorpstad";
            bedrijf1.Address.HouseNumber = 48;
            bedrijf1.Address.PostalCode = "7550";
            bedrijf1.Address.Street = "Straatlaan";
            bedrijf1.ClosingHour = bedrijf1.ClosingHour.AddHours(17);
            bedrijf1.ClosingHour = bedrijf1.ClosingHour.AddMinutes(30);
            bedrijf1.OpeningHour = bedrijf1.OpeningHour.AddHours(8);
            bedrijf1.Remark = "Dit is het eerste bedrijf dat toegevoegd werd aan de lijst.";
            bedrijf1.Closingdays.Add(Daysinweek.Saturday);
            bedrijf1.Closingdays.Add(Daysinweek.Sunday);

            bedrijf2.Name = "Café De Smoutpot";
            bedrijf2.Phonenumber = "+32 485 96 24 72";
            bedrijf2.Address.City = "Zwijndrecht";
            bedrijf2.Address.HouseNumber = 50;
            bedrijf2.Address.PostalCode = "2070";
            bedrijf2.Address.Street = "Smoutpot";
            bedrijf2.ClosingHour = bedrijf2.ClosingHour.AddHours(1);
            bedrijf2.OpeningHour = bedrijf2.OpeningHour.AddHours(16);
            bedrijf2.Remark = "Het beste café van Zwijndrecht!";
            bedrijf2.Closingdays.Add(Daysinweek.Monday);
            bedrijf2.Closingdays.Add(Daysinweek.Tuesday);
            bedrijf2.Closingdays.Add(Daysinweek.Wednesday);

            vm.Contacts.Add(persoon1);
            vm.Contacts.Add(persoon2);
            vm.Contacts.Add(bedrijf1);
            vm.Contacts.Add(bedrijf2);
            #endregion


            DataContext = vm;
            
            InitializeComponent();
            DataGridContacts.ItemsSource = vm.Contacts;
            

        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            AddPersonWindow addPersonWindow = new AddPersonWindow(vm);
            addPersonWindow.ShowDialog();
        }
        private void AddCompany_Click(object sender, RoutedEventArgs e)
        {
            AddCompanyWindow addCompanyWindow = new AddCompanyWindow(vm);
            addCompanyWindow.ShowDialog();
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            if (vm.CurrentContact != null)
            {
                string currentContactType = vm.CurrentContact.GetType().ToString();
                if (currentContactType == "ContactPersonen3.Data.Person")
                {
                    ShowPersonWindow showPerson = new ShowPersonWindow((Person)vm.CurrentContact);
                    showPerson.ShowDialog();
                }
                if (currentContactType == "ContactPersonen3.Data.Company")
                {
                    ShowCompanyWindow showCompany = new ShowCompanyWindow((Company)vm.CurrentContact);
                    showCompany.ShowDialog();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (vm.CurrentContact != null)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete contact: {vm.CurrentContact.Name}", "Delete contact", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.OK)
                {
                    vm.Contacts.Remove(vm.CurrentContact);
                    DataGridContacts.ItemsSource = vm.Contacts;
                    txtSearch.Text = ""; 
                }
            }

        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            var filterName = vm.Contacts.Where(t => t.Name.ToLower().Contains(txtSearch.Text));
            var filterPhone = vm.Contacts.Where(t => t.Phonenumber.Contains(txtSearch.Text));
            var filter = filterName.Concat(filterPhone);
            var distinctfilter = filter.Distinct();
            DataGridContacts.ItemsSource = distinctfilter;
        }
    }
}
