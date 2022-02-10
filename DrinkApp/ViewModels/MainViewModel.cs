using DrinkApp.Commands;
using DrinkApp.Models;
using DrinkApp.Models.Domains;
using DrinkApp.Models.Wrappers;
using DrinkApp.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DrinkApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();



        public MainViewModel()
        {
            

            AddDrinkCommand = new RelayCommand(AddEditDrink);
            EditDrinkCommand = new RelayCommand(AddEditDrink, CanEditDeleteDrink);
            DeleteDrinkCommand = new AsyncRelayCommand(DeleteDrink, CanEditDeleteDrink);
            RefreshDrinkCommand = new RelayCommand(RefreshDrinks);
            GetResultCommand = new RelayCommand(ResultScreenDrinks);

            RefreshDrink();

            InitGroups();


        }

        private void ResultScreenDrinks(object obj)
        {
            var ScreenString = Score.ToString();
            ScreenScore = ScreenString;
           ;
        }

        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private string _screenScore;

        public string ScreenScore
        {
            get { 
                return _screenScore; 
            }
            set
            {
                _screenScore = value;
                OnPropertyChanged();
            }
        }





        public ICommand AddDrinkCommand { get; set; }

        public ICommand EditDrinkCommand { get; set; }

        public ICommand DeleteDrinkCommand { get; set; }

        public ICommand RefreshDrinkCommand { get; set; }

        public ICommand GetResultCommand { get; set; }



        private DrinkWrapper _selectedDrink;

        public DrinkWrapper SelectedDrink
        {
            get { return _selectedDrink; }
            set
            {
                _selectedDrink = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<DrinkWrapper> _drinks;

        public ObservableCollection<DrinkWrapper> Drinks
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
            get
            {
               
                return _groups;
            }
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
            var addEditStudentWindow = new AddEditDrinkView(obj as DrinkWrapper);
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

            _repository.DeleteDrink(SelectedDrink.Id);

            RefreshDrink();
        }

        private void InitGroups()
        {
            var groups = _repository.GetGroups();
            groups.Insert(0, new Group { Id = 0, Name = "Wszystkie" });

            Groups = new ObservableCollection<Group>(groups);

            SelectedGroupId = 0;


        }


        private void RefreshDrink()
        {
            Drinks = new ObservableCollection<DrinkWrapper>(_repository.GetDrinks(SelectedGroupId));

        }

        private bool _sober;

        public bool Sober
        {
            get { return _sober; }
            set
            {
                _sober = value;
                OnPropertyChanged();

            }
        }


    }
}
