using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Service.ReservationProviders
{
   public interface IReservationProvider
    {
        public Task<IEnumerable<Reservation>> GetAllReservations();
        
    }
}
