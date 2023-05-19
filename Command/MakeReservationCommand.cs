using Reservoom.Excepctions;
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
   public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly HotelStore hotel;
        private MakeReservationViewModel _makeReservationViewModel;

        public MakeReservationCommand(HotelStore hotel, MakeReservationViewModel makeReservationViewModel)
        {
            this.hotel = hotel;
            _makeReservationViewModel = makeReservationViewModel;
            
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Reservation reservation = new Reservation(new RoomID(_makeReservationViewModel.FloorNumber,
                _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.Username,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate);
            try
            {
                await hotel.MakeReservation(reservation);
                MessageBox.Show("sucessfully reseved room . ", "Sucessfully", MessageBoxButton.OK,
                    MessageBoxImage.Information);

            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("this room is already taken. ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("failed to make reservation ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
