using MachineStatusApi.Data;
using MachineStatusApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MachineStatusAPI.Controllers
{
    [ApiController]
    [Route("api/machine")]
    public class MachineController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MachineController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMachine(Machine machine)
        {
            _context.Machines.Add(machine);
            _context.SaveChanges();
            return Ok(machine);
        }

        [HttpGet("{id}")]
        public IActionResult GetMachine(int id)
        {
            var machine = _context.Machines.Find(id);
            if (machine == null)
                return NotFound();

            return Ok(machine);
        }

        [HttpPut("start/{id}")]
        public IActionResult StartMachine(int id)
        {
            var machine = _context.Machines.Find(id);
            if (machine == null)
                return NotFound();

            machine.IsRunning = true;
            _context.SaveChanges();
            return Ok(machine);
        }

        [HttpPut("stop/{id}")]
        public IActionResult StopMachine(int id)
        {
            var machine = _context.Machines.Find(id);
            if (machine == null)
                return NotFound();

            machine.IsRunning = false;
            _context.SaveChanges();
            return Ok(machine);
        }
    }
}
