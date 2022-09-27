using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        MyContext myContext;

        public DivisionController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Divisions.ToList();
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Divisions.Find(id);
            if (data == null)
                return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = "null" });
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        //CREATE
        [HttpPost("DivisionViewModel")]
        public IActionResult Post([FromQuery] DivisionViewModel divVM)
        {
            Division division = new Division();
            division.Name = divVM.Name;
            myContext.Divisions.Add(division);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Add Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Add Data Failed" });
        }

        //UPDATE
        [HttpPut("Division")]
        public IActionResult Put([FromQuery] Division division)
        {
            var data = myContext.Divisions.Find(division.Id);
            data.Name = division.Name;
            myContext.Divisions.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Update Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Update Data Failed" });
        }

        //DELETE
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Divisions.Find(id);
            myContext.Divisions.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { message = "Data Removal Succeded", statusCode = 200, data = "null" });
            return BadRequest(new { message = "Data Retrieval Failed", statusCode = 400, data = data });
        }
    }
}
