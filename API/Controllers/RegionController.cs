using API.Context;
using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        RegionRepository regionRepository;

        public RegionController(RegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = regionRepository.Get();
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var data = regionRepository.Get(id);
            if (data == null)
                return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = "null" });
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        //CREATE
        [HttpPost("RegionViewModel")]
        public IActionResult Post([FromQuery] RegionViewModel regVM)
        {
            var result = regionRepository.Post(regVM);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Add Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Add Data Failed" });
        }

        //UPDATE
        [HttpPut("RegionEditViewModel")]
        public IActionResult Put([FromQuery] RegionEditViewModel regEVM)
        {
            var result = regionRepository.Put(regEVM);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Update Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Update Data Failed" });
        }

        //DELETE
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = regionRepository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Data Removal Succeded" });
            return BadRequest(new { statusCode = 400, message = "Data Retrieval Failed" });
        }
    }
}
