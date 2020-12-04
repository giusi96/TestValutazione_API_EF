using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esercizio.Core.EF.Context;
using Esercizio.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esercizio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Employee> Get() //restituisce la lista di employees
        {
            using var _ctx = new OfficeContext();

            var result = _ctx.Employees
               //.Include(t=>t.Notes)
               .ToList();
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) //restiuisce l'impiegato in base all'id
        {

            using var _ctx = new OfficeContext();
            var employee = _ctx.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post(Employee employee)//<= model Binding
                                                    //inseriemnto di un nuovo employee           
        {
            using var _ctx = new OfficeContext();
            if (employee != null)
            {
                _ctx.Employees.Add(employee);
                _ctx.SaveChanges();

                return Ok();
            }

            return BadRequest("Invalid employee");
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee employee)
        //modifica di un employee           
        {
            using var _ctx = new OfficeContext();
            if (employee != null && id == employee.Id)
            {
                _ctx.Employees.Update(employee);
                _ctx.SaveChanges();


                return Ok();
            }
            return BadRequest("Error updating Employee");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //cancella in base all'id 
                                            
        {
            using var _ctx = new OfficeContext();
            var employee = _ctx.Employees.SingleOrDefault(e => e.Id == id);

            if (employee != null)
            {
                _ctx.Employees.Remove(employee);
                _ctx.SaveChanges();
                return Ok();
            }
            else
                return BadRequest("Cannot delete Employee");          
        }
        [HttpGet("{FirstName}")]
        public IEnumerable<Office> Get(string name) //restituisce la lista di employees di un ufficio
        {
            using var _ctx = new OfficeContext();

            var result = _ctx.Offices
               .Include(e=>e.Employees)
               .ToList();
            return result;
        }
    }

}
