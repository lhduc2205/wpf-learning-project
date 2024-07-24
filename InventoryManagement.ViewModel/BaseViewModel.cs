using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InventoryManagement.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyNames = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNames));
        }

    }
}
