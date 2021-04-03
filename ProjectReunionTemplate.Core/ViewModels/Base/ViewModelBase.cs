using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectReunionTemplate.Core.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged,
            [CallerMemberName] string propertyName = null)

        {
            if (Equals(storage, value))
                return false;

            storage = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}