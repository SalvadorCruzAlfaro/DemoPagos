using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ExPagos.DTOs;
using Xamarin.Forms;

namespace Expagos.Converters
{
    public class MontoUSDConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PAGO pago = value as PAGO;
            if (pago != null)
                return pago.Monto * 21;
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
