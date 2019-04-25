using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ExPagos.DTOs;
using Xamarin.Forms;

namespace Expagos.Converters
{
    public class ComisionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PAGO pago = value as PAGO;
            double comision = 0;
            if (pago != null)
            {
                double porcentaje = ((double)pago.IdClienteNavigation.Comision) / 100;
                comision = (double) (pago.Monto * (decimal) porcentaje);
            }
                
            return comision;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
