using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Nyam_Nyam.Service
{
    public class IngredientToColorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int requiredIngredients = 1000;
            int availableIngredients = (int)value;

            if (availableIngredients >= requiredIngredients)
            {
                return Brushes.Green; // Зеленый цвет
            }
            else
            {
                return Brushes.Red; // Красный цвет
            }

        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
