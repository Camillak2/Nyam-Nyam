using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nyam_Nyam.DB;

namespace Nyam_Nyam.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecipeForSelectedDishPage.xaml
    /// </summary>
    public partial class RecipeForSelectedDishPage : Page
    {
        public static List<Dish> dishes { get; set; }
        public static List<Ingredient> ingredients { get; set; }
        public static List<CookingStage> cookingStages { get; set; }
        public static List<IngredientOfStage> ingredientOfStages { get; set; }
        public static Category category { get; set; }
        public static CookingStage cookingStage { get; set; }
        public static List<Unit> units { get; set; }

        Dish contextDish;

        public RecipeForSelectedDishPage(Dish dish)
        {
            InitializeComponent();
            contextDish = dish;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void InitializeDataInPage()
        {
            //CookingProcessLV.ItemsSource = DBConnection.nyamNyam.CookingStage.Where(i => i.DishId == contextDish.Id);
            IngredientsLV.ItemsSource = DBConnection.nyamNyam.GetIngredientsForSelectDish(contextDish.Id).ToList();
            dishes = DBConnection.nyamNyam.Dish.ToList();
            ingredients = DBConnection.nyamNyam.Ingredient.ToList();
            cookingStages = DBConnection.nyamNyam.CookingStage.ToList();
            ingredientOfStages = DBConnection.nyamNyam.IngredientOfStage.ToList();
            units = DBConnection.nyamNyam.Unit.ToList();
            this.DataContext = this;
            DishTB.Text = contextDish.Name;
            CategoryTB.Text = contextDish.Category.Name;
            //CookingTimeTB.Text = contextDish.CookingStage.TimeInMinutes.ToString() + " min";
            DescriptionTB.Text = contextDish.Description;
        }
    }
}
