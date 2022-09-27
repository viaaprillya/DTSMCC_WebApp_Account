using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        MyContext myContext;

        public RegionController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Regions.ToList();
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Regions.Find(id);
            if (data == null)
                return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = "null" });
            return Ok(new { message = "Data Retrieval Succeded", statusCode = 200, data = data });
        }

        //CREATE
        [HttpPost("RegionViewModel")]
        public IActionResult Post([FromQuery] RegionViewModel regVM)
        {
            Region region = new Region();
            region.Name = regVM.Name;
            region.DivisionId = regVM.DivisionId;
            myContext.Regions.Add(region);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Add Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Add Data Failed" });
        }

        //UPDATE
        [HttpPut("RegionEditViewModel")]
        public IActionResult Put([FromQuery] RegionEditViewModel regVM)
        {
            Region region = new Region();
            region.Id = regVM.Id;
            region.Name = regVM.Name;
            region.DivisionId = regVM.DivisionId;
            var data = myContext.Regions.Find(region.Id);
            data.Name = region.Name;
            data.DivisionId = region.DivisionId;
            myContext.Regions.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Update Data Succeded" });
            return BadRequest(new { statusCode = 400, message = "Update Data Failed" });
        }

        //DELETE
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Regions.Find(id);
            myContext.Regions.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { message = "Data Removal Succeded", statusCode = 200, data = "null" });
            return BadRequest(new { message = "Data Retrieval Failed", statusCode = 400, data = data });
        }
    }
}
