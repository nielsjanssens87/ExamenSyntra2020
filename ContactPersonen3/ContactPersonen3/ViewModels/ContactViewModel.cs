using ContactPersonen3.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ContactPersonen3.ViewModel
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contact> contacts;

        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; RaisePropertyChanged("Contacts"); }
        }

        private Contact currentContact;

        public Contact CurrentContact
        {
            get { return currentContact; }
            set 
            { 
                currentContact = value;
                RaisePropertyChanged("CurrentContact");
            }
        }

        public ContactViewModel()
        {
            this.Contacts = new ObservableCollection<Contact>();
        }
        private void RaisePropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        static public bool CheckOpeningHours(DateTime openinghour, DateTime closinghour)
        {
            bool check = false;
            TimeSpan timeSpan = closinghour - openinghour;
            if (timeSpan.Ticks > 0)
            {
                check = true;
            }
            else 
            {
                check = false;
            }
            return check;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
