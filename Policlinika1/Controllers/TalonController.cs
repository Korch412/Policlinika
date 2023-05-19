using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Policlinika;
using System;
using System.Net;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Policlinika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalonController : ControllerBase
    {
        DBContext dbt = new DBContext();
        List<Talon> lt = new List<Talon>();

        [HttpGet]
        public IResult Get()
        {

            lt = dbt.Talons.ToList();
            return Results.Json(lt);
        }


        [HttpGet("{id}")]
        public IResult Get(int id_talon)
        {
            int it = 0;
            lt = dbt.Talons.ToList();
            for (int i = 0; i < lt.Count; i++)
            {
                if (lt[i].IdTalon == id_talon) { it = i; }
            }
            return Results.Json(lt[it]);
        }

        [HttpPost]
        public void Post(int idpatient, int iddoctor, DateTime datetime, string number)
        {
            Talon t = new Talon {IdPatient=idpatient, IdDoctor=iddoctor, DateTime=datetime, Number=number  };
            dbt.Talons.Add(t);
            dbt.SaveChanges();
        }


        [HttpPut("{id}")]
        public void Put(int id, int idpatient, int iddoctor, DateTime datetime, string number)
        {
            lt = dbt.Talons.ToList();
            for (int i = 0; i < lt.Count; i++)
            {
                if (lt[i].IdTalon == id)
                {
                    lt[i].IdPatient = idpatient;
                    lt[i].IdDoctor = iddoctor;
                    lt[i].DateTime = datetime;
                    lt[i].Number = number;
                    dbt.SaveChanges();
                }
            }
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbt.Talons.Where(u => u.IdTalon == id).ExecuteDelete();
            dbt.SaveChanges();
        }
    }
}
