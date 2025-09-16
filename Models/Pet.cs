using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11._1.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PetType { get; set; }
        public string PetBreed { get; set; }

    }
}
