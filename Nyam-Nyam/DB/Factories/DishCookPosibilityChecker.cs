using Nyam_Nyam.DB;
using Nyam_Nyam.DB.Factories;
using System.Collections.Generic;
using System.Linq;

namespace Nyam_Nyam.DB
{
    public static class DishCookPosibilityChecker
    {
        public static bool IsPossibleToCook(Dish dish)
        {
            if (dish == null)
            {
                return false;
            }

            IEnumerable<ExtendedIngredient> ingredients = IngredientToIngredientWithAvailabilityConverter
                .ConvertDishIngredientsToIngredientsWithAvailability(dish, 1);

            bool isPossibleToCook = ingredients.All(i => i.IsAvailable);
            return isPossibleToCook;
        }
    }
}
