using System;
using System.Collections.Generic;
using System.Text;

namespace ContactPersonen3.Data
{
    public abstract class Contact
    {
        public Guid GUID { get; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phonenumber { get; set; }
        public string Remark { get; set; }
        public Contact()
        {
            this.GUID = Guid.NewGuid();
            this.Address = new Address();
        }

    }
}
