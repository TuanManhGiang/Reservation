using Reservoom.Navigation;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservoom.Service;

namespace Reservoom.Command
{
    public class NavigationCommand<TViewModel> : CommandBase where TViewModel :ViewModelBase
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigationCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
