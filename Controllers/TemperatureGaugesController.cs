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
    public class TemperatureGaugesController : Controller
    {
        private readonly TenchexContext _context;

        public TemperatureGaugesController(TenchexContext context)
        {
            _context = context;
        }

        // GET: TemperatureGauges
        public async Task<IActionResult> Index()
        {
              return _context.temperatureGauges != null ? 
                          View(await _context.temperatureGauges.ToListAsync()) :
                          Problem("Entity set 'TenchexContext.temperatureGauges'  is null.");
        }

        // GET: TemperatureGauges/Details/5
        public async Task<IActionResult> Details(Instrumentations ins)
        {
            if (ins == null || _context.temperatureGauges == null)
            {
                return NotFound();
            }

            TemperatureGauge? temperatureGauge = await _context.temperatureGauges
                .FirstOrDefaultAsync(m => m.TemperatureGaugeId == ins.TemperatureGaugeId);
            if (temperatureGauge == null)
            {
                return NotFound();
            }

            return View(temperatureGauge);
        }

        // GET: TemperatureGauges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TemperatureGauges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TemperatureGaugeId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,ProcessConnectionToThermowell,ProcessConnectionMaterial,InsertionLength,EmersionLength,TotalLength,WaveFrequencyCalculation,StemLength,StemDiameter,SpanRange,SensorType,Accuracy,Repeatabilty,Standard,ThermowellType,ThermowellProcessConnection,ThermowellProcessConnectionMaterial,CaseMaterial,DialSize,CaseFilling,GlassType")] TemperatureGauge temperatureGauge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperatureGauge);
                await _context.SaveChangesAsync();
                return RedirectToAction("Set" , temperatureGauge);
            }
            return View(temperatureGauge);
        }

		public async Task<IActionResult> Set(TemperatureGauge temperatureGauge)
		{
			Instrumentations instrumentations = new()
			{
				TemperatureGaugeId = temperatureGauge.TemperatureGaugeId,
                InstrumentType = InstrumentType.TemperatureGauge,
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

		// GET: TemperatureGauges/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.temperatureGauges == null)
            {
                return NotFound();
            }

            var temperatureGauge = await _context.temperatureGauges.FindAsync(id);
            if (temperatureGauge == null)
            {
                return NotFound();
            }
            return View(temperatureGauge);
        }

        // POST: TemperatureGauges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TemperatureGaugeId,Kks,ModelNumber,AreaClassification,Ip,ElementMaterial,ProcessConnectionToThermowell,ProcessConnectionMaterial,InsertionLength,EmersionLength,TotalLength,WaveFrequencyCalculation,StemLength,StemDiameter,SpanRange,SensorType,Accuracy,Repeatabilty,Standard,ThermowellType,ThermowellProcessConnection,ThermowellProcessConnectionMaterial,CaseMaterial,DialSize,CaseFilling,GlassType")] TemperatureGauge temperatureGauge)
        {
            if (id != temperatureGauge.TemperatureGaugeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperatureGauge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperatureGaugeExists(temperatureGauge.TemperatureGaugeId))
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
            return View(temperatureGauge);
        }

        // GET: TemperatureGauges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.temperatureGauges == null)
            {
                return NotFound();
            }

            var temperatureGauge = await _context.temperatureGauges
                .FirstOrDefaultAsync(m => m.TemperatureGaugeId == id);
            if (temperatureGauge == null)
            {
                return NotFound();
            }

            return View(temperatureGauge);
        }

        // POST: TemperatureGauges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.temperatureGauges == null)
            {
                return Problem("Entity set 'TenchexContext.temperatureGauges'  is null.");
            }
            var temperatureGauge = await _context.temperatureGauges.FindAsync(id);
            if (temperatureGauge != null)
            {
                _context.temperatureGauges.Remove(temperatureGauge);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperatureGaugeExists(int id)
        {
          return (_context.temperatureGauges?.Any(e => e.TemperatureGaugeId == id)).GetValueOrDefault();
        }
    }
}
