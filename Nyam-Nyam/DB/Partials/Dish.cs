using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyam_Nyam.DB
{
    public partial class Dish
    {
        public string ImageConverter
        {
            get
            {
                var destrinationFormat = string.Empty;
                var allIngredientsRecipeSteps = this.CookingStage.SelectMany(i => i.IngredientOfStage);
                if (allIngredientsRecipeSteps.Any())
                {
                    foreach (var ingredientStep  in allIngredientsRecipeSteps)
                    {
                        if(allIngredientsRecipeSteps.Where(i => i.IngredientId == ingredientStep.IngredientId).Sum(i => i.Quantity) > 
                            ingredientStep.Ingredient.AvailableCount)
                        {
                            destrinationFormat = "Gray32Float";
                            Available = false;
                            DBConnection.nyamNyam.SaveChanges();
                        }
                    }
                }
                else
                {
                    destrinationFormat = "Bgra32";
                    Available = true;
                    DBConnection.nyamNyam.SaveChanges();
                }
                return destrinationFormat;
            }
        }
        
        public double OurCost
        {
            get
            {
                var v = this.CookingStage.SelectMany(s => s.IngredientOfStage).ToList();
                double result = 0;
                foreach (var i in v)
                {
                    result += i.Ingredient.CostInCents * i.Quantity;
                }
                return result * 0.01;
            }
        }
    }
}
