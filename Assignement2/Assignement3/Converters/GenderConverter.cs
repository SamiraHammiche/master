using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;


namespace Assignement3.Converters
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string malePath = "/Images/male.JPG";
            string femalePath = "/Images/female.JPG";
           
            switch (value.ToString().ToLower())
            {
                case "male":
                    Uri imageUri = new Uri(malePath, UriKind.Relative);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    return imageBitmap;
                case "female":
                    Uri imageUri2 = new Uri(femalePath, UriKind.Relative);
                    BitmapImage imageBitmap2 = new BitmapImage(imageUri2);
                    return imageBitmap2;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
