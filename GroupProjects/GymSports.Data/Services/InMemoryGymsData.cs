using GymSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymSports.Data.Services
{
     public class InMemoryGymsData : IGymsData
     {
          List<Gyms> GymPlaces;

        public InMemoryGymsData()
        {
            GymPlaces = new List<Gyms>()
            {
                 new Gyms() {Id = 1, Name = "BigSport", Region =RegionList.Buiucani, Address = "Chișinău, str. Socoleni 7"},
                 new Gyms() {Id = 2, Name = "BigSport2", Region =RegionList.Botanica, Address = "Chișinău, str. Brâncuși 3"},
                 new Gyms() {Id = 3, Name = "BigSport3", Region =RegionList.Ciocana, Address = "Chișinău, str. Dumeniuc 12"}
            };
        }

          public void Add(Gyms gyms)
          {
               GymPlaces.Add(gyms);
               gyms.Id = GymPlaces.Max( g => g.Id ) + 1;
          }

          public void Update(Gyms gyms)
          {
               var existing = Get(gyms.Id);
               if (existing != null)
               {
                    existing.Name = gyms.Name;
                    existing.Region = gyms.Region;
                    existing.Address = gyms.Address;
               }
          }

          public Gyms Get(int id)
          {
               return GymPlaces.FirstOrDefault(g => g.Id == id);
          }

          public IEnumerable<Gyms> GetAll()
          {
               return GymPlaces.OrderBy(g => g.Name);
          }

          public void Delete(int id)
          {
               var gym = Get(id);
               if (gym != null)
               {
                    GymPlaces.Remove(gym);
               }
          }
     }
}
