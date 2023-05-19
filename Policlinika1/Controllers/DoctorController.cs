using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Numerics;

namespace Policlinika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        DBContext dbt = new DBContext();
        List <Doctor> ld = new List<Doctor>();


        [HttpGet]
        public IResult Get()
        {

            ld = dbt.Doctors.ToList();
            return Results.Json(ld);
        }


        [HttpGet("{id}")]
        public IResult Get(int id_doctor)
        {
            int it = 0;
            ld = dbt.Doctors.ToList();
            for (int i = 0; i < ld.Count; i++)
            {
                if (ld[i].IdDoctor == id_doctor) { it = i; }
            }
            return Results.Json(ld[it]);
        }

        [HttpPut("{id}")]
        public void Put(int id, string fio, string type, string phone)
        {
            ld = dbt.Doctors.ToList();
            for (int i = 0; i < ld.Count; i++)
            {
                if (ld[i].IdDoctor == id)
                {
                    ld[i].Type = type;
                    ld[i].Fio = fio;
                    ld[i].Phone = phone;
                    dbt.SaveChanges();
                }
            }

        }

        [HttpPost]
        public void Post(string fio, string type, string phone )
        {
            Doctor c = new Doctor { Type= type, Fio=fio, Phone=phone };
            dbt.Doctors.Add(c);
            dbt.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbt.Doctors.Where(u => u.IdDoctor == id).ExecuteDelete();
            dbt.SaveChanges();
        }
    }
}
