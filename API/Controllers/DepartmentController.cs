using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        MyContext myContext;

        public DepartmentController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Departments.ToList();
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Departments.Find(id);
            if (data == null)
                return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = "null" });
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        //CREATE
        [HttpPost("DepartmentViewModel")]
        public IActionResult Post([FromQuery] DepartmentViewModel deptVM)
        {
            Department department = new Department();
            department.Name = deptVM.Name;
            department.DivisionId = deptVM.DivisionId;
            myContext.Departments.Add(department);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Add Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Add Data Failed" });
        }

        //UPDATE
        [HttpPut("DepartmentEditViewModel")]
        public IActionResult Put([FromQuery] DepartmentEditViewModel deptVM)
        {
            Department department = new Department();
            department.Id = deptVM.Id;
            department.Name = deptVM.Name;
            department.DivisionId = deptVM.DivisionId;
            var data = myContext.Departments.Find(department.Id);
            data.Name = department.Name;
            data.DivisionId = department.DivisionId;
            myContext.Departments.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Update Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Update Data Failed" });
        }

        //DELETE
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Departments.Find(id);
            myContext.Departments.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { message = "Data Removal Succeded", statusCode = 200, data = "null" });
            return BadRequest(new { message = "Data Retrieval Failed", statusCode = 400, data = data });
        }
    }
}
