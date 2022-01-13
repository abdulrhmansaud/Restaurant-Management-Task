using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Data
{
      public  interface reservationRepository
    {

        bool SaveChange();

        IEnumerable<reservation> GetAllReservations();
        reservation GetReservationById(int id);

        void rerurntokenId();
        void createnewReservation(reservation cmd);

        void UpdateReservation(reservation cmd);

        void DeleteReservation(reservation cmd);
    }
}
