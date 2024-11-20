using MVVMExample.Models;
using MVVMExample.ViewModels.Base;
using MVVMExample.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMExample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private int _age;

        public MainViewModel()
        {
            People = new ObservableCollection<Person>();
            AddPersonCommand = new RelayCommand(ExecuteAddPerson, CanExecuteAddPerson);
        }

        public ObservableCollection<Person> People { get; }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public ICommand AddPersonCommand { get; }

        private bool CanExecuteAddPerson(object obj)
        {
            return !string.IsNullOrWhiteSpace(FirstName) &&
                   !string.IsNullOrWhiteSpace(LastName) &&
                   Age > 0;
        }

        private void ExecuteAddPerson(object obj)
        {
            People.Add(new Person
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age
            });

            // Clear the inputs
            FirstName = string.Empty;
            LastName = string.Empty;
            Age = 0;
        }
    }
}