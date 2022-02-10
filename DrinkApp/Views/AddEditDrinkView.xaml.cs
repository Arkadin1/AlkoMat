using DrinkApp.Models;
using DrinkApp.Models.Wrappers;
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
        

        public AddEditDrinkView(DrinkWrapper drink = null)
        {
            InitializeComponent();

            DataContext = new AddEditDrinkViewModel(drink);
        }

       


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var BeerString = BeerDrink.Text;
            var BeerToInt = int.Parse(BeerString);

            var WineString = WineDrink.Text;
            var WineToInt = int.Parse(WineString);

            var VodkaString = VodkaDrink.Text;
            var VodkaToint = int.Parse(VodkaString);

            var Score = (BeerToInt + WineToInt + VodkaToint) * 10;

            string ScoreToText = Score.ToString();

        }
    }
}
