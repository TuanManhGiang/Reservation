using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationConflictValidators
{
    public interface IReservationConflictValidator
    {
        public Task<Reservation> GetConflictingReservation(Reservation reservation);
    }
}