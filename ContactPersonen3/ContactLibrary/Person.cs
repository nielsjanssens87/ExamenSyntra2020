using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ContactPersonen3.Data
{
    public class Person : Contact
    {
        public string LastName { get; set; }
        public BitmapImage ProfilePicture { get; set; }
        public Person()
        {
            ProfilePicture = new BitmapImage(new Uri(@"Images\ProfilePics\ProfilePicInit.jpg", UriKind.Relative));
        }
    }
}
