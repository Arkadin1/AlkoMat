using DrinkApp.Models;
using DrinkApp.ViewModels;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace DrinkApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddEditDrinkView.xaml
    /// </summary>
    public partial class AddEditDrinkView : MetroWindow
    {
        public AddEditDrinkView(Drink drink = null)
        {
            InitializeComponent();

            DataContext = new AddEditDrinkViewModel(drink);
        }
    }
}
