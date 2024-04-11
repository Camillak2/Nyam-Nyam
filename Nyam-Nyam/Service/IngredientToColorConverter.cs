using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyam_Nyam.Service
{
    public class IngredientToColorConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int requiredIngredients = 1000000;
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
