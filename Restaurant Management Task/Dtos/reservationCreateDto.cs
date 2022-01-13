using Restaurant_Management_Task.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Dtos
{
    public class reservationCreateDto
    {


        public reservationCreateDto()
        {

            ReservationDate = DateTime.Now;

        }



        [Required(ErrorMessage = "Phone Number is needed.")]
      
        public string GustsNumber { get; set; }

      
        public DateTime ReservationDate { get; set; }

        [StringLength(300, ErrorMessage = "note can't be longer than 300 characters")]
        [NotNull]
        public string Note { get; set; }

        public string UserIdforToken { get; set; }

        [Required]
        public string MenuTypeId { get; set; }


    }
}
