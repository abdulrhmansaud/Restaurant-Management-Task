using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Dtos
{
    public class reservationReadDto
    {

      public int ReservationId { get; set; }
        public string GustsNumber { get; set; }
        public string ReservationDate { get; set; }
        public string Note { get; set; }
       public string UserIdforToken { get; set; }

        public int MenuTypeId { get; set; }


    }
}
