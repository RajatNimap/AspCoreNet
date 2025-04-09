using CodeFirstApi.Data;
using CodeFirstApi.Models;
using CodeFirstApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployye()
        {
          var allemp = dbContext.employes.ToList();
            return Ok(allemp);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployesById(Guid id) { 
            
            var emp=dbContext.employes.Find(id);
            if(emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        
        }
        [HttpPost]
        public IActionResult AddEmp(AddEmpDto addEmpDto)
        {
            var empEntity = new employe()
            {

                Name = addEmpDto.Name,
                email = addEmpDto.email,
                phone = addEmpDto.phone,
                salary = addEmpDto.salary
            };

            dbContext.employes.Add(empEntity);
            dbContext.SaveChanges();
            return Ok(empEntity);

        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmp(Guid id,UpdateEmp updateEmp)
        {
            var employee = dbContext.employes.Find(id);
            if (employee == null) { 
                return NotFound();
            }
            employee.Name = updateEmp.Name;
            employee.email = updateEmp.email;
            employee.phone = updateEmp.phone;
            employee.salary = updateEmp.salary;  
            dbContext.SaveChanges();
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmp(Guid id) {

            var employee = dbContext.employes.Find(id);
            if (employee == null)
            {
                    return NotFound();  
            }
            dbContext.employes.Remove(employee);
            dbContext.SaveChanges();    
            
            return Ok(); 
        
        }
    }
}
