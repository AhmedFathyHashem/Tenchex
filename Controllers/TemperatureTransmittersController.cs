using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tenchex.Models;

namespace Tenchex.Controllers
{
    public class TemperatureTransmittersController : Controller
    {
        private readonly TenchexContext _context;

        public TemperatureTransmittersController(TenchexContext context)
        {
            _context = context;
        }

        // GET: TemperatureTransmitters
        public async Task<IActionResult> Index()
        {
              return _context.temperatureTransmitters != null ? 
                          View(await _context.temperatureTransmitters.ToListAsync()) :
                          Problem("Entity set 'TenchexContext.temperatureTransmitters'  is null.");
        }

        // GET: TemperatureTransmitters/Details/5
        public async Task<IActionResult> Details(Instrumentations ins)
        {
            if (ins == null || _context.temperatureTransmitters == null)
            {
                return NotFound();
            }

            TemperatureTransmitter? temperatureTransmitter = await _context.temperatureTransmitters
                .FirstOrDefaultAsync(m => m.TemperatureTransmitterId == ins.TemperatureTransmitterId);
            if (temperatureTransmitter == null)
            {
                return NotFound();
            }

            return View(temperatureTransmitter);
        }

        // GET: TemperatureTransmitters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TemperatureTransmitters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TemperatureTransmitterId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,HousingMaterial,ProcessConnectionToThermowell,ProcessConnectionMaterial,InsertionLength,EmersionLength,TotalLength,WaveFrequencyCalculation,StemLength,StemDiameter,SpanRange,CallibrationRange,SensorType,Accuracy,Repeatabilty,Standard,Lcd,KeyPad,Protocol,_420mA,ThermowellType,ThermowellProcessConnection,ThermowellProcessConnectionMaterial")] TemperatureTransmitter temperatureTransmitter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperatureTransmitter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Set" , temperatureTransmitter);
            }
            return View(temperatureTransmitter);
        }

		public async Task<IActionResult> Set(TemperatureTransmitter temperatureTransmitter)
		{
			Instrumentations instrumentations = new()
			{
				TemperatureTransmitterId = temperatureTransmitter.TemperatureTransmitterId ,
                InstrumentType = InstrumentType.TemperatureTransmitter
			};
			_context.Add(instrumentations);
			await _context.SaveChangesAsync();
			Types type = new()
			{
				InstrumentId = instrumentations.InstrumentationId
			};
			_context.Add(type);
			await _context.SaveChangesAsync();
			return RedirectToAction("Create", "Equipments", type);
		}

		// GET: TemperatureTransmitters/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.temperatureTransmitters == null)
            {
                return NotFound();
            }

            var temperatureTransmitter = await _context.temperatureTransmitters.FindAsync(id);
            if (temperatureTransmitter == null)
            {
                return NotFound();
            }
            return View(temperatureTransmitter);
        }

        // POST: TemperatureTransmitters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TemperatureTransmitterId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,HousingMaterial,ProcessConnectionToThermowell,ProcessConnectionMaterial,InsertionLength,EmersionLength,TotalLength,WaveFrequencyCalculation,StemLength,StemDiameter,SpanRange,CallibrationRange,SensorType,Accuracy,Repeatabilty,Standard,Lcd,KeyPad,Protocol,_420mA,ThermowellType,ThermowellProcessConnection,ThermowellProcessConnectionMaterial")] TemperatureTransmitter temperatureTransmitter)
        {
            if (id != temperatureTransmitter.TemperatureTransmitterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperatureTransmitter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperatureTransmitterExists(temperatureTransmitter.TemperatureTransmitterId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(temperatureTransmitter);
        }

        // GET: TemperatureTransmitters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.temperatureTransmitters == null)
            {
                return NotFound();
            }

            var temperatureTransmitter = await _context.temperatureTransmitters
                .FirstOrDefaultAsync(m => m.TemperatureTransmitterId == id);
            if (temperatureTransmitter == null)
            {
                return NotFound();
            }

            return View(temperatureTransmitter);
        }

        // POST: TemperatureTransmitters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.temperatureTransmitters == null)
            {
                return Problem("Entity set 'TenchexContext.temperatureTransmitters'  is null.");
            }
            var temperatureTransmitter = await _context.temperatureTransmitters.FindAsync(id);
            if (temperatureTransmitter != null)
            {
                _context.temperatureTransmitters.Remove(temperatureTransmitter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperatureTransmitterExists(int id)
        {
          return (_context.temperatureTransmitters?.Any(e => e.TemperatureTransmitterId == id)).GetValueOrDefault();
        }
    }
}
