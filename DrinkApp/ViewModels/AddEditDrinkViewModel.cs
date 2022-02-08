using DrinkApp.Commands;
using DrinkApp.Models;
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
    public class AddEditDrinkViewModel : ViewModelBase
    {
        public AddEditDrinkViewModel(Drink drink = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (drink == null)
            {
                Drink = new Drink();
            }
            else
            {
                Drink = drink;
                IsUpdate = true;
            }

            InitGroups();
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private Drink _drink;

        public Drink Drink
        {
            get { return _drink; }
            set { 
                _drink = value;
                OnPropertyChanged();
            }
        }

        private bool _isUpdate;

        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
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

        private void InitGroups()
        {
            Groups = new ObservableCollection<Group>
            {
                new Group {Id =0, Name = "-- BRAK --"},
                new Group {Id =1, Name = "Mężczyzna"},
                new Group {Id =2, Name = "Kobieta"},
            };

            Drink.Group.Id= 0;
        }



        private void Confirm(object obj)
        {
            if (!IsUpdate)
            {
                AddDrink();
            }
            else
            {
                UpdateDrink();
            }
            //później
            CloseWindow(obj as Window);
        }

        private void UpdateDrink()
        {
            //baza danych
        }

        private void AddDrink()
        {
            //baza danych
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
