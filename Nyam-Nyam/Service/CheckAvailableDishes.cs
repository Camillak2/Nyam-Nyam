using Nyam_Nyam.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyam_Nyam.Service
{
    public class CheckAvailableDishes
    {
        public static void Check()
        {
            List<Dish> dishes = DBConnection.nyamNyam.Dish.ToList();
            for (int i = 0; i < dishes.Count; i++)
            {
                dishes[i].Availble = true;
                int id = dishes[i].Id;
                List<CookingStage> cookingStages = DBConnection.nyamNyam.CookingStage.Where(x => x.DishId == id).ToList();
                List<IngredientOfStage> ingredientOfStages = new List<IngredientOfStage>(0);
                for (int j = 0; j < cookingStages.Count; j++)
                {
                    int stageId = cookingStages[j].Id;
                    IngredientOfStage temp = DBConnection.nyamNyam.IngredientOfStage.FirstOrDefault(x => x.CookingStageId == stageId);
                    if (temp != null
                        ingredientOfStages.Add(temp);
                }
                for (int j = 0; j < ingredientOfStages.Count; j++)
                {
                    if (ingredientOfStages[j].Ingredient.AvailableCount < ingredientOfStages[j].Quantity)
                    {
                        dishes[i].Availble = false;
                    }
                }
            }
            DBConnection.nyamNyam.SaveChanges();
        }
    }
}
