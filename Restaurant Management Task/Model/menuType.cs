using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Model
{
    public class menuType 
    {

       public menuType()
        {
            reservationsList = new List<reservation>();
        }

        [Key]
        public int MenuTypeId {get; set;}



        // Look up in database (1-breakfast , 2-lunch , 3-dinner , 4-drinks)..
        [StringLength(50, ErrorMessage = "Note can't be longer than 50 characters")]
        [Required]
        public string menuTypeName {get; set;}

        public List<reservation> reservationsList { get; set; }

    }
}
