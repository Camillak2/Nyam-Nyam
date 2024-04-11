using Nyam_Nyam.DB;
using System.Collections.Generic;
using System.Linq;

namespace Nyam_Nyam.DB.Factories
{
    public static class IngredientToIngredientWithAvailabilityConverter
    {
        /// <summary>
        /// Converts dish ingredients to an ingredient with availability 
        /// representation with respect to servings count.
        /// </summary>
        /// <param name="dish">The dish whose ingredients will be converted.</param>
        /// <param name="servingsCount">The servings count of the given dish.</param>
        /// <returns></returns>
        public static IEnumerable<ExtendedIngredient>
           ConvertDishIngredientsToIngredientsWithAvailability(Dish dish,
                                                               int servingsCount)
        {
            List<CookingStage> dishStages = new List<CookingStage>();
            List<IngredientOfStage> stageIngredients = new List<IngredientOfStage>();
            List<Ingredient> ingredients = new List<Ingredient>();

            foreach (CookingStage dishStage in dish.CookingStage)
            {
                dishStages.Add(dishStage);
                foreach (IngredientOfStage stageIngredient in dishStage.IngredientOfStage)
                {
                    stageIngredients.Add(stageIngredient);
                    if (!ingredients.Contains(stageIngredient.Ingredient))
                    {
                        ingredients.Add(stageIngredient.Ingredient);
                    }
                }
            }

            return (from ds in dish.CookingStage
                    join si in stageIngredients on ds.Id equals si.CookingStageId
                    join i in ingredients on si.IngredientId equals i.Id
                    group si by (
                        si.Ingredient,
                        si.Quantity,
                        i.AvailableCount
                    ) into iq
                    select new ExtendedIngredient
                    (
                        iq.Sum(stageIngredient => stageIngredient.Quantity
                        * servingsCount) <= iq.KeyAvailableCount,
                        iq.Key.Ingredient.Name,
                        iq.Key.AvailableCount - iq.Sum(stageIngredient =>
                        {
                            return stageIngredient.Quantity
                                                    * servingsCount;
                        }),
                        iq.Key.Ingredient.Unit.Name,
                        iq.Key.Ingredient.CostInCents * servingsCount
                    )).ToList();
        }
    }
}
