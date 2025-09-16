using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_11._1.Models;
using Microsoft.Extensions.Logging;

namespace Assignment_11._1.Services
{
    public interface ICRUD
    {
        //Create methods
        public void AddPet(Pet pet);
        public void AddEvent(PetEvent petEvent);
        //Read methods
        public Pet GetPetById(int id);
        public List<Pet> GetAllPets();
        public List<PetEvent> GetAllEventsByPet(int id);
        public PetEvent GetEventById(int id);
        //Update methods
        public void UpdatePet(Pet pet);
        public void UpdateEvent(PetEvent petEvent);

        //Delete methods - NO DELETE METHOD FOR PETS- KEEP FOREVER!
        public void DeleteEvent(PetEvent petEvent);
        
    }
}
