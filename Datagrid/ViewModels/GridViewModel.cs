using GitSpecificApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GitSpecificApp.ViewModels
{
    public class GridViewModel : BaseViewModel
    {
        private ObservableCollection<SudentModel> _listOfStudent;
        private int _selectedIndex;

        public LocalCommand InsertCommand { get; private set; }
        public LocalCommand ModifyCommand { get; private set; }
        public LocalCommand DeleteCommand { get; private set; }

        public ObservableCollection<SudentModel> ListOfStudents
        {
            get
            {
                if (_listOfStudent == null)
                {
                    _listOfStudent = new ObservableCollection<SudentModel>();
                }
                return _listOfStudent;
            }
            set
            {
                _listOfStudent = value;
                OnPropertyChanged("ListOfStudents");
            }
        }

        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        public GridViewModel()
        {
            InsertCommand = new LocalCommand(ExecuteInsert, CanExecuteInsert);
            DeleteCommand = new LocalCommand(ExecuteDelete, CanExecuteDelete);

            var tmp = new List<SudentModel>()
            {
            new SudentModel
            {
                City = "TestCity",
                BirthDate = new DateTime(1991, 12, 2),
                Name = "John1"
            },
             new SudentModel
            {
                City = "TestCity2",
                BirthDate = new DateTime(1995, 12, 6),
                Name = "John2"
            },
              new SudentModel
            {
                City = "TestCity3",
                BirthDate = new DateTime(2001, 10, 9),
                Name = "John3"
            }

            };

            ListOfStudents = new System.Collections.ObjectModel.ObservableCollection<SudentModel>(tmp);



            OnPropertyChanged("ListOfStudents");
        }

        private void ExecuteDelete(object obj)
        {
            if (SelectedIndex < ListOfStudents.Count)
            {
                ListOfStudents.RemoveAt(SelectedIndex);
            }

        }

        private bool CanExecuteDelete(object arg)
        {
            return true;
        }

        private bool CanExecuteInsert(object arg)
        {
            return true;
        }

        private void ExecuteInsert(object obj)
        {
            var tmp = SelectedIndex;
            ListOfStudents.Insert(SelectedIndex, new SudentModel());
            SelectedIndex = tmp;
        }
    }
}
