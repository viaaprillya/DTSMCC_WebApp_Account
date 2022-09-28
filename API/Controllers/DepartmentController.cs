using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        DepartmentRepository departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = departmentRepository.Get();
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var data = departmentRepository.Get(id);
            if (data == null)
                return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = "null" });
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        //CREATE
        [HttpPost("DepartmentViewModel")]
        public IActionResult Post([FromQuery] DepartmentViewModel deptVM)
        {
            var result = departmentRepository.Post(deptVM);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Add Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Add Data Failed" });
        }

        //UPDATE
        [HttpPut("DepartmentEditViewModel")]
        public IActionResult Put([FromQuery] DepartmentEditViewModel deptEVM)
        {
            var result = departmentRepository.Put(deptEVM);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Update Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Update Data Failed" });
        }

        //DELETE
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = departmentRepository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Data Removal Succeded" });
            return BadRequest(new { statusCode = 400, message = "Data Retrieval Failed" });
        }
    }
}
