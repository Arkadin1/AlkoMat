using DrinkApp.Commands;
using DrinkApp.Models;
using DrinkApp.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DrinkApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            AddDrinkCommand = new RelayCommand(AddEditDrink);
            EditDrinkCommand = new RelayCommand(AddEditDrink, CanEditDeleteDrink);
            DeleteDrinkCommand = new AsyncRelayCommand(DeleteDrink, CanEditDeleteDrink);
            RefreshDrinkCommand = new RelayCommand(RefreshDrinks);

            RefreshDrink();

            InitGroups();

        }

       


        public ICommand AddDrinkCommand { get; set; }

        public ICommand EditDrinkCommand { get; set; }

        public ICommand DeleteDrinkCommand { get; set; }

        public ICommand RefreshDrinkCommand { get; set; }

        private Drink _selectedDrink;

        public Drink SelectedDrink
        {
            get { return _selectedDrink; }
            set
            {
                _selectedDrink = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Drink> _drinks;

        public ObservableCollection<Drink> Drinks
        {
            get { return _drinks; }
            set
            {
                _drinks = value;
                OnPropertyChanged();
            }
        }

        private int _selectedGroupId;

        public int SelectedGroupId
        {
            get { return _selectedGroupId; }
            set
            {
                _selectedGroupId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Group> _groups;

        public ObservableCollection<Group> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }



        private void RefreshDrinks(object obj)
        {
            RefreshDrink();
        }


        private bool CanEditDeleteDrink(object obj)
        {
            return SelectedDrink != null;
        }

        private void AddEditDrink(object obj)
        {
            var addEditStudentWindow = new AddEditDrinkView(obj as Drink);
            addEditStudentWindow.Closed += AddEditDrinkWindow_Closed;
            addEditStudentWindow.ShowDialog();
        }

        private void AddEditDrinkWindow_Closed(object sender, EventArgs e)
        {
            RefreshDrink();
        }

        private async Task DeleteDrink(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
           var dialog = await metroWindow.ShowMessageAsync("Usuwanie Pomiaru", $"Czy jesteś pewien, czy chcesz usunąć pomiar {SelectedDrink.Name}?", MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
            {
                return;
            }

            // usuwanie z bazy danych

            RefreshDrink();
        }

        private void InitGroups()
        {
            Groups = new ObservableCollection<Group>
            {
                new Group {Id =0, Name = "Wszystkie"},
                new Group {Id =1, Name = "Mężczyzna"},
                new Group {Id =2, Name = "Kobieta"},
            };

            SelectedGroupId = 0;
        }


        private void RefreshDrink()
        {
            Drinks = new ObservableCollection<Drink>
            {
                new Drink
                {
                    Id = 1,
                    Name = "Pierwszy ",
                    Weight = 50,
                    Beer = 1,
                    Wine = 0,
                    Vodka = 2,
                    Score = 0,
                    Sober = true,
                    Group = new Group {Id = 1}

                },

                 new Drink
                {
                     Id=2,
                    Name = "Drugi",
                    Group = new Group {Id = 2},
                    Weight = 30,
                    Beer = 2,
                    Wine = 5,
                    Vodka = 1,
                    Score = 1,
                    Sober = false,

                },

                  new Drink
                {
                      Id = 3,
                    Name = "Trzeci",
                    Group = new Group {Id = 1},
                    Weight = 80,
                    Beer = 3,
                    Wine = 0,
                    Vodka = 0,
                     Score = 2,
                    Sober = false,

                }
            };
        }

    }
}
