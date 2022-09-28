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
    public class DivisionController : ControllerBase
    {
        DivisionRepository divisionRepository;

        public DivisionController(DivisionRepository divisionRepository)
        {
            this.divisionRepository = divisionRepository;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = divisionRepository.Get();
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var data = divisionRepository.Get(id);
            if (data == null)
                return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = "null" });
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        //CREATE
        [HttpPost("DivisionViewModel")]
        public IActionResult Post([FromQuery] DivisionViewModel divVM)
        {
            var result = divisionRepository.Post(divVM);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Add Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Add Data Failed" });
        }

        //UPDATE
        [HttpPut("Division")]
        public IActionResult Put([FromQuery] Division division)
        {
            var result = divisionRepository.Put(division);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Update Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Update Data Failed" });
        }

        //DELETE
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = divisionRepository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Data Removal Succeded" });
            return BadRequest(new { statusCode = 400, message = "Data Retrieval Failed" });
        }
    }
}
