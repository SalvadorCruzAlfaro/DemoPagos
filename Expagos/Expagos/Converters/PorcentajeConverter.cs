using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ExPagos.DTOs;
using Xamarin.Forms;

namespace Expagos.Converters
{
    public class PorcentajeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PAGO pago = value as PAGO;
            double porcentaje = 0;
            if (pago != null)
                porcentaje= ((double)pago.IdClienteNavigation.Comision) / 100;
            return porcentaje;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
