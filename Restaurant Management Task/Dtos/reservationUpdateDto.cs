using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Dtos
{
    public class reservationUpdateDto
    {


        [Key]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Phone Number is needed.")]

        public string GustsNumber { get; set; }

        [Required(ErrorMessage = "reservation date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }

        [StringLength(300, ErrorMessage = "note can't be longer than 300 characters")]
        [NotNull]
        public string Note { get; set; }

        public string UserIdforToken { get; set; }

        [ForeignKey("menuType")]
        public int MenuTID { get; set; }
    }
}
