using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Numerics;
using System.Text.Json;

namespace Policlinika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        DBContext dbt = new DBContext();
        List<Patient> lp = new List<Patient>();
        [HttpGet]
        public IResult Get()
        {

            lp = dbt.Patients.ToList();
            return Results.Json(lp);
        }


        [HttpGet("{id}")]
        public IResult Get(int id_patient)
        {
            int it = 0;
            lp = dbt.Patients.ToList();
            for (int i = 0; i < lp.Count; i++)
            {
                if (lp[i].IdPatient == id_patient) { it = i; }
            }
            return Results.Json(lp[it]);
        }


        [HttpPost]
        public void Post(string fio,int age, char sex, string phone, string address)
        {
            Patient c = new Patient { Fio = fio, Address=address, Phone=phone, Sex=sex.ToString(), Age=age  };
            dbt.Patients.Add(c);
            dbt.SaveChanges();
        }

        
        [HttpPut("{id}")]
        public void Put(int id, string fio, int age, char sex, string phone, string address)
        {

            lp = dbt.Patients.ToList();
            for (int i = 0; i < lp.Count; i++)
            {
                if (lp[i].IdPatient == id)
                {
                    lp[i].Fio = fio;
                    lp[i].Address = address;
                    lp[i].Phone = phone;
                    lp[i].Sex = sex.ToString();
                    lp[i].Age = age;
                    dbt.SaveChanges();
                }
            }
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbt.Patients.Where(u => u.IdPatient == id).ExecuteDelete();
            dbt.SaveChanges();
        }
    }
}
