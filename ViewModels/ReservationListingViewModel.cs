using Reservoom.Command;
using Reservoom.Models;
using Reservoom.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Reservoom.Commands;
using Reservoom.Service;
using Reservoom.Stores;


namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private HotelStore hotelStore;
        private readonly ObservableCollection<ReservationViewModel> _reservation;
        public IEnumerable<ReservationViewModel> Reservations => _reservation;
        private String _errorMessage;

        public String ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasMessageError));
            }
        }
        public bool HasMessageError => !String.IsNullOrEmpty(ErrorMessage);
        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand MakeReservationCommand { get; }
        public ICommand LoadReservationCommand { get; }
        public ReservationListingViewModel(HotelStore hotel, NavigationService<MakeReservationViewModel> navigationService)
        {
            hotelStore = hotel;
            MakeReservationCommand = new NavigationCommand<MakeReservationViewModel>(navigationService);
            LoadReservationCommand = new LoadReservationsCommand(this,hotel);
            _reservation = new ObservableCollection<ReservationViewModel>();
            hotelStore.ReservationMade += OnReservationMode;
            
        }

        public override void Dipose()
        {
            hotelStore.ReservationMade -= OnReservationMode;
            base.Dipose();
        }

        private void OnReservationMode(Reservation reservation)
        {
            ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
            _reservation.Add(reservationViewModel);
        }

        public static ReservationListingViewModel LoadViewModel(HotelStore hotel,  NavigationService<MakeReservationViewModel> navigationService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(hotel ,navigationService);
            viewModel.LoadReservationCommand.Execute(null);
            return viewModel;
        }
        
        public void Update(IEnumerable<Reservation> reservations)
        {
            _reservation.Clear();
            foreach (Reservation _reservation in reservations)
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(_reservation);
                this._reservation.Add(reservationViewModel);
            }
        }
    }
}
