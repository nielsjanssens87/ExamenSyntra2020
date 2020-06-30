using ContactPersonen3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactPersonen3.Data
{
    public class Company : Contact
    {

        private List<Daysinweek> closingdays;

        public List<Daysinweek> Closingdays
        {
            get { return closingdays; }
            set 
            {
                closingdays = value;
            }
        }
        
        public DateTime OpeningHour { get; set; }
        public DateTime ClosingHour { get; set; }

        public Company()
        {
            

            Closingdays = new List<Daysinweek>();
            OpeningHour = new DateTime();
            ClosingHour = new DateTime();
        }

        
    }
}
