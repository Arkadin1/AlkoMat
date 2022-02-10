using DrinkApp.Commands;
using DrinkApp.Models;
using DrinkApp.Models.Domains;
using DrinkApp.Models.Wrappers;
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
        private Repository _repository = new Repository();

        public AddEditDrinkViewModel(DrinkWrapper drink = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (drink == null)
            {
                Drink = new DrinkWrapper();
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

        private DrinkWrapper _drink;

        public DrinkWrapper Drink
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

        private void Confirm(object obj)
        {
            if (!Drink.IsValid)
                return;

            

            if (!IsUpdate)
                AddDrink();
            else
                UpdateDrink();

           
            
            CloseWindow(obj as Window);
        }

    

        private void UpdateDrink()
        {
            _repository.UpdateDrink(Drink);
        }

        private void AddDrink()
        {
            _repository.AddDrink(Drink);
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }


        private void InitGroups()
        {
            var groups = _repository.GetGroups();
            groups.Insert(0, new Group { Id = 0, Name = "-- BRAK --" });

            Groups = new ObservableCollection<Group>(groups);

            SelectedGroupId = Drink.Group.Id;
        }

       
     

    }
}
