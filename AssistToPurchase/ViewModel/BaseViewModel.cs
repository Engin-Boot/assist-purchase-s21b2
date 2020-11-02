using System.ComponentModel;

namespace AssistToPurchase.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //CallerMemberName take the property name at runtime and give to it 
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName()] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
