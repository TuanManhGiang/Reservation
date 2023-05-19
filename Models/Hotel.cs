using Reservoom.Excepctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
   public class Hotel
    {
        public  ReservationBook _reservationBook;
        public String name { get; }

        public Hotel(ReservationBook reservationBook, string name)
        {
            _reservationBook = reservationBook;
            this.name = name;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
           return await _reservationBook.GetAllReservations();
        }
        public async Task MakeReservationBook(Reservation reservation)
        {
           await _reservationBook.AddReservation(reservation);
        }
        

        

    }
}
