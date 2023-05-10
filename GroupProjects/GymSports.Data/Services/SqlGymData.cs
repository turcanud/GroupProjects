using GymSports.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSports.Data.Services
{
     public class SqlGymData : IGymsData
     {
          private readonly GymDataBaseContext db;

          public SqlGymData(GymDataBaseContext db)
        {
               this.db = db;
          }
        public void Add(Gyms gyms)
          {
               db.GymsDb.Add(gyms);
               db.SaveChanges();
          }

          public void Delete(int id)
          {
               var gym = db.GymsDb.Find(id);
               db.GymsDb.Remove(gym);
               db.SaveChanges();
          }

          public Gyms Get(int id)
          {
               return db.GymsDb.FirstOrDefault(g => g.Id == id);
          }

          public IEnumerable<Gyms> GetAll()
          {
               return from g in db.GymsDb
                      orderby g.Name
                      select g;

          }

          public void Update(Gyms gyms)
          {
               var entry = db.Entry(gyms);
               entry.State = EntityState.Modified;
               db.SaveChanges();
          }
     }
}
