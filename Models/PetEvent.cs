using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11._1.Models
{
    public class PetEvent
    {
        [Key]        
        public int EventId { get; set; }        
        public DateOnly EventDate { get; set; }
        public string EventType { get; set; }
        public string EventDescription { get; set; }
        public string EventComments { get; set; }
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
        //Constructors
        public PetEvent()
        {

        }
        public PetEvent(int petId)
        {
            PetId = petId;
        }

    }
}
