using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID Room { set; get; }
        public String Username { get; set; }

        public Reservation(String username)
        {
            Username = username;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Leght => EndTime.Subtract(StartTime);
        public Reservation(RoomID roomID,String name, DateTime startTime, DateTime endTime)
        {
            Username = name;
            Room = roomID;
            StartTime = startTime;
            EndTime = endTime;
        }

        public bool Conflicts(Reservation reservation)
        {
            if (!Room.Equals(reservation.Room))
            {
                return false;
            }
            return reservation.StartTime <=EndTime || reservation.EndTime >= StartTime;
        }
    }
}
