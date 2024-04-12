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
    /// Логика взаимодействия для DishesPage.xaml
    /// </summary>
    public partial class DishesPage : Page
    {
        public static List<Category> categories { get; set; }
        public static List<Dish> dishes { get; set; }
        public static Dish dish { get; set; }

        public DishesPage()
        {
            InitializeComponent();
            categories = DBConnection.nyamNyam.Category.ToList();
            dishes = DBConnection.nyamNyam.Dish.ToList();
            this.DataContext = this;
            Refresh();
        }

        private void Refresh()
        {
            DishesLV.ItemsSource = DBConnection.nyamNyam.Dish.ToList();
        }

        private void DishesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DishesLV.SelectedItem is Dish)
            {
                DBConnection.selectedDish = DishesLV.SelectedItem as Dish;
                NavigationService.Navigate(new RecipeForSelectedDishPage(DishesLV.SelectedItem as Dish));
            }
        }

        private void CategoryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = CategoryCB.SelectedItem as Category;
            DishesLV.ItemsSource = DBConnection.nyamNyam.Dish.Where(i => i.CategoryId == a.Id).ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTB.Text.Length > 0)
            {
                DishesLV.ItemsSource = DBConnection.nyamNyam.Dish.Where(i => i.Name.ToLower().StartsWith(SearchTB.Text.Trim().ToLower())).ToList();
            }
            else
            {
                Refresh();
            }
        }

        private void IngredientChBx_Checked(object sender, RoutedEventArgs e)
        {
            if (IngredientChBx.IsChecked == true)
            {
                DishesLV.ItemsSource = DBConnection.nyamNyam.Dish.Where(x => x.Available == true).ToList();
            }
            else
            {
                DishesLV.ItemsSource = dishes;
            }
        }

        private void IngredientChBx_Unchecked(object sender, RoutedEventArgs e)
        {
            if (IngredientChBx.IsChecked == false)
            {
                DishesLV.ItemsSource = DBConnection.nyamNyam.Dish.ToList();
            }
            else
            {
                DishesLV.ItemsSource = dishes;
            }
        }
    }
}
