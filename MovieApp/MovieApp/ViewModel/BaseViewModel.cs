using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MovieApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public Page ViewPage { get; set; }

        protected virtual bool SetProperty<T>(ref T name, T value, [CallerMemberName]string propertyName = "", Action onChanged = null,
    Func<T, T, bool> validateValue = null)
        {
            if (EqualityComparer<T>.Default.Equals(name, value))
                return false;

            //if value changed but didn't validate
            if (validateValue != null && !validateValue(name, value))
                return false;

            name = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}

