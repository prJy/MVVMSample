using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MVVMSample.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {        
        public MainPageViewModel()
        {
            AllTodoItems = new ObservableCollection<string>();

            SaveTodoItemCommand = new Command(() =>
            {
                AllTodoItems.Add(TodoItem);
                TodoItem = string.Empty;
            });

            DeleteTodoItemCommand = new Command(() => {
                TodoItem = string.Empty;
            });
        }

        string todoItem;
        public string TodoItem {
            get => todoItem;
            set {
                if (todoItem != value)
                {
                    todoItem = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> AllTodoItems { get; set; }
        public Command SaveTodoItemCommand { get; }
        public Command DeleteTodoItemCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
