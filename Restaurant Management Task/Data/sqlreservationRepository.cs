using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Data
{
    public class sqlreservationRepository : reservationRepository
    {

        private readonly reservationContext _context;


        public sqlreservationRepository(reservationContext context)
        {

            _context = context;
        }

        public IEnumerable<reservation> GetAllReservations()
        {


            return _context.reservations.ToList();
        }

        public reservation GetReservationById(int id)
        {
            return _context.reservations.FirstOrDefault(p => p.ReservationId == id);
        }

        public void createnewReservation(reservation cmd)
        {
            if (cmd == null)
            {

                throw new ArgumentNullException(nameof(cmd));

            }
            _context.reservations.Add(cmd);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateReservation(reservation cmd)
        {
           // No CODE HERE 
        }

        public void DeleteReservation(reservation cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));

            }

            _context.reservations.Remove(cmd);
        }

        public void rerurntokenId()
        {
            // No CODE HERE 
        }
    }
}
