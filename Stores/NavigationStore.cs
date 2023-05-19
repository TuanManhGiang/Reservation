using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Navigation
{
    public class NavigationStore
    {
        private ViewModelBase currentView;

        public ViewModelBase CurrentView
        {
            get => currentView;
            set
            {
                CurrentView?.Dipose();
                currentView = value;
                OnCurrentViewModelChanged();
            }
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        public event Action CurrentViewModelChanged;

    }
}
