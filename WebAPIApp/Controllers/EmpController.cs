using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult updateEmpById()
        {

        }
    }
}
