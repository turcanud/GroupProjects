using GymSports.Data.Models;
using GymSports.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebPage.Api
{
    public class GymsController : ApiController
    {
          private readonly IGymsData db;

          public GymsController(IGymsData db) {
               this.db = db;
          }
          public IEnumerable<Gyms> Get() {
               var model = db.GetAll();
               return model;
          }
    }
}
