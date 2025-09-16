using Assignment_11._1.Data;
using Assignment_11._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11._1.Services
{    
    public class CRUD : ICRUD
    {        
        private PetContext context;
        //constructor to be called by dependency injection services
        public CRUD(PetContext _context) {
            context = _context;
        }
        public void AddEvent(PetEvent petEvent)
        {
            context.EventList.Add(petEvent);
            context.SaveChanges();
        }
        public void AddPet(Pet pet)
        {
            context.PetList.Add(pet);
            context.SaveChanges();
        }
        public void DeleteEvent(PetEvent petEvent)
        {            
            if (petEvent != null)
            {
                context.EventList.Remove(petEvent);
                context.SaveChanges();
            }
        }
        public List<PetEvent> GetAllEventsByPet(int id)
        {
            List<PetEvent> allEvents = context.EventList.ToList();
            var filteredList = from events in allEvents
                               where events.PetId == id
                               select events;
            return filteredList.ToList();
            //If there's an error it may be the TYPE from the LINQ to the return type
        }
        public List<Pet> GetAllPets()
        {
            return context.PetList.ToList();
        }
        public PetEvent GetEventById(int id)
        {
            return context.EventList.Find(id);
        }
        public Pet GetPetById(int id)
        {
            return context.PetList.Find(id);            
        }
        public void UpdateEvent(PetEvent petEvent)
        {
            context.EventList.Update(petEvent);
            context.SaveChanges();
        }

        public void UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
