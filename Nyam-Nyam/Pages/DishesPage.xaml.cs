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
    }
}
