using Reservoom.Models;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Reservoom.Commands;
using Reservoom.Stores;

namespace Reservoom.Command
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _viewModel;
        private readonly HotelStore _hotel;

        public LoadReservationsCommand(ReservationListingViewModel viewModel, HotelStore hotel)
        {
            _viewModel = viewModel;
            _hotel = hotel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.IsLoading = true;
            _viewModel.ErrorMessage = String.Empty;
            try
            {
                
                await _hotel.Load();

                _viewModel.Update(_hotel._Reservation);
            }
            catch (Exception)
            {
                _viewModel.ErrorMessage = "failed to make reservation ";
            }

            _viewModel.IsLoading = false;

        }
    }
}