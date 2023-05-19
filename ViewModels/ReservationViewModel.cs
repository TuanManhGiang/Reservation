using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
   public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservations;
        public String RoomID => _reservations.Room?.ToString();
        public String Username => _reservations.Username;
        public String StartTime => _reservations.StartTime.ToString("d");
        public String EndTime => _reservations.EndTime.ToString("d");
        public ReservationViewModel(Reservation reservation)
        {
            _reservations = reservation;
        }
    }
}
