using ASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MyDbContext context;

        public StudentAPIController(MyDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task< ActionResult<List<MyTable>>> GetStudents()
        {
            var data = await context.MyTables.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MyTable>> GetStudentById(int id)
        {
            var data= await context.MyTables.FindAsync(id);
            if (data == null)
            {
                return NotFound();  
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<MyTable>> CreateTable(MyTable table)
        {
          var data=await  context.MyTables.AddAsync(table);
            return Ok(data);
        }





















    }
}
