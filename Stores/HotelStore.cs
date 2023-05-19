using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Stores
{
  public class HotelStore
    {
        private readonly List<Reservation> _reservations;
        private Hotel _hotel;
        private Lazy<Task> initializeLazy;
        public IEnumerable<Reservation> _Reservation => _reservations;
        public Action<Reservation> ReservationMade;
        public HotelStore(Hotel hotel)
        {
            this.initializeLazy = new Lazy<Task>(Initialize);
            this._reservations = new List<Reservation>();
            this._hotel = hotel;    
        }
        private void OnReservationMade(Reservation reservation)
        {
            ReservationMade?.Invoke(reservation);
        }
        public async Task MakeReservation(Reservation reservation)
        {
            await _hotel.MakeReservationBook(reservation);
            _reservations.Add(reservation);
            OnReservationMade(reservation);
        }
        public async Task Load()
        {
            try
            {
                await initializeLazy.Value;
            }
            catch (Exception)
            {
                this.initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }
        }
        private async Task  Initialize()
        {
            IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();
            _reservations.Clear();
            _reservations.AddRange(reservations);
        }
    }
}
