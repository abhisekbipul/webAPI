using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPIApp.Data;
using WebAPIApp.Models;

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [Route("AddEmp")]
        [HttpPost]
        public IActionResult AddNewEmp(Emp emp)
        {
            db.employee.Add(emp);
            db.SaveChanges();
            return Ok("Emp Added successfully");
        }
        [Route("AddEmpList")]
        [HttpPost]
        public IActionResult AddEmpList(List<Emp> empList)
        {
            db.employee.AddRange(empList);
            db.SaveChanges();
            return Ok("EmpList Added successfully");

        }
        [Route("GetEmp")]
        [HttpGet]
        public IActionResult GetEmp()
        {
            var data = db.employee.ToList();
            return Ok(data);
        }
        [Route("DeleteEmp/{id}")]
        [HttpDelete]
        public IActionResult DeleteEmpById(int id)
        {
            var data=db.employee.Find(id);
            db.employee.Remove(data);
            db.SaveChanges();
            return Ok("Employee Deleted Successfully");
        }

        [Route("DeleteEmpList")]
        [HttpDelete]
        public IActionResult DeleteMultiple(List<int> id)
        {
            var data=db.employee.Where(x=>id.Contains(x.Id)).ToList();
            db.employee.RemoveRange(data);
            db.SaveChanges();
            return Ok("Employee Deleted Successfully");
        }

        [Route("UpdateEmployee")]
        [HttpPut]
        public IActionResult updateEmp([FromForm]Emp emp)
        {
            db.employee.Update(emp);
            db.SaveChanges();
            return Ok("Employee updated successfully");
        }

        [Route("UpdateEmp/{id}")]
        [HttpPut]
        public IActionResult updateEmpById(int id,Emp updatedEmp)
        {
            var existingEmp = db.employee.Find(id);
            if (existingEmp == null)
            {
                return NotFound("Employee not found");
            }

            
            existingEmp.Name = updatedEmp.Name;
            existingEmp.Department = updatedEmp.Department;
            existingEmp.Salary = updatedEmp.Salary;
            
            db.SaveChanges();

            return Ok("Employee updated successfully");

        }
        [Route("SearchEmp/{search}")]
        [HttpGet]
        public IActionResult searchEmp(string search)
        {
            
            var data=db.employee.Where(x=>search.Contains(x.Name)||search.Contains(x.Department)|| search.Contains(x.Salary.ToString())).ToList();
            return Ok(data);
        }
    }
}
