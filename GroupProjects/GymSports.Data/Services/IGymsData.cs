using GymSports.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSports.Data.Services
{
     public interface IGymsData
     {
          IEnumerable<Gyms> GetAll();
          Gyms Get(int id);
          void Add(Gyms gyms);
          void Update(Gyms gyms);
          void Delete(int id);
     }
}
